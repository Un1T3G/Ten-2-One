using UnityEngine;
using System;

namespace Un1T3G.Ten2One
{
    public class Board : TransformableBehaviour, IBoard
    {
        [SerializeField] private BoardTile _boardTilePrefab;
        
        private BoardTile[,] _tiles;

        public int Rows => _tiles.GetLength(0);
        public int Columns => _tiles.GetLength(1);

        public void Build(int rows, int columns)
        {
            if (_tiles != null)
                throw new InvalidOperationException();

            _tiles = new BoardTile[rows, columns];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < columns; j++)
                    _tiles[i, j] = Instantiate(_boardTilePrefab, transform);
        }

        public BoardTile GetTile(Vector2Int index)
        {
            if (IndexInBound(index) == false)
                throw new IndexOutOfRangeException();

            return _tiles[index.y, index.x];
        }

        public bool IndexInBound(Vector2Int index)
        {
            return index.y >= 0 && index.x >= 0 && index.y < Rows && index.x < Columns;
        }

        public void DestoryTiles()
        {
            if (_tiles == null)
                throw new InvalidOperationException();

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    Destroy(_tiles[i, j].gameObject);
        }
    }
}
