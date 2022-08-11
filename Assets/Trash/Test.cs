using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private RectTransform _selfTransform;
    [SerializeField] private RectTransform _rootTransform;

    private void Start()
    {
        Debug.Log(RectTransformUtility.CalculateRelativeRectTransformBounds(_rootTransform));
        Debug.Log(RectTransformUtility.CalculateRelativeRectTransformBounds(_selfTransform));
        Debug.Log(RectTransformUtility.CalculateRelativeRectTransformBounds(_rootTransform, _selfTransform));
        Debug.Log(RectTransformUtility.CalculateRelativeRectTransformBounds(_selfTransform, _rootTransform));
        Debug.Log(_rootTransform.root);
    }
}
