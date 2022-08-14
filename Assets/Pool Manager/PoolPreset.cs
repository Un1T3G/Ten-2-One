using UnityEngine;

namespace Un1T3G.Pool
{
    public class PoolPreset : MonoBehaviour
    {
        [SerializeField] private int _amount;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _autoExpand;

        public int Amount => _amount;
        public GameObject Prefab => _prefab;
        public bool AutoExpand => _autoExpand;

        private void Awake()
        {
            PoolManager.AddPreset(this);
        }
    }
}
