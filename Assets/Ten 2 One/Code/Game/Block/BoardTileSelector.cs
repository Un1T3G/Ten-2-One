using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTileSelector : MonoBehaviour
    {
        private IBoard _board;
        private IBlock _selectedBlock;
        private BoardTileFinder _boardTileFinder;
        private List<Vector2> _tilePlacementPositions;

        private void Update()
        {
            if (_selectedBlock == null)
                return;

            if (_tilePlacementPositions.Count == 0)
            {
                foreach (var tile in _selectedBlock.Tiles)
                {
                    var positon = _selectedBlock.Position + tile.Position;
                    var boardTile = _boardTileFinder.Find(positon);

                    if (boardTile == null)
                    {
                        _tilePlacementPositions.Clear();
                        ResetBoardTiles();
                        return;
                    }

                    if (boardTile.TilePlaced)
                    {
                        _tilePlacementPositions.Clear();
                        ResetBoardTiles();
                        return;
                    }

                    _tilePlacementPositions.Add(positon);
                }
            }

            if (_tilePlacementPositions.Count > 0)
            {

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