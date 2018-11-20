// 

﻿using System.Collections;
using GameOfLife;
using UnityEngine;
using UnityEngine.XR;

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
            grid = grid.NextGrid();
            RenderGrid(grid);
        }
        Application.Quit();
    }

    private void RenderGrid(GameGrid grid)
    {
        foreach (var cell in grid.LivingCells())
            Instantiate(cellPrefab, new Vector3(cell.x * CellSpacing, 0, cell.y * CellSpacing), Quaternion.identity);
    }
}
