using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Board _board;
        [SerializeField] private BlockPlacer _blockPlacer;
        [SerializeField] private BlockSizeFitter _blockSizeFitter;
        [SerializeField] private BlockIntreactableController _blockIntreactableController;
        [SerializeField] private UIGridContainer _boardUIGridContainer;
        [SerializeField] private BlockFactory _blockFactory;
        [SerializeField] private BlockDataProvider _blockDataProvider;
        [SerializeField] private BlockSpawner _blockSpawner;

        private void Start()
        {
            _board.Build(8, 8);
            _blockSizeFitter.Init(_board);
            _blockFactory.Init(_board, _board.transform, _canvas.scaleFactor);
            _blockIntreactableController.Init(_blockPlacer, _blockSizeFitter);
            _blockSpawner.Init(_blockFactory, _blockDataProvider);
        }
    }
}
