using UnityEngine;
using System.Linq;

namespace Un1T3G.Ten2One
{
    public class BlockTileValueIncreaser : MonoBehaviour
    {
        private IBoard _board;
        private IBlockPlacer _blockPlacer;

        private void OnDestroy()
        {
            if (_blockPlacer != null)
                _blockPlacer.OnPlace -= OnBlockPlace;
        }

        private void OnBlockPlace(PlacedBlockStatus status)
        {
            if (status.HasMatch)
                return;

            var ignoreTiles = status.Block.Tiles.ToList();

            for (int i = 0; i < _board.Rows; i++)
            {
                for (int j = 0; j < _board.Columns; j++)
                {
                    var tile = _board.GetTile(new Vector2Int(j, i)).SelectedTile;

                    if (tile == null)
                        continue;

                    if (tile.IsRock)
                        continue;

                    if (ignoreTiles.Contains(tile))
                        continue;

                    tile.DecreaseValue();
                }
            }
        }

        public void Init(IBoard board, IBlockPlacer blockPlacer)
        {
            _board = board;
            _blockPlacer = blockPlacer;

            _blockPlacer.OnPlace += OnBlockPlace;
        }
    }
}
