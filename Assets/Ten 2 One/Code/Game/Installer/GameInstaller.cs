using UnityEngine;
using DG.Tweening;

namespace Un1T3G.Ten2One
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Board _board;
        [SerializeField] private BlockPlacer _blockPlacer;
        [SerializeField] private BlockSizeFitter _blockSizeFitter;
        [SerializeField] private BoardTileMatcher _boardTileMatcher;
        [SerializeField] private BoardTileMatchFinder _boardTileMatchFinder;
        [SerializeField] private BlockIntreactableController _blockIntreactableController;
        [SerializeField] private BoardTileFinder _boardTileFinder;
        [SerializeField] private BoardTileSelector _boardTileSelector;
        [SerializeField] private UIGridContainer _boardUIGridContainer;
        [SerializeField] private BlockFactory _blockFactory;
        [SerializeField] private BlockDataProvider _blockDataProvider;
        [SerializeField] private BlockSpawner _blockSpawner;
        [SerializeField] private BlockTileValueIncreaser _blockTileValueIncreaser;

        private void Start()
        {
            DOTween.Init();
            _blockSizeFitter.Init(_board);
            _blockFactory.Init(_board, _board.transform, _canvas.scaleFactor);
            _boardTileFinder.Init(_board, _boardUIGridContainer);
            _boardTileSelector.Init(_board, _boardTileFinder);
            _blockPlacer.Init(_boardTileFinder, _boardTileMatchFinder);
            _boardTileMatchFinder.Init(_board);
            _boardTileMatcher.Init(_blockPlacer, _boardTileMatchFinder);
            _blockIntreactableController.Init(_blockPlacer, _blockSizeFitter);
            _blockSpawner.Init(_blockFactory, _blockPlacer, _boardTileMatcher, _blockDataProvider);
            _blockTileValueIncreaser.Init(_board, _blockPlacer);
        }
    }
}
