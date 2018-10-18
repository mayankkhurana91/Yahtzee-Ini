namespace Yahtzee.Models
{
    public class UpperSixCategory : CategoryBase
    {
        #region Declaration
        public int CheckedDiceTopNumber;
        #endregion

        #region Initialization
        public UpperSixCategory(string name, int checkedDiceTopNumber)
        {
            Name = name;
            CheckedDiceTopNumber = checkedDiceTopNumber;
        }
        #endregion

        #region Public Methods
        public override bool CheckIfValid(Dice[] dices)
        {
            if (DiceSupport.CalculateDiceTopNumberCount(dices, CheckedDiceTopNumber) != 0)
            {
                IsCategoryValid = true;
            }
            return IsCategoryValid;
        }

        public override int Evaluate(Dice[] dices)
        {
            if (CheckIfValid(dices))
            {
                //Sum up
                Score = SumUpScore(dices);
                return Score;
            }

            return 0;
        }
        #endregion

        #region Private Methods
        private int SumUpScore(Dice[] dices)
        {
            return DiceSupport.CalculateDiceTopNumberCount(dices, CheckedDiceTopNumber) * CheckedDiceTopNumber;
        }
        #endregion

    }
}
