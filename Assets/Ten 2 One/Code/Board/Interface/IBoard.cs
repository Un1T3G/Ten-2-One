using UnityEngine;

namespace Un1T3G.Ten2One
{
    public interface IBoard
    {
        int Rows { get; }

        int Columns { get; }

        BoardTile GetTile(Vector2Int index);

        bool IndexInBound(Vector2Int index);
    }
}
