using UnityEngine;
using System.Collections.Generic;
using Un1T3G.Pool;

namespace Un1T3G.Ten2One
{
    public class BlockSpawner : MonoBehaviour
    {
        private BlockFactory _blockFactory;
        private IBlockPlacer _blockPlacer;
        private IBoardTileMatcher _boardTileMatcher;
        private IBlockDataProvider _blockDataProvider;

        private readonly List<IBlock> _spawnedBlocks = new();
        private readonly int _maxBlockCount = 3;

        private void Build()
        {
            var data = _blockDataProvider.GetData();
            var randomModel = data[Random.Range(0, data.Length)];
            var block = _blockFactory.Build(randomModel, transform);

            _spawnedBlocks.Add(block);
        }

        private void OnBlockPlace(PlacedBlockStatus status)
        {
            if (status.HasMatch)
                return;

            Build();

            _spawnedBlocks.Remove(status.Block);
        }

        private void OnMatch()
        {
            Build();
        }

        private void OnDestroy()
        {
            if (_blockPlacer != null)
                _blockPlacer.OnPlace -= OnBlockPlace;

            if (_boardTileMatcher != null)
                _boardTileMatcher.OnMatch -= OnMatch;
        }

        public void Init(BlockFactory blockFactory, IBlockPlacer blockPlacer, IBoardTileMatcher boardTileMatcher, IBlockDataProvider blockDataProvider)
        {
            _blockFactory = blockFactory;
            _blockPlacer = blockPlacer;
            _boardTileMatcher = boardTileMatcher;
            _blockDataProvider = blockDataProvider;

            _blockPlacer.OnPlace += OnBlockPlace;
            _boardTileMatcher.OnMatch += OnMatch;
        }

        public void BuildStartBlocks()
        {
            for (int i = 0; i < _maxBlockCount; i++)
                Build();
        }

        public void DestroySpawnedBlocks()
        {
            foreach (var child in _spawnedBlocks)
                PoolManager.Despawn(child.Root.gameObject);

            _spawnedBlocks.Clear();
        }
    }
}