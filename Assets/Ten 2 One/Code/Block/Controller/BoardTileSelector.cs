using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Un1T3G.Ten2One
{
    public class BoardTileSelector : MonoBehaviour
    {
        private IBoard _board;
        private BoardTile _cursorPoint;
        private IBlock _selectedBlock;
        private BoardTileFinder _boardTileFinder;
        private void OnEnable()
        {
            BlockEvent.OnPointerDown += BlockOnPointerDown;
            BlockEvent.OnPointerUp += BlockOnPointerUp;
        }
        private void OnDisable()
        {
            BlockEvent.OnPointerDown -= BlockOnPointerDown;
            BlockEvent.OnPointerUp -= BlockOnPointerUp;
        }
        private void BlockOnPointerDown(IBlock block)
        {
            _selectedBlock = block;
        }
        private void BlockOnPointerUp(IBlock block)
        {
            _cursorPoint = null;
            _selectedBlock = null;
        }
        private void Update()
        {
            if (_selectedBlock == null)
                return;

            var newCursorPoint = _boardTileFinder.Find((
                _selectedBlock.Position + _selectedBlock.Tiles.First().Position) * new Vector2(1, -1));

            if (newCursorPoint == null)
            {
                _cursorPoint = null;

                ResetBoardTiles();

                return;
            }

            if (newCursorPoint == _cursorPoint)
                return;

            _cursorPoint = newCursorPoint;

            ResetBoardTiles();

            foreach (var tile in _selectedBlock.Tiles)
            {
                var boardTile = _boardTileFinder.Find((_selectedBlock.Position + tile.Position) * new Vector2(1, -1));

                if (boardTile == null)
                    return;

                if (boardTile.TilePlaced)
                    return;
            }

            foreach (var tile in _selectedBlock.Tiles)
            {
                var boardTile = _boardTileFinder.Find((_selectedBlock.Position + tile.Position) * new Vector2(1, -1));

                if (boardTile.SelectedTile == null)
                    boardTile.SetSelectedTile(tile);
            }
        }
        private void ResetBoardTiles()
        {
            for (int i = 0; i < _board.Rows; i++) 
            {
                for (int j = 0; j < _board.Columns; j++)
                {
                    var boardTile = _board.GetTile(new Vector2Int(j, i));

                    if (boardTile.TilePlaced)
                        continue;

                    boardTile.SetSelectedTile(null);
                }
            }
        }
        public void Init(IBoard board, BoardTileFinder boardTileFinder)
        {
            _board = board;
            _boardTileFinder = boardTileFinder;
        }
    }
}