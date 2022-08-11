using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BlockSpawner : MonoBehaviour
    {
        private BlockFactory _blockFactory;
        private IDataProvider<BlockModel[]> _blockDataProvider;

        public void Init(BlockFactory blockFactory, IDataProvider<BlockModel[]> blockDataProvider)
        {
            _blockFactory = blockFactory;
            _blockDataProvider = blockDataProvider;

            for (int i = 0; i < 3; i++)
                Build();
        }

        private void Build()
        {
            var data = _blockDataProvider.GetData();
            BlockModel model = data[Random.Range(0, data.Length)];
            _blockFactory.Build(model, transform);
        }
    }
}