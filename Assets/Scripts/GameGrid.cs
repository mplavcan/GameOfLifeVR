// 

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameOfLife
{
    public class GameGrid
    {
        private readonly HashSet<Vector2> livingCells = new HashSet<Vector2>();

        public GameGrid(params Vector2[] liveCells)
        {
            foreach (var l in liveCells)
            {
                AddLivingCell(l);
            }
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
            var neighborThreshold = Mathf.Sqrt(2) + Mathf.Epsilon;
            return livingCells.Count(candidate =>
                (candidate - center).magnitude <= neighborThreshold &&
                candidate != center
            );
        }

        public GameGrid NextGrid()
        {
            throw new System.NotImplementedException();
        }
    }
}