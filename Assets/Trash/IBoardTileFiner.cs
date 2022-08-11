using UnityEngine;
using Un1T3G.Ten2One;

public interface IBoardTileFiner
{ 
    BoardTile GetTile(Vector2 position);
}

internal class BoardTileFinder : IBoardTileFiner
{
    public BoardTile GetTile(Vector2 position)
    {
        return null;
    }
}
