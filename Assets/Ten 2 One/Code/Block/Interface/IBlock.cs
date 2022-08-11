using System;
using System.Collections.Generic;


namespace Un1T3G.Ten2One
{
    public interface IBlock : ITransformable, IIntreactable
    {
        IEnumerable<IBlockTile> Tiles { get; }

        event Action<IBlock> OnPointerDownEvent;
        event Action<IBlock> OnDragEvent;
        event Action<IBlock> OnPointerUpEvent;
    }
}
