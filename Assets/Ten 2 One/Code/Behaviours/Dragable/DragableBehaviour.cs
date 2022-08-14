using System;
using UnityEngine.EventSystems;

namespace Un1T3G.Ten2One
{
    public class DragableBehaviour : TransformableBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IIntreactable
    {
        private bool _intreactable = true;
        private float _scaleFactor;

        public event Action<bool> OnIntreactableChange;

        public bool Intreactable
        {
            get => _intreactable;
            set
            {
                if (value == _intreactable)
                    return;

                _intreactable = value;
                OnIntreactableChange?.Invoke(value);
            }
        }

        protected virtual void Init(float scaleFactor)
        {
            _scaleFactor = scaleFactor;
            base.Init();
        }

        protected virtual void PointerUp() { }

        protected virtual void Draging() { }

        protected virtual void PointerDown() { }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_intreactable == false)
                return;

            PointerUp();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_intreactable == false)
                return;

            Position += eventData.delta / _scaleFactor;
            Draging();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_intreactable == false)
                return;

            PointerDown();
        }
    }
}
