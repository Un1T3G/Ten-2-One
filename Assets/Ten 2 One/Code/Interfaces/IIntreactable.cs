using System;

namespace Un1T3G.Ten2One
{
    public interface IIntreactable
    {
        bool Intreactable { get; set; }

        event Action<bool> OnIntreactableChange;
    }
}