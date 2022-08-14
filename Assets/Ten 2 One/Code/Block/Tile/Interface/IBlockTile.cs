using UnityEngine;

namespace Un1T3G.Ten2One
{
    public interface IBlockTile : ITransformable
    {
        int Value { get; }

        Vector2Int Index { get; }

        bool IsRock { get; }

        void DecreaseValue();
    }
}
