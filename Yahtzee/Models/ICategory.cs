namespace Yahtzee.Models
{
    /// <summary>
    /// Definition of Interface for different categories
    /// </summary>
    public interface ICategory
    {
        #region Properties
        string Name
        {
            get;
            set;
        }

        int Score
        {
            get;
            set;
        }
        #endregion

        #region
        /// <summary>
        /// Check if a Category is a Valid Category
        /// </summary>
        /// <param name="dices"></param>
        /// <returns></returns>
        bool CheckIfValid(Dice[] dices);

        /// <summary>
        /// Evaluate a particlar category to check the score
        /// </summary>
        /// <param name="dices"></param>
        /// <returns></returns>
        int Evaluate(Dice[] dices);
        #endregion
    }
}
