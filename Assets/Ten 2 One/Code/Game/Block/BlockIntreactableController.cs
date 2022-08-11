using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BlockIntreactableController : MonoBehaviour
    {
        [SerializeField] private BlockFactory _blockFactory;

        private IBlockPlacer _blockPlacer;
        private IBlockSizeFitter _blockSizeFitter;

        private readonly List<IBlock> _blocks = new();

        private void OnEnable()
        {
            _blockFactory.OnBuild += OnBlockBuild;
        }

        private void OnDisable()
        {
            _blockFactory.OnBuild -= OnBlockBuild;
        }

        private void OnDestroy()
        {
            if (_blockPlacer == null)
                return;

            _blockPlacer.OnPlace -= OnBlockPlace;
        }

        private void OnBlockBuild(IBlock block)
        {
            _blocks.Add(block);
        }

        private void OnBlockPlace(IBlock block)
        {
            _blocks.Remove(block);

            ControlIntreactable();
        }

        private void ControlIntreactable()
        {
            foreach (var block in _blocks)
                block.Intreactable = _blockSizeFitter.CanFit(block);
        }

        public void Init(IBlockPlacer blockPlacer, IBlockSizeFitter blockSizeFitter)
        {
            _blockPlacer = blockPlacer;
            _blockSizeFitter = blockSizeFitter;
            _blockPlacer.OnPlace += OnBlockPlace;
        }
    }
}
