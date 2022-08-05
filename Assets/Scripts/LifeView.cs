// GameofLifeVR
// Matt Plavcan (@mplavcan)
// Public domain: Reuse and modification permitted without attribution
//  

using System.Collections;
using UnityEngine;

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
                RenderGrid();
                grid = grid.CellCount() == 0 ? RPentomino() : grid.NextGrid();
            }
        }

        private void RenderGrid()
        {
            foreach (var cell in grid.LivingCells())
                Instantiate(cellPrefab, new Vector3(cell.x * CellSpacing, 0, cell.y * CellSpacing), Quaternion.identity,
                    transform);
        }

        private static GameGrid RPentomino()
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