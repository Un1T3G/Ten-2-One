using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BlockSizeFitter : MonoBehaviour, IBlockSizeFitter
    {
        private IBoard _board;

        public IBoard Board => _board;

        public void Init(IBoard board)
        {
            _board = board;
        }

        public bool CanFit(IBlock block)
        {
            bool CanOnPositon(int i, int j)
            {
                foreach(var tile in block.Tiles)
                {
                    var index = tile.Index + new Vector2Int(j, i);
                    var isIndexInBound = _board.IndexInBound(index);

                    if (isIndexInBound == false)
                        return false;

                    var boardTile = _board.GetTile(index);

                    if (boardTile.SelectedTile != null)
                        return false;
                }

                return true;
            }

            for (int i = 0; i < _board.Rows; i++)
                for (int j = 0; j < _board.Columns; j++)
                    if (CanOnPositon(i, j))
                        return true;

            return false;
        }
    }
}