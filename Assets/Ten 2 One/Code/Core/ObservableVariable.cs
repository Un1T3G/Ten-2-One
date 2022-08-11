using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Un1T3G.Ten2One
{
    public class ObservableVariable<T> : IObservable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        public event Action<T> OnValueChanged;

        public ObservableVariable()
        {
            _value = default;
        }

        public ObservableVariable(T defaultValue)
        {
            _value = defaultValue;
        }
    }
}
