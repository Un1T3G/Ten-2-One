using UnityEngine;
using System;
using Un1T3G.Pool;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Un1T3G.Ten2One
{
    public class BoardTileMatcher : MonoBehaviour, IBoardTileMatcher
    {
        private IBlockPlacer _blockPlacer;
        private BoardTileMatchFinder _boardTileMatchFinder;

        public event Action OnMatchFind;
        public event Action OnMatch;
        public event Action<IBlockTile> OnMatching;

        private void OnDestroy()
        {
            if (_blockPlacer == null)
                return;

            _blockPlacer.OnPlace -= OnBlockPlaced;
        }

        private async Task Match(List<List<BoardTile>> match)
        {
            foreach (var matchList in match)
            {
                foreach (var tile in matchList)
                {
                    await Task.Delay(100);

                    OnMatching?.Invoke(tile.SelectedTile);

                    tile.SelectedTile.Root.gameObject.SetActive(false);
                }
            }

            foreach (var matchList in match)
            {
                foreach (var tile in matchList)
                {
                    tile.Reset();
                }
            }
        }

        private async void OnBlockPlaced(PlacedBlockStatus status)
        {
            var match = _boardTileMatchFinder.Find();

            if (match == null)
                return;

            OnMatchFind?.Invoke();

            await Match(match);

            OnMatch?.Invoke();
        }

        public void Init(IBlockPlacer blockPlacer, BoardTileMatchFinder boardTileMatchFinder)
        {
            _blockPlacer = blockPlacer;
            _boardTileMatchFinder = boardTileMatchFinder;

            _blockPlacer.OnPlace += OnBlockPlaced;
        }
    }
}
