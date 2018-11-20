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
    public void GridCanAddALivingCell()
    {
        var grid = new GameGrid();
        grid.AddLivingCell(Vector2.zero);
        Assert.That(grid.CellCount(), Is.EqualTo(1));
    }

    [Test]
    public void GridCanQueryCellState()
    {
        var grid = new GameGrid();
        Assert.That(grid.CellStateAt(Vector2.zero), Is.EqualTo(CellState.Dead));
    }

    [Test]
    public void GridCellStateQueryCanFindLiveCells()
    {
        var grid = new GameGrid();
        grid.AddLivingCell(Vector2.one);
        Assert.That(grid.CellStateAt(Vector2.one), Is.EqualTo(CellState.Alive));
    }

    [Test]
    public void GridCellStateQueryIsDistinct()
    {
        var grid = new GameGrid();
        grid.AddLivingCell(Vector2.zero);
        Assert.That(grid.CellStateAt(Vector2.one), Is.EqualTo(CellState.Dead));
    }

    [Test]
    public void LivingCellCoordinatesAreUnique()
    {
        var grid = new GameGrid();
        grid.AddLivingCell(Vector2.one);
        grid.AddLivingCell(Vector2.one);
        Assert.That(grid.CellCount(), Is.EqualTo(1));
    }

    [Test]
    public void NeighborhoodQueryFindsAllNeighbors()
    {
        var grid = new GameGrid(
            new Vector2(2, 7),
            new Vector2(3, 6),
            new Vector2(4, 6),
            new Vector2(4, 7));
        Assert.That(grid.NeighborCount(new Vector2(3, 7)), Is.EqualTo(4));
    }

    [Test]
    public void NeighborhoodQueryDoesNotFindOwnCoordinate()
    {
        var grid = new GameGrid(
            new Vector2(3, 7),
            new Vector2(2, 7),
            new Vector2(3, 6),
            new Vector2(4, 6),
            new Vector2(4, 7));
        Assert.That(grid.NeighborCount(new Vector2(3, 7)), Is.EqualTo(4));
    }
}