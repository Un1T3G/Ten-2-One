using System;

namespace Un1T3G.Ten2One
{
    public interface IBlockPlacer
    {
        event Action<IBlock> OnPlace;
    }
}
