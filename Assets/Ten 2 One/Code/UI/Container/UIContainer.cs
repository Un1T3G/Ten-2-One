using UnityEngine;

namespace Un1T3G.Ten2One
{
    [RequireComponent(typeof(RectTransform))]
    public class UIContainer : MonoBehaviour
    {
        [SerializeField] private float _innerSpacing;

        private RectTransform _transform;

        private float _parentWidth => _transform.rect.width;

        private void Start()
        {
            _transform = GetComponent<RectTransform>();
        }

        private float SumOfAllChildWidth()
        {
            float sum = 0;

            for (int i = 0; i < _transform.childCount; i++)
                sum += _transform.GetChild(i).GetComponent<RectTransform>().rect.width;

            return sum;
        }

        public void Calculate()
        {
            int childCount = _transform.childCount;

            float sumOfAllChildWidth = SumOfAllChildWidth();
            float spacingBetweenCell = (_parentWidth - sumOfAllChildWidth - 2 * _innerSpacing) / (childCount - 1);

            var lastChildWidth = -_parentWidth;
            var lastChildPosition = new Vector2(_innerSpacing, 0);

            for (int i = 0; i < childCount; i++)
            {
                var child = _transform.GetChild(i);
                var childRect = child.GetComponent<RectTransform>();

                childRect.anchoredPosition = lastChildPosition + new Vector2(1, 0) *
                    ((lastChildWidth + childRect.rect.width) / 2);

                lastChildWidth = childRect.rect.width;
                lastChildPosition = childRect.anchoredPosition + new Vector2(spacingBetweenCell, 0);
            }
        }
    }
}
