using System;

namespace Un1T3G.Ten2One
{
    public interface IBoardTileMatcher
    {
        event Action OnMatchFind;
        event Action OnMatch;
    }
}
