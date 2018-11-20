// 

using GameOfLife;
using NUnit.Framework;

public class GameTests
{
    [Test]
    public void DeadCellWithNoNeighborsStaysDead()
    {
        Assert.That(Rules.NextState(CellState.Dead, 0), Is.EqualTo(CellState.Dead));
    }

    [Test]
    public void LivingCellWithTwoNeighborsStaysAlive()
    {
        Assert.That(Rules.NextState(CellState.Alive, 2), Is.EqualTo(CellState.Alive));
    }
}
