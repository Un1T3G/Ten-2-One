using System.Collections.Generic;

namespace Un1T3G.Ten2One
{
    public class PlacedBlockStatus
    {
        public readonly IBlock Block;
        public readonly List<List<BoardTile>> TileMatch;
        public bool HasMatch => TileMatch != null;

        public PlacedBlockStatus(IBlock block, List<List<BoardTile>> tileMatch)
        {
            Block = block;
            TileMatch = tileMatch;
        }
    }
}
