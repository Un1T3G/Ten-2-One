using System.Collections.Generic;
using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTileMatchFinder : MonoBehaviour, IBoardTileMatchFinder
    {
        private IBoard _board;

        private List<List<BoardTile>> GetVertical()
        {
            List<List<BoardTile>> matches = new();

            for (int i = 0; i < _board.Rows; i++)
            {
                List<BoardTile> tiles = new();

                for (int j = 0; j < _board.Columns; j++)
                {
                    var tile = _board.GetTile(new Vector2Int(i, j));

                    if (tile.SelectedTile == null)
                        break;

                    if (tile.SelectedTile.IsRock)
                        break;

                    tiles.Add(tile);
                }

                if (tiles.Count == _board.Rows)
                    matches.Add(tiles);
            }

            return matches.Count > 0 ? matches: null;
        }

        private List<List<BoardTile>> GetHorizontal()
        {
            List<List<BoardTile>> matches = new();

            for (int i = 0; i < _board.Rows; i++)
            {
                List<BoardTile> tiles = new();

                for (int j = 0; j < _board.Columns; j++)
                {
                    var tile = _board.GetTile(new Vector2Int(j, i));

                    if (tile.SelectedTile == null)
                        break;

                    if (tile.SelectedTile.IsRock)
                        break;

                    tiles.Add(tile);
                }

                if (tiles.Count == _board.Rows)
                    matches.Add(tiles);
            }

            return matches.Count > 0 ? matches : null;
        }

        public void Init(IBoard board)
        {
            _board = board;
        }

        public List<List<BoardTile>> Find()
        {
            var verticalMatch = GetVertical();
            if (verticalMatch != null)
                return verticalMatch;

            var horizontalMatch = GetHorizontal();
            if (horizontalMatch != null)
                return horizontalMatch;

            return null;
        }
    }
}