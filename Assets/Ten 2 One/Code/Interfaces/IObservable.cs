using System;

namespace Un1T3G.Ten2One
{
    public interface IObservable<T>
    {
        event Action<T> OnValueChanged;
    }
}
