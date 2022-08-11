using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace Un1T3G.Ten2One
{
    public class BlockPlacer : MonoBehaviour, IDropHandler, IBlockPlacer
    {
        public event Action<IBlock> OnPlace;

        private bool IsReadyToPlace(IBlock block)
        {
            foreach (var tile in block.Tiles)
            {
                if (tile == null)
                    return false;
            }

            return true;
        }

        private void Place(IBlock block)
        {
            foreach (var tile in block.Tiles)
            {
                var boardTile = transform;

                tile.Root.SetParent(boardTile.transform);
                tile.Position = Vector2.zero;
            }

            Destroy(block.Root.gameObject);

            OnPlace?.Invoke(block);
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag.TryGetComponent<IBlock>(out var block))
                if (IsReadyToPlace(block))
                    Place(block);
        }
    }
}
