// 

using GameOfLife;
using NUnit.Framework;
using UnityEngine;

public class GridTests
{
    [Test]
    public void GridBeginsEmpty()
    {
        Assert.That(new GameGrid().CellCount(), Is.EqualTo(0));
    }

    [Test]
    public void GridCanAddLivingCells()
    {
        var grid = new GameGrid();
        grid.AddLivingCell(Vector2.zero);
        Assert.That(grid.CellCount(), Is.EqualTo(1));
    }
}