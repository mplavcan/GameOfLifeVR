// 

using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife
{
    public class GameGrid
    {
        private readonly List<Vector2> livingCells = new List<Vector2>();

        public GameGrid()
        {
        }

        public int CellCount()
        {
            return livingCells.Count;
        }

        public void AddLivingCell(Vector2 location)
        {
            livingCells.Add(location);
        }

        public CellState CellStateAt(Vector2 location)
        {
            return livingCells.Contains(location) ? CellState.Alive : CellState.Dead;
        }
    }
}