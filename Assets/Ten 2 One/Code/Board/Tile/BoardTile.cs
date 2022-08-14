using System;
using Un1T3G.Pool;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTile : TransformableBehaviour
    {
        private bool _tilePlaced;

        public bool TilePlaced => _tilePlaced;
        public IBlockTile SelectedTile { get; private set; }

        public event Action<IBlockTile> OnSelectedTileChanged;
        public event Action OnTilePlaced;

        public void Setup()
        {
            base.Init();
        }

        public void Place(IBlockTile tile)
        {
            if (_tilePlaced)
                throw new InvalidOperationException();

            tile.Root.SetParent(_transform);
            tile.Position = Vector2.zero;
            tile.Scale = Vector2.one;

            _tilePlaced = true;

            OnTilePlaced?.Invoke();
        }

        public void SetSelectedTile(IBlockTile tile)
        {
            SelectedTile = tile;
            OnSelectedTileChanged?.Invoke(tile);
        }

        public void Reset()
        {
            if (_tilePlaced)
                PoolManager.Despawn(SelectedTile.Root.gameObject);

            _tilePlaced = false;
        }
    }
}