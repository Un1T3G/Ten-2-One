using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        private void OnValueChanged(int value)
        {
            if (value < 0)
                return;

            _text.text = value == 0 ? "" : $"{value}";
            _image.color = value == 0 ? _rockColor : _colors[value - 1];
        }
    }
}
