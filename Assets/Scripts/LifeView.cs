// 

﻿using System.Collections;
using GameOfLife;
using UnityEngine;
using UnityEngine.XR;

public class LifeView : MonoBehaviour
{
    private bool running = true;
    private const float TimeStep = .5f;
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

    private void RenderGrid(GameGrid gameGrid)
    {
    }    
}
