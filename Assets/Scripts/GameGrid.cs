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
            return new GameGrid(
                this.livingCells.Where(cell =>
                Rules.NextState(CellStateAt(cell), NeighborCount(cell)) == CellState.Alive
            ).ToArray());
        }

        public static IEnumerable<Vector2> AdjacentTo(Vector2 center)
        {
            return new List<Vector2>
            {
                center + Vector2.up,
                center + Vector2.down,
                center + Vector2.right,
                center + Vector2.left,
                center + Vector2.up + Vector2.left,
                center + Vector2.up + Vector2.right,
                center + Vector2.down + Vector2.left,
                center + Vector2.down + Vector2.right,
            };
        }

        public HashSet<Vector2> PotentialLivingCells()
        {
            var candidates = new HashSet<Vector2>(livingCells);
            foreach (var cell in livingCells)
                foreach (var c in AdjacentTo(cell))
                    candidates.Add(c);
            return candidates;
        }
    }
}
