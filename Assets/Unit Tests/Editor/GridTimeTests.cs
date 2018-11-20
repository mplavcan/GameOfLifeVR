// GameofLifeVR
// Matt Plavcan (@mplavcan)
// Public domain: Reuse and modification permitted without attribution
// 

using System.Collections.Generic;
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
    
    [Test]
    public void GridCanListNeighborLocations()
    {
        Assert.That(GameGrid.AdjacentTo(Vector2.one), Is.EquivalentTo(new List<Vector2>() {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(2, 0),
            new Vector2(0, 1),
            new Vector2(2, 1),
            new Vector2(0, 2),
            new Vector2(1, 2),
            new Vector2(2, 2),
        }));
    }

    [Test]
    public void GridConsidersLargerSurroundingCellBoundary()
    {
        var grid = new GameGrid(
            new Vector2(1, 1),
            new Vector2(-1, -1),
            new Vector2(-1, 1),
            new Vector2(1, -1));
        Assert.That(grid.PotentialLivingCells().Count, Is.EqualTo(25));
    }

    [Test]
    public void NewGridAddsBirthingCells()
    {
        var grid = new GameGrid(
            new Vector2(1, 1),
            new Vector2(1, 2),
            new Vector2(2, 1));
        Assert.That(grid.NextGrid().CellStateAt(new Vector2(2, 2)), Is.EqualTo(CellState.Alive));
    }
}
