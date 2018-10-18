namespace Yahtzee.Models
{
    /// <summary>
    /// Defintion of Large Striaght Category
    /// </summary>
    public class CategoryLargeStraight : CategoryBase
    {
        #region Declaration
        public int CategoryIdentifier;
        #endregion

        #region Initialization
        public CategoryLargeStraight(string name, int categoryIdentifier)
        {
            Name = name;
            CategoryIdentifier = categoryIdentifier;
        }
        #endregion

        #region Public Methods
        public override bool CheckIfValid(Dice[] dices)
        {
            
                if (DiceSupport.DiceTopNumber(dices)[0] == 1 && DiceSupport.DiceTopNumber(dices)[1] == 1 && DiceSupport.DiceTopNumber(dices)[2] == 1 && DiceSupport.DiceTopNumber(dices)[3] == 1 &&
                    DiceSupport.DiceTopNumber(dices)[4] == 1
                    ||
                    DiceSupport.DiceTopNumber(dices)[1] == 1 && DiceSupport.DiceTopNumber(dices)[2] == 1 && DiceSupport.DiceTopNumber(dices)[3] == 1 && DiceSupport.DiceTopNumber(dices)[4] == 1 &&
                    DiceSupport.DiceTopNumber(dices)[5] == 1)
                
                {
                IsCategoryValid = true;
                }
            return IsCategoryValid;
        }

        public override int Evaluate(Dice[] dices)
        {
            if (CheckIfValid(dices))
            {
                Score = 40;
                return Score;
            }
            return 0;
        }
        #endregion
    }
}
