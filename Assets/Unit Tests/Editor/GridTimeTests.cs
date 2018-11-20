//

using GameOfLife;
using NUnit.Framework;
using UnityEngine;

public class GridTimeTests
{
    [Test]
    public void GridCanGenerateNewGrid()
    {
        Assert.That(new GameGrid().NextGrid(), Is.AssignableTo(typeof(GameGrid)));
    }

    [Test]
    public void NewGridMaintainsStableCells()
    {
        var grid = new GameGrid(
            new Vector2(1, 1),
            new Vector2(1, 2),
            new Vector2(2, 1),
            new Vector2(2, 2));
        Assert.That(grid.NextGrid().CellCount(), Is.EqualTo(4));
    }


    [Test]
    public void NewGridRemovesDyingCells()
    {
        var grid = new GameGrid(
            new Vector2(1, 1),
            new Vector2(1, 2));
        Assert.That(grid.NextGrid().CellCount(), Is.EqualTo(0));
    }
}
