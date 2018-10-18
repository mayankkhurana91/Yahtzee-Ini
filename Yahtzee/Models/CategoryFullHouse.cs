namespace Yahtzee.Models
{
    /// <summary>
    /// Defintion of Full House Category
    /// </summary>
    public class CategoryFullHouse : CategoryBase
    {
        #region Declaration
        public int CheckedDiceTopNumber;
        #endregion

        #region Initialization
        public CategoryFullHouse(string name, int checkedDiceTopNumber)
        {
            Name = name;
            CheckedDiceTopNumber = checkedDiceTopNumber;
        }
        #endregion

        #region Public Methods
        public override bool CheckIfValid(Dice[] dices)
        {
            for (int i = 0; i < DiceSupport.DiceTopNumber(dices).Length; i++)
            {
                if (DiceSupport.DiceTopNumber(dices)[i] == 3)
                {
                    for (int j = 0; j < DiceSupport.DiceTopNumber(dices).Length; j++)
                    {
                        if (DiceSupport.DiceTopNumber(dices)[j] == 2)
                        {
                            IsCategoryValid = true;
                        }
                    }
                }
            }
            return IsCategoryValid;
        }


        public override int Evaluate(Dice[] dices)
        {
            if (CheckIfValid(dices))
            {
                Score = 25;
                return Score;
            }
            return 0;
        }
        #endregion
    }

}
