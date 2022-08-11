using UnityEngine;
using UnityEngine.UI;

namespace Un1T3G.Ten2One
{
    [RequireComponent(typeof(Image))]
    public class BoardTileHighlighter : MonoBehaviour
    {
        [SerializeField] private BoardTile _tile;
        [SerializeField] private Color _highlightColor;

        private Image _image;
        private Color _beginColor;

        private void Start()
        {
            _image = GetComponent<Image>();
            _beginColor = _image.color;
        }

        private void OnEnable()
        {
            _tile.OnSelectedTileChanged += OnSelectedTileChanged;
        }

        private void OnSelectedTileChanged(IBlockTile tile)
        {
            _image.color = tile == null ? _beginColor : _highlightColor;
        }

        public void OnDisable()
        {
            _tile.OnSelectedTileChanged -= OnSelectedTileChanged;
        }
    }
}
