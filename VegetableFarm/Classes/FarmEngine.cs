using VegetableFarm.Enums;

namespace VegetableFarm.Classes
{
    static class FarmEngine
    {
        public const int SPEND_CASH_PLANTED = 2;
        public const int SPEND_CASH_OVERGROW = 1;
        public const int EARN_CASH_IMMATURE = 3;
        public const int EARN_CASH_MATURE = 5;

        public static int day = 0;
        public static int cash = 100;

        public static void UpdateCash(Cell cell)
        {
            switch (cell.state)
            {
                case CellState.Immature:
                    cash += EARN_CASH_IMMATURE;
                    break;
                case CellState.Mature:
                    cash += EARN_CASH_MATURE;
                    break;
                case CellState.Overgrow:
                    cash -= SPEND_CASH_OVERGROW;
                    break;
            }
        }
    }
}
