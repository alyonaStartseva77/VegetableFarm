using VegetableFarm.Enums;

namespace VegetableFarm.Classes
{
    class Cell
    {
        private const int PROGRESS_PLANTED = 20;
        private const int PROGRESS_GREEN = 100;
        private const int PROGRESS_IMMATURE = 120;
        private const int PROGRESS_MATURE = 140;

        public CellState state = CellState.Empty;
        public int progress = 0;

        public void StartGrow()
        {
            state = CellState.Planted;
            progress = 1;
            FarmEngine.cash -= FarmEngine.SPEND_CASH_PLANTED;
        }

        public void Cut()
        {
            FarmEngine.UpdateCash(this);
            state = CellState.Empty; 
            progress = 0;
        }

        public void NextStep()
        {
            if ((state != CellState.Empty) && (state != CellState.Overgrow))
            {
                progress++;
                if (progress < PROGRESS_PLANTED) state = CellState.Planted;
                else if (progress < PROGRESS_GREEN) state = CellState.Green;
                else if (progress < PROGRESS_IMMATURE) state = CellState.Immature;
                else if (progress < PROGRESS_MATURE) state = CellState.Mature;
                else state = CellState.Overgrow;
            }
        }
    }
}
