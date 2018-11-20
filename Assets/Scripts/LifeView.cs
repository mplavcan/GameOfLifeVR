// 

using System.Collections;
using UnityEngine;
using UnityEngine.XR;

namespace GameOfLife
{
    public class LifeView : MonoBehaviour
    {
        [SerializeField] private GameObject cellPrefab;

        private bool running = true;
        private const float TimeStep = .5f;
        private const float CellSpacing = 1.05f;
        private GameGrid grid = new GameGrid();

        private void Start()
        {
            InputTracking.Recenter();
            StartCoroutine(LifeAnimator());
        }

        private void Update()
        {
            running = !Input.anyKeyDown;
        }

        private IEnumerator LifeAnimator()
        {
            while (running)
            {
                yield return new WaitForSeconds(TimeStep);
                RenderGrid(grid);
                grid = grid.CellCount() == 0 ? Rpentomino() : grid.NextGrid();
            }
        }

        private void RenderGrid(GameGrid grid)
        {
            foreach (var cell in grid.LivingCells())
                Instantiate(cellPrefab, new Vector3(cell.x * CellSpacing, 0, cell.y * CellSpacing), Quaternion.identity,
                    transform);
        }

        private static GameGrid Rpentomino()
        {
            return new GameGrid(
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(0, -1),
                new Vector2(0, 1),
                new Vector2(-1, 1));
        }
    }
}