using UnityEngine;
using TMPro;

namespace Un1T3G.Ten2One
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private Score _score;
        [SerializeField] private TextMeshProUGUI _text;

        private void OnEnable()
        {
            _score.OnPointChanged += OnPointChanged;
        }

        private void OnDisable()
        {
            _score.OnPointChanged -= OnPointChanged;
        }

        private void OnPointChanged(int point)
        {
            _text.text = $"<alpha=$AA>Score:<alpha=$FF>{point}";
        }
    }
}
