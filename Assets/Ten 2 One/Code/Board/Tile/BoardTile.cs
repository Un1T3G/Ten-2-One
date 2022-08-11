using System;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTile : TransformableBehaviour
    {
        private bool _tilePlaced;

        public bool TilePlaced => _tilePlaced;
        public IBlockTile SelectedTile { get; private set; }

        public event Action<IBlockTile> OnSelectedTileChanged;

        public void Place(IBlockTile tile)
        {
            if (_tilePlaced)
                throw new InvalidOperationException();

            tile.Root.SetParent(_transform);
            tile.Position = Vector2.zero;

            _tilePlaced = true;
        }

        public void SetSelectedTile(IBlockTile tile)
        {
            if (SelectedTile != null && tile != null)
                if (tile.Root == SelectedTile.Root)
                    return;

            SelectedTile = tile;
            OnSelectedTileChanged?.Invoke(tile);
        }
    }
}