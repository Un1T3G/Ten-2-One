using UnityEngine;
using UnityEngine.EventSystems;

namespace Un1T3G.Ten2One
{
    public class DragableBehaviour : TransformableBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IIntreactable
    {
        private bool _intreactable = true;
        private float _scaleFactor;
        private Vector2 _beginPosition;

        public bool Intreactable
        {
            get => _intreactable;
            set => _intreactable = value;
        }

        protected virtual void Init(float scaleFactor)
        {
            _scaleFactor = scaleFactor;
        }

        protected virtual void PointerUp() { }

        protected virtual void Draging() { }

        protected virtual void PointerDown() { }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_intreactable == false)
                return;

            _beginPosition = _transform.anchoredPosition;

            PointerUp();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (_intreactable == false)
                return;

            _transform.anchoredPosition += eventData.delta / _scaleFactor;
            Draging();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_intreactable == false)
                return;

            _transform.anchoredPosition = _beginPosition;

            PointerDown();
        }
    }
}
