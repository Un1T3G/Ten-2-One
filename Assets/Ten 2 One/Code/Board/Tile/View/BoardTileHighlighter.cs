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
            _tile.OnTilePlaced += OnTilePlaced;
        }

        private void OnTilePlaced()
        {
            _image.color = _beginColor;
        }

        private void OnSelectedTileChanged(IBlockTile tile)
        {
            if (_tile.TilePlaced)
            {
                _image.color = _beginColor;
                return;
            }

            _image.color = tile == null ? _beginColor : _highlightColor;
        }

        public void OnDisable()
        {
            _tile.OnSelectedTileChanged -= OnSelectedTileChanged;
            _tile.OnTilePlaced -= OnTilePlaced;
        }
    }
}
