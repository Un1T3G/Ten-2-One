using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace Un1T3G.Ten2One
{
    [RequireComponent(typeof(Image))]
    public class BlockTileView : MonoBehaviour
    {
        [SerializeField] private Color[] _colors;
        [SerializeField] private Color _rockColor;
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private BlockTile _tile;

        private Image _image;
        private Tween _tween;

        private readonly float _animationDuration = .3f;
        private readonly Ease _animationEase = Ease.InCirc;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            _tile.OnValueChanged += OnValueChanged;
        }

        private void OnDisable()
        {
            _tile.OnValueChanged -= OnValueChanged;
        }

        private void ChangeTextValue(int value)
        {
            _text.text = value == 0 ? "" : $"{value}";
        }

        private void ChangeBlockColor(int value)
        {
            var duration = _tile.IsSetup ? _animationDuration : 0f;
            var targetColor = value == 0 ? _rockColor : _colors[value - 1];
            _image.DOColor(_rockColor, duration / 2).SetEase(_animationEase).OnComplete(() =>
            {
                _image.DOColor(targetColor, duration / 2).SetEase(_animationEase);
            });
        }

        private void StartPunching()
        {
            _tween = transform.DOPunchScale(Vector2.one * 0.1f,
                    _animationDuration * 2).SetEase(_animationEase).SetLoops(int.MaxValue);
        }

        private void StopPunching()
        {
            if (_tween != null)
                _tween.Kill(true);
        }

        private void OnValueChanged(int value)
        {
            if (value < 0)
                return;

            ChangeTextValue(value);
            ChangeBlockColor(value);

            if (value == 1)
                StartPunching();
            else
                StopPunching();
        }
    }
}
