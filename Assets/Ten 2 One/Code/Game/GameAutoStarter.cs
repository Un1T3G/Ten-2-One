using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class GameAutoStarter : MonoBehaviour
    {
        [SerializeField] private Game _game;

        private void Start()
        {
            _game.StartGame();
        }
    }
}
