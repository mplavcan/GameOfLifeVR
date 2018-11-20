//

using GameOfLife;
using NUnit.Framework;

public class GridTimeTests
{
    [Test]
    public void GridCanGenerateNewGrid()
    {
        Assert.That(new GameGrid().NextGrid(), Is.AssignableTo(typeof(GameGrid)));
    }
}
