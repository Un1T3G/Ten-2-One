using UnityEngine;
using DG.Tweening;

namespace Un1T3G.Ten2One
{
    [RequireComponent(typeof(CanvasGroup))]
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private float _disabledAlpha;
        [SerializeField] private Vector2 _noramlScale;
        [SerializeField] private Vector2 _onPointerDownScale;
        [SerializeField] private Block _block;

        private CanvasGroup _canvasGroup;

        private readonly float _animationDuration = .3f;
        private readonly Ease _animationEase = Ease.InCirc;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _block.Scale = _noramlScale;
        }

        private void OnEnable()
        {
            _block.OnPointerUpEvent += OnPointerUp;
            _block.OnIntreactableChange += OnIntreactableChange;
            _block.OnPointerDownEvent += OnPointerDown;
        }

        private void OnDisable()
        {
            _block.OnPointerUpEvent -= OnPointerUp;
            _block.OnIntreactableChange -= OnIntreactableChange;
            _block.OnPointerDownEvent -= OnPointerDown;
        }

        private void OnPointerUp(IBlock block)
        {
            _block.transform.DOScale(_noramlScale, _animationDuration).SetEase(_animationEase);
        }

        private void OnIntreactableChange(bool value)
        {
            var targetAlpha = value ? 1 : _disabledAlpha;
            _canvasGroup.DOFade(targetAlpha, _animationDuration).SetEase(_animationEase);
        }

        public void OnPointerDown(IBlock block)
        {
            _block.Scale = _onPointerDownScale;
            _block.transform.DOScale(_onPointerDownScale, _animationDuration).SetEase(_animationEase);
        }
    }
}