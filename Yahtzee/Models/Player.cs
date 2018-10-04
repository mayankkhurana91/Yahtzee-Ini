#region Statements
namespace Yahtzee.Models
#endregion
{
    /// <summary>
    /// Definition of a Player
    /// </summary>
    public class Player
    {

        #region Initializaion
        public Player()
        {
            Dices = new Dice[] { new Dice(), new Dice(), new Dice(), new Dice(), new Dice() };
            Score = 0;
            Chances = 0;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Player Name
        /// </summary>
        public string PlayerName
        {
            get;
            set;
        }

        /// <summary>
        /// Player Score
        /// </summary>
        public int Score
        {
            get;
            set;
        }

        /// <summary>
        ///  Dices with a player : 5 in no.
        /// </summary>
        public Dice[] Dices
        {
            get;
            set;
        }

        /// <summary>
        ///  Chances with a player 
        /// </summary>
        public int Chances
        {
            get;
            set;
        }
        #endregion

        #region Public Methods
        /// <summary>
        ///  Rolling of Dices
        /// </summary>
        public void RollDices()
        {
            foreach (Dice d in Dices)
            {
                d.Roll();
            }
        }
        #endregion
    }
}

