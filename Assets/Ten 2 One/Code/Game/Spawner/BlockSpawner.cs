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
        private IDataProvider<BlockModel[]> _blockDataProvider;

        private readonly Stack<BlockModel> _buildedModels = new();
        private readonly List<IBlock> _spawnedBlocks = new();

        private BlockModel GetRandomModel()
        {
            if (_buildedModels.Count > 3)
                _buildedModels.Peek();

            var data = _blockDataProvider.GetData();

            BlockModel model = null;

            while (model == null)
            {
                var randomModel = data[Random.Range(0, data.Length)];
                /*
                if (_buildedModels.Contains(randomModel) == false)
                    model = randomModel;
                */
                model = randomModel;
            }

            _buildedModels.Push(model);

            return model;
        }

        private void Build()
        {
            var block = _blockFactory.Build(GetRandomModel(), transform);

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

        public void Init(BlockFactory blockFactory, IBlockPlacer blockPlacer, IBoardTileMatcher boardTileMatcher, IDataProvider<BlockModel[]> blockDataProvider)
        {
            _blockFactory = blockFactory;
            _blockPlacer = blockPlacer;
            _boardTileMatcher = boardTileMatcher;
            _blockDataProvider = blockDataProvider;

            _blockPlacer.OnPlace += OnBlockPlace;
            _boardTileMatcher.OnMatch += OnMatch;

            BuildStartBlocks();
        }

        public void BuildStartBlocks()
        {
            for (int i = 0; i < 3; i++)
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