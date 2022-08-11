using UnityEngine;
using System;

namespace Un1T3G.Ten2One
{
    public class BlockTile : TransformableBehaviour, IBlockTile
    {
        private int _value;
        private Vector2Int _index;

        public int Value => _value;
        public Vector2Int Index => _index;

        public event Action<int> OnValueChanged;

        public void Init(int value, Vector2Int index)
        {
            _value = value;
            OnValueChanged?.Invoke(value);
            _index = index;
        }

        public void DecreaseValue()
        {
            OnValueChanged?.Invoke(--_value);
        }
    }
}
