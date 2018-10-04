#region Statements
#endregion

namespace Yahtzee.Models
{
    /// <summary>
    /// Definition of ScoreBoard
    /// </summary>

    public class ScoreBoard
    {
        #region Initialization
        public ScoreBoard()
        {
            ScoreCategory = new int[] {0, 1, 2, 3, 4, 5, 6};
        }
        #endregion

        #region Properties
        /// <summary>
        /// Score Categories according to which the player score is calculated, after each roll 
        /// 0 - Ones, 1- Twos, 2- Threes, 3- Fours/ ThreeOfAKind, 4- Fives/ FourOfAKind, 5- Sixes/ FiveOfAKind
        /// </summary>
        public int[] ScoreCategory
        {
            get;
            set;
        }
        #endregion
    }
}

