using System.Collections.Generic;

namespace Un1T3G.Ten2One
{
    public class BlockModel
    {
        private List<List<bool>> _map;

        public int Rows => _map.Count;
        public int Columns => _map[0].Count;

        public bool[,] Map
        {
            get
            {
                bool[,] map = new bool[Rows, Columns];

                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < Columns; j++)
                        map[i, j] = _map[i][j];

                return map;
            }
        }

        public BlockModel(bool[,] map)
        {
            _map = new List<List<bool>>();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                _map.Add(new List<bool>());

                for (int j = 0; j < map.GetLength(1); j++)
                {
                    _map[i].Add(map[i, j]);
                }
            }
        }
    }
}
