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
            switch (numNeighbors)
            {
                case 2: return currentState;
                case 3: return CellState.Alive;
                default: return CellState.Dead;
            }
        }
    }
}
