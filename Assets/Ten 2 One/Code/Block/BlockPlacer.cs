using UnityEngine;
using System;
using Un1T3G.Pool;

namespace Un1T3G.Ten2One
{
    public class BlockPlacer : MonoBehaviour, IBlockPlacer
    {
        private BoardTileFinder _boardTileFinder;
        private IBoardTileMatchFinder _boardTielMatchFinder;

        public event Action<PlacedBlockStatus> OnPlace;

        private void OnEnable()
        {
            BlockEvent.OnPointerUp += OnBlockRelased;
        }

        private void OnDisable()
        {
            BlockEvent.OnPointerUp -= OnBlockRelased;
        }

        private void OnBlockRelased(IBlock block)
        {
            if (IsReadyToPlace(block))
                Place(block);
        }

        private bool IsReadyToPlace(IBlock block)
        {
            foreach (var tile in block.Tiles)
            {
                var boardTile = _boardTileFinder.Find((block.Position + tile.Position) * new Vector2(1, -1));

                if (boardTile == null)
                    return false;

                if (boardTile.TilePlaced)
                    return false;

                if (boardTile.SelectedTile == null)
                    return false;
            }

            return true;
        }

        private void Place(IBlock block)
        {
            foreach (var tile in block.Tiles)
            {
                var boardTile = _boardTileFinder.Find((block.Position + tile.Position) * new Vector2(1, -1));

                boardTile.Place(tile);
            }

            var status = new PlacedBlockStatus(block, 
                _boardTielMatchFinder.Find());

            OnPlace?.Invoke(status);

            PoolManager.Despawn(block.Root.gameObject);
        }

        public void Init(BoardTileFinder boardTileFinder, IBoardTileMatchFinder boardTileMatchFinder)
        {
            _boardTileFinder = boardTileFinder;
            _boardTielMatchFinder = boardTileMatchFinder;
        }
    }
}
