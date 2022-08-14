using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTileFinder : MonoBehaviour
    {
        private IBoard _board;
        private UIGridContainer _uiGridContainer;

        public void Init(IBoard board, UIGridContainer uiGridContainer)
        {
            _board = board;
            _uiGridContainer = uiGridContainer;
        }

        public BoardTile Find(Vector2 position)
        {
            var size = _uiGridContainer.ChildSize + Vector2.one * _uiGridContainer.SpacingBetweenItem;

            position += new Vector2(_uiGridContainer.Width, _uiGridContainer.Height) / 2 - _uiGridContainer.InsetSpacing * Vector2.one;

            Vector2Int index = new(
                Mathf.FloorToInt(position.x / size.x),
                Mathf.FloorToInt(position.y / size.y));

            if (_board.IndexInBound(index))
                return _board.GetTile(index);

            return null;
        }
    }
}
