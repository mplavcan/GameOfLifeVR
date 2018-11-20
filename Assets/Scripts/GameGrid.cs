// 

using UnityEngine;

namespace GameOfLife
{
    public class GameGrid
    {
        private int numCells = 0;

        public GameGrid()
        {
        }

        public int CellCount()
        {
            return numCells;
        }

        public void AddLivingCell(Vector2 location)
        {
            numCells++;
        }

        public CellState CellStateAt(Vector2 location)
        {
            return CellState.Dead;
        }
    }
}