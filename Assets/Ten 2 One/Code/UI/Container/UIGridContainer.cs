using UnityEngine;

namespace Un1T3G.Ten2One
{
    [RequireComponent(typeof(RectTransform))]
    public class UIGridContainer : MonoBehaviour
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private float _insetSpacing;
        [SerializeField] private float _spacingBetweenItem;

        private RectTransform _transform;

        private float _parentWidth => _transform.rect.width;
        private float _parentHeight => _transform.rect.height;

        public float InsetSpacing => _insetSpacing;
        public float SpacingBetweenItem => _spacingBetweenItem;
        public Vector2 ChildSize => new Vector2(
                (_parentWidth - (_columns - 1) * _spacingBetweenItem - _insetSpacing * 2) / _columns,
                (_parentHeight - (_rows - 1) * _spacingBetweenItem - _insetSpacing * 2) / _rows
                );

        public void Init()
        {
            _transform = GetComponent<RectTransform>();
        }

        public UIGridContainer SetRowsAndColumns(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;

            return this;
        }

        public UIGridContainer SetInsetSpacing(float insetSpacing)
        {
            _insetSpacing = insetSpacing;

            return this;
        }

        public UIGridContainer SetSpacingBetweenItem(float spacingBetweenItem)
        {
            _spacingBetweenItem = spacingBetweenItem;

            return this;
        }

        public void Calculate()
        {
            Vector2 startPosition = new Vector2(
                    -_parentWidth / 2 + ChildSize.x / 2 + _insetSpacing,
                    _parentHeight / 2 - ChildSize.y / 2 - _insetSpacing
                    );

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _columns; j++)
                {
                    var item = _transform.GetChild(i * _rows + j);
                    var itemTransform = item.GetComponent<RectTransform>();

                    Vector2 positon = startPosition +
                        (new Vector2(j, -i) * (ChildSize + _spacingBetweenItem * Vector2.one));

                    itemTransform.sizeDelta = ChildSize;
                    itemTransform.anchoredPosition = positon;
                }
            }
        }

        public Vector2Int GetChildIndex(Vector2 position)
        {
            var size = ChildSize + _spacingBetweenItem * Vector2.one;

            position += new Vector2(_parentWidth, _parentHeight) / 2 - size / 2 - _insetSpacing * Vector2.one;

            Vector2Int index = new Vector2Int(
                Mathf.RoundToInt(position.x / size.x),
                Mathf.RoundToInt(position.y / size.y));

            if (index.x < _columns || index.x >= _columns || index.y < 0 || index.y >= _rows)
                return Vector2Int.one * -1;

            return index;
        }
    }
}
