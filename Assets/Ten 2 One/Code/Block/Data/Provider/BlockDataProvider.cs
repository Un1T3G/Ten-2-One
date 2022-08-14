using UnityEngine;

namespace Un1T3G.Ten2One
{
    public class BlockDataProvider : MonoBehaviour, IBlockDataProvider
    {
        private readonly BlockModel[] _data =
        {
            new BlockModel(new bool[1, 1] {{true}}),
            new BlockModel(new bool[2, 2] {{true, true}, {true, true}}),
            new BlockModel(new bool[2, 2] {{false, true}, {true, true}}),
            new BlockModel(new bool[2, 1] {{true}, {true}}),
            new BlockModel(new bool[1, 2] {{true, true}}),
            new BlockModel(new bool[3, 3] {{true, true, true }, {true, true, true }, {true, true, true } }),
        };

        public BlockModel[] GetData()
        {
            return _data;
        }
    }
}
