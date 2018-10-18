#region
namespace Yahtzee.Models
#endregion
{
    public static class DiceSupport
    {
        #region Public Methods
        /// <summary>
        /// Comparing Dice Top Number Count
        /// </summary>
        /// <param name="dices"></param>
        /// <param name="desiredNumber"></param>
        /// <returns></returns>
        public static int CalculateDiceTopNumberCount(Dice[] dices, int desiredNumber)
        {
            int[] diceTopNumberCount = DiceTopNumber(dices);
            return diceTopNumberCount[desiredNumber - 1];
        }

        public static int[] DiceTopNumber(Dice[] dices)
        {
            int[] diceTopNumberCount = new int[6] { 0, 0, 0, 0, 0, 0 };
            foreach (Dice d in dices)
            {
                switch (d.TopNumber)
                {
                    case 1:
                        diceTopNumberCount[0]++;
                        break;
                    case 2:
                        diceTopNumberCount[1]++;
                        break;
                    case 3:
                        diceTopNumberCount[2]++;
                        break;
                    case 4:
                        diceTopNumberCount[3]++;
                        break;
                    case 5:
                        diceTopNumberCount[4]++;
                        break;
                    case 6:
                        diceTopNumberCount[5]++;
                        break;
                }
            }
            return diceTopNumberCount;
        }
        #endregion
    }
}
