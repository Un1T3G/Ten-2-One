using UnityEngine;

namespace Un1T3G.Ten2One
{
    [RequireComponent(typeof(RectTransform))]
    public class TransformableBehaviour : MonoBehaviour, ITransformable
    {
        protected RectTransform _transform;

        public Transform Root => _transform;

        public Vector2 Position
        {
            get => _transform.anchoredPosition;
            set => _transform.anchoredPosition = value;
        }
        public Vector2 Size
        {
            get => new(_transform.rect.width, _transform.rect.height);
            set => _transform.sizeDelta = value;
        }
        public Vector2 Scale
        {
            get => _transform.localScale;
            set => _transform.localScale = value;
        }

        public void Init()
        {
            _transform = GetComponent<RectTransform>();
        }
    }
}
