using UnityEngine;
using System;

namespace Un1T3G.Ten2One
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private BoardTileMatcher _boardTileMatcher;

        private int _point;

        public int Point
        {
            get => _point;
            private set
            {
                _point = value;
                OnPointChanged?.Invoke(_point);
            }
        }

        public event Action<int> OnPointChanged;

        private void OnEnable()
        {
            _boardTileMatcher.OnMatching += OnMatching;
        }

        private void OnDisable()
        {
            _boardTileMatcher.OnMatching -= OnMatching;
        }

        private void Start()
        {
            Point = 0;
        }

        private void OnMatching(IBlockTile tile)
        {
            Point += tile.Value;
        }

        public void Reset()
        {
            Point = 0;            
        }
    }
}
