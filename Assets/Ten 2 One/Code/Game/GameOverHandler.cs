using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class GameOverHandler : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Game _game;
        [SerializeField] private BlockIntreactableController _blockIntreactableController;

        private void Start()
        {
            _gameOverPanel.SetActive(false);
        }

        private void OnEnable()
        {
            _game.OnRestartGame += OnRestartGame;
            _blockIntreactableController.OnBlocksNotFit += GameOver;
        }

        private void OnDisable()
        {
            _game.OnRestartGame -= OnRestartGame;
            _blockIntreactableController.OnBlocksNotFit -= GameOver;
        }

        private void OnRestartGame()
        {
            _gameOverPanel.SetActive(false);
        }

        private void GameOver()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}
