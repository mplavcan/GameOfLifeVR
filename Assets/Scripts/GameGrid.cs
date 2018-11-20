// 

using System.Collections.Generic;
using UnityEngine;

namespace GameOfLife
{
    public class GameGrid
    {
        private readonly HashSet<Vector2> livingCells = new HashSet<Vector2>();

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

        public int NeighborCount(Vector2 center)
        {
            throw new System.NotImplementedException();
        }
    }
}