namespace Yahtzee.Models
{
    public class LowerThreeCategory : CategoryBase
    {
        #region Declaration
        public int CheckedDiceTopNumber;
        #endregion

        #region Initialization
        public LowerThreeCategory(string name, int categoryIdentifier)
        {
            Name = name;
            CheckedDiceTopNumber = categoryIdentifier;
        }
        #endregion

        #region Public Methods
        public override bool CheckIfValid(Dice[] dices)
        {
            for (int i = 0; i < DiceSupport.DiceTopNumber(dices).Length; i++)
            {
                if (DiceSupport.DiceTopNumber(dices)[i] >= CheckedDiceTopNumber)
                {
                    IsCategoryValid = true;
                    //Score = (i + 1) * CheckedDiceTopNumber;
                }
            }
            return IsCategoryValid;
        }


        public override int Evaluate(Dice[] dices)
        {
            if (CheckIfValid(dices))
            {
                Score = SumUpScore(dices);
                return Score;
            }
            return 0;
        }
        #endregion

        #region Private Methods
        private int SumUpScore(Dice[] dices)
        {
            foreach (Dice d in dices)
            {
                Score = Score + d.TopNumber;
            }
            return Score;
        }
        #endregion

    }
}
