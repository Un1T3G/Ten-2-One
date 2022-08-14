using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;
using Un1T3G.Pool;

namespace Un1T3G.Ten2One
{
    public class BlockFactory : MonoBehaviour
    {
        [SerializeField] private int _minValue;
        [SerializeField] private int _maxValue;
        [SerializeField] private Block _blockPrefab;
        [SerializeField] private BlockTile _blockTilePrefab;

        private IBoard _board;
        private Transform _boardRoot;
        private float _canvasScaleFactor;

        public event Action<Block> OnBuild;

        public void Init(IBoard board, Transform boardRoot, float canvasScaleFactor)
        {
            _board = board;
            _boardRoot = boardRoot;
            _canvasScaleFactor = canvasScaleFactor;
        }

        public Block Build(BlockModel model, Transform parent)
        {
            var size = _board.GetTile(Vector2Int.zero).Size;
            var spacingBetweenTile = Vector2.Distance(
                _board.GetTile(Vector2Int.zero).Position, 
                _board.GetTile(new Vector2Int(1, 0)).Position) - 
                size.x;

            var block = PoolManager.Spawn(_blockPrefab, parent);
            block.Init(_boardRoot, _canvasScaleFactor);
            block.Size = new Vector2(model.Columns, model.Rows) * 
                size.x + spacingBetweenTile * 
                new Vector2(model.Columns - 1, model.Rows - 1);

            var map = model.Map;
            var children = new List<IBlockTile>();

            var value = Random.Range(_minValue, _maxValue + 1);
            var position = -block.Size / 2 + size / 2;

            for (int i = 0; i < model.Rows; i++)
            {
                for (int j = 0; j < model.Columns; j++)
                {
                    if (map[i, j] == false)
                        continue;

                    var tile = PoolManager.Spawn(_blockTilePrefab, block.transform);
                    tile.Init();

                    tile.Position = position + new Vector2(j, i) * (size + spacingBetweenTile *  Vector2.one);
                    tile.Size = size;

                    tile.Setup(value, new Vector2Int(j, i));
                    children.Add(tile);
                }
            }

            block.Setup(children);

            OnBuild?.Invoke(block);

            return block;
        }
    }
}
