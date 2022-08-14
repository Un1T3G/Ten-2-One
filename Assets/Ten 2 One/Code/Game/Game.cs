using UnityEngine;
using System;

namespace Un1T3G.Ten2One
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private int _rows;
        [SerializeField] private int _columns;
        [SerializeField] private Board _board;
        [SerializeField] private BlockSpawner _blockSpawner;
        [SerializeField] private Score _score;

        public event Action OnStartGame;
        public event Action OnRestartGame;

        private void DestroySelectedTiles()
        {
            for (int i = 0; i < _board.Rows; i++)
            {
                for (int j = 0; j < _board.Columns; j++)
                {
                    var tile = _board.GetTile(new Vector2Int(j, i));
                    tile.Reset();
                }
            }
        }

        public void StartGame()
        {
            _board.Build(_rows, _columns);

            OnStartGame?.Invoke();
        }

        public void RestartGame()
        {
            DestroySelectedTiles();

            _blockSpawner.DestroySpawnedBlocks();
            _blockSpawner.BuildStartBlocks();

            _score.Reset();

            OnRestartGame?.Invoke();
        }
    }
}