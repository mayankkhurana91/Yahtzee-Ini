namespace Yahtzee.Models
{
    /// <summary>
    /// Base Class for All Categories in the Game
    /// </summary>
    public abstract class CategoryBase : ICategory
    {
        #region Initialization
        public CategoryBase()
        {
            IsCategoryValid = false;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Name of the Category
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Score of an individual category
        /// </summary>
        public int Score
        {
            get;
            set;
        }

        /// <summary>
        /// Category Valid 
        /// </summary>
        public bool IsCategoryValid
        {
            get;
            set;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Checking if a category is a valid category
        /// </summary>
        /// <param name="dices"></param>
        /// <returns></returns>
        public abstract bool CheckIfValid(Dice[] dices);

        /// <summary>
        /// Evaluate a Category for Score
        /// </summary>
        /// <param name="dices"></param>
        /// <returns></returns>
        public abstract int Evaluate(Dice[] dices);
        #endregion
    }
}
