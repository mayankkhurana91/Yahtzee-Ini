#region Statements
namespace Yahtzee.Models
#endregion
{
    /// <summary>
    /// Definition of a Player
    /// </summary>
    public class Player
    {
        #region Declaration
        private int _chance = 3;
        #endregion


        #region Initializaion
        public Player()
        {
            Score = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Player Score
        /// </summary>
        public int Score
        {
            get;
            set;
        }

        /// <summary>
        /// Chances to Roll : 3
        /// </summary>
        public int Chance
        {
            get => _chance;
            set => _chance = value;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Updating player's score
        /// </summary>
        /// <param name="toBeAddedScore"></param>
        public void AddToScore(int toBeAddedScore)
        {
            Score += toBeAddedScore;
        }
        #endregion
    }
}

