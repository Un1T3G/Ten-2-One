using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BoardTilesPositioner : MonoBehaviour
    {
        [SerializeField] private Board _board;
        [SerializeField] private UIGridContainer _uiGridContainer;

        private void OnEnable()
        {
           // _board.OnBuild += OnBoardBuild;
        }

        private void Awake()
        {
            _uiGridContainer.Init();
        }

        private void OnBoardBuild()
        {
            _uiGridContainer.SetRowsAndColumns(_board.Rows, _board.Columns).Calculate();
        }

        private void OnDisable()
        {
            //_board.OnBuild -= OnBoardBuild;
        }
    }
}