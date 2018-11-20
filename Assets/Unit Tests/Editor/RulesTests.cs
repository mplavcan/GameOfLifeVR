// GameofLifeVR
// Matt Plavcan (@mplavcan)
// Public domain: Reuse and modification permitted without attribution
// 

using NUnit.Framework;

namespace GameOfLife
{
    public class RulesTests
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

        [Test]
        public void DeadCellWithTwoNeighborsStaysDead()
        {
            Assert.That(Rules.NextState(CellState.Dead, 2), Is.EqualTo(CellState.Dead));
        }

        [Test]
        public void DeadCellWithThreeNeighborsBirths()
        {
            Assert.That(Rules.NextState(CellState.Dead, 3), Is.EqualTo(CellState.Alive));
        }

        [Test]
        public void LivingCellWithFiveNeighborsDies()
        {
            Assert.That(Rules.NextState(CellState.Alive, 5), Is.EqualTo(CellState.Dead));
        }
    }
}
