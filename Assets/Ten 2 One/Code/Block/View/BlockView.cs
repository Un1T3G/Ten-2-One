using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private Vector2 _noramlScale;
        [SerializeField] private Vector2 _onPointerDownScale;
        [SerializeField] private Block _block;

        private Vector2 _beginPosition;

        private void Start()
        {
            _block.Scale = _noramlScale;
        }

        private void OnEnable()
        {
            _block.OnPointerUpEvent += OnPointerUp;
            _block.OnPointerDownEvent += OnPointerDown;
        }

        private void OnDisable()
        {
            _block.OnPointerUpEvent -= OnPointerUp;
            _block.OnPointerDownEvent -= OnPointerDown;
        }

        private void OnPointerUp(IBlock block)
        {
            _block.Position = _beginPosition;
            _block.Scale = _noramlScale;
        }

        public void OnPointerDown(IBlock block)
        {
            _beginPosition = _block.Position;
            _block.Scale = _onPointerDownScale;
        }
    }
}