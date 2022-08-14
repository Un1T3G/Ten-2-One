using UnityEngine;
using System;
using Un1T3G.Pool;

namespace Un1T3G.Ten2One
{
    public class BlockTile : TransformableBehaviour, IBlockTile, IPoolable
    {
        private int _value;
        private Vector2Int _index;

        public int Value => _value;
        public Vector2Int Index => _index;
        public bool IsRock => _value < 0;

        public bool IsSetup { get; private set; }

        public event Action<int> OnValueChanged;

        public void Setup(int value, Vector2Int index)
        {
            _value = value;
            OnValueChanged?.Invoke(value);
            _index = index;
            IsSetup = true;
        }

        public void DecreaseValue()
        {
            OnValueChanged?.Invoke(--_value);
        }

        public void OnSpawn()
        {
            
        }

        public void OnDespawn()
        {
            IsSetup = false;
            Scale = Vector2.one;
        }
    }
}
