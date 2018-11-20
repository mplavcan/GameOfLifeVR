// 

namespace GameOfLife
{
    public enum CellState
    {
        Dead,
        Alive
    }

    public static class Rules
    {
        public static CellState NextState(CellState currentState, int numNeighbors)
        {
            return CellState.Dead;
        }
    }
}
