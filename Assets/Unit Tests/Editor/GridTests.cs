// 

using GameOfLife;
using NUnit.Framework;

public class GridTests
{
    [Test]
    public void GridBeginsEmpty()
    {
        Assert.That(new GameGrid().CellCount(), Is.EqualTo(0));
    }
}