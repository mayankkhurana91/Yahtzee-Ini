#region Statements
using System.Windows.Controls;
using Image = System.Windows.Controls.Image;
#endregion

namespace Yahtzee.Models
{
    /// <summary>
    /// Definition of Game Manager
    /// </summary>

    public class GameManager
    {
        #region Declaration
        private bool _isValidCategory;

        public  bool _isScoreBoardSelected;
        public Player player;
        public ScoreBoard scoreBoard;
        #endregion

        #region Initializaion
        public GameManager()
        {
            _isValidCategory = false;
            _isScoreBoardSelected = false;
            DiceTopPattern = new Image[] { new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image() }; // 6 Patterns for Dice Sides + 1 Blank Pattern
            DiceTopNumberCount = new int[6] { 0, 0, 0, 0, 0, 0 };
            player = new Player();
            scoreBoard = new ScoreBoard();
        }
        #endregion
     
        #region Properties
        /// <summary>
        /// Dice Sides Patterns  
        /// </summary>
        public Image[] DiceTopPattern 
        {
            get;
            set;
        }

        /// <summary>
        /// Frequency of Same Top Numbers seen when multiple dices are rolled together
        /// </summary>
        public int[] DiceTopNumberCount
        {
            get;
            set;
        }

        /// <summary>
        /// Sum of Same Top Numbers seen when multiple dices are rolled together
        /// </summary>
        public int[] DiceSameTopNumberSum
        {
            get;
            set;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Taking a count of values seen on the top of multiple dices (after they are rolled together)
        /// e.g. 1 is observed on a dice, increase the count of DiceTopNumberCount first element
        /// </summary>
        public void CalculateDiceTopNumberCount()
        {
            foreach (Dice d in player.Dices)

                switch (d.TopNumber)
                {
                    case 1: 
                        DiceTopNumberCount[0]++;
                        break;
                    case 2: 
                        DiceTopNumberCount[1]++;
                        break;
                    case 3:
                        DiceTopNumberCount[2]++;
                        break;
                    case 4:
                        DiceTopNumberCount[3]++;
                        break;
                    case 5:
                        DiceTopNumberCount[4]++;
                        break;
                    case 6:
                        DiceTopNumberCount[5]++;
                        break;
                }
        }

        /// <summary>
        /// Check if Valid Upper Categories : Ones, Twos, Threes, Fours, Fives, Sixes
        /// </summary>

        public bool CheckIfValidUpperCategory(int category)
        {
            if (DiceTopNumberCount[category] != 0)
            {
                _isValidCategory = true;
            }
            return _isValidCategory;
           
        }

        /// <summary>
        /// Calculate sum of scores of same scores in the upper categories :  Ones, Twos, Threes, Fours, Fives, Sixes
        /// </summary>
        public int EvaluateDiceSumUpperCategory(int category) 
        {
            foreach (Dice d in player.Dices)
            {
                if (d.TopNumber == category)
                {
                    player.Score = player.Score + d.TopNumber;
                }
            }
            return player.Score;
        }

        /// <summary>
        /// Check if Valid Lower Categories : ThreeOfAKind, FourOfAKind, FiveOfAKind
        /// </summary>
        public bool CheckIfValidLowerCategory(int category)
        {
            for (int i = 0; i < DiceTopNumberCount.Length; i++)
            {
                if (DiceTopNumberCount[i] == category)
                {
                    _isValidCategory = true;
                }
            }
            return _isValidCategory;
        }

        /// <summary>
        /// Calculate sum of scores of same scores in the lower categories :  ThreeOfAKind, FourOfAKind, FiveOfAKind
        /// </summary>
       
        public int EvaluateDiceSumLowerCategory(int category) 
        {
            for(int i = 0; i < DiceTopNumberCount.Length; i++)
            {
                if (DiceTopNumberCount[i] == category)
                {
                    int pos = i;
                    player.Score = player.Score + category * DiceTopNumberCount[pos-1];
                    break;
                }
            }
            return player.Score;
        } 

        /// <summary>
        /// Check if valid Small Straight Category
        /// </summary>
        public bool CheckIfValidSmallStraight()
        {

            if (DiceTopNumberCount[0] >= 1 && DiceTopNumberCount[1] >= 1 && DiceTopNumberCount[2] >= 1 && DiceTopNumberCount[3] >= 1
               ||
               DiceTopNumberCount[1] >= 1 && DiceTopNumberCount[2] >= 1 && DiceTopNumberCount[3] >= 1 && DiceTopNumberCount[4] >= 1
               ||
               DiceTopNumberCount[2] >= 1 && DiceTopNumberCount[3] >= 1 && DiceTopNumberCount[4] >= 1 && DiceTopNumberCount[5] >= 1)
            {
                _isValidCategory = true;
            }
            return _isValidCategory;
        }

        /// <summary>
        /// Check if valid Large Straight Category
        /// </summary>
        public bool CheckIfValidLargeStraight()
        {
            if (DiceTopNumberCount[0] == 1 && DiceTopNumberCount[1] == 1 && DiceTopNumberCount[2] == 1 && DiceTopNumberCount[3] == 1 &&
                DiceTopNumberCount[4] == 1
                ||
                DiceTopNumberCount[1] == 1 && DiceTopNumberCount[2] == 1 && DiceTopNumberCount[3] == 1 && DiceTopNumberCount[4] == 1 &&
                DiceTopNumberCount[5] == 1)
            {
                _isValidCategory = true;
            }
            return _isValidCategory;
        }

        /// <summary>
        /// Check if valid Full House Category
        /// </summary>
        public bool CheckIfValidFullHouse()
        {
            for (int i = 0; i < DiceTopNumberCount.Length; i++)    //DiceResults = new int[6] { 0, 0, 0, 0, 0, 0 }; // 6 sides
            {
                if (DiceTopNumberCount[i] == 3)
                {
                    for (int j = 0; j < DiceTopNumberCount.Length; j++)
                    {
                        if (DiceTopNumberCount[j] == 2)
                        {
                            _isValidCategory = true;       // 3, 3 ,3, 2, 2
                        }
                    }
                }
            }
            return _isValidCategory;
        }

        public void EnableOrDisableButton(Button buttonName, bool value)
        {
            //button.Content = "Entry Completeted";
            buttonName.IsEnabled = value;
        }
        
        /// <summary>
        /// Reset Dice Counters 
        /// </summary>
        public void ResetGameCounters()
        {
            for (int i = 0; i < DiceTopNumberCount.Length; i++)
                DiceTopNumberCount[i] = 0;

            _isValidCategory = false;
        }
    }
}

        #endregion























































































































































































































































