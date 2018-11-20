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
            if(numNeighbors == 2)
                return CellState.Alive;
            return CellState.Dead;
        }
    }
}
