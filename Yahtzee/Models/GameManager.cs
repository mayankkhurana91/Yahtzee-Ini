#region Statements
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
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
        public Player player;
        public bool AreDicesRolled;
        #endregion

        #region Initialization
        public GameManager()
        {
            player = new Player();
            DiceTopPattern = new Image[] { new Image(), new Image(), new Image(), new Image(), new Image(), new Image(), new Image() }; // 6 Patterns for Dice Sides + 1 Blank Pattern
            Dices = new Dice[] { new Dice(), new Dice(), new Dice(), new Dice(), new Dice() };
            AreDicesRolled = false;

            Categories = new List<ICategory>();
            Categories.Add(new UpperSixCategory("CategoryAces", 1));
            Categories.Add(new UpperSixCategory("CategoryTwos", 2));
            Categories.Add(new UpperSixCategory("CategoryThrees", 3));
            Categories.Add(new UpperSixCategory("CategoryFours", 4));
            Categories.Add(new UpperSixCategory("CategoryFives", 5));
            Categories.Add(new UpperSixCategory("CategorySixes", 6));
            Categories.Add(new LowerThreeCategory("CategoryThreeOfAKind", 3));
            Categories.Add(new LowerThreeCategory("CategoryFourOfAKind", 4));
            Categories.Add(new LowerThreeCategory("CategoryFiveOfAKind", 5));
            Categories.Add(new CategorySmallStraight("CategorySmallStraight", 10));
            Categories.Add(new CategoryLargeStraight("CategoryLargeStraight", 11));
            Categories.Add(new CategoryFullHouse("CategoryFullHouse", 12));
        }
        #endregion

        #region Properties
        /// <summary>
        ///  Dices with a player : 5 in no.
        /// </summary>
        public Dice[] Dices
        {
            get;
            set;
        }

        /// <summary>
        /// Dice Sides Patterns  
        /// </summary>
        public Image[] DiceTopPattern
        {
            get;
            set;
        }

        /// <summary>
        /// Scoring Categories 
        /// </summary>
        public List<ICategory> Categories
        {
            get;
            set;
        }

        #endregion
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

        /// <summary>
        /// Disabling Category Button in View
        /// </summary>
        /// <param name="buttonName"></param>
        /// <param name="value"></param>
        public void DisableCategoryButton(Button buttonName)
        {
            buttonName.IsEnabled = false;
        }

        /// <summary>
        /// Checking the state of Hold Button & Dice Hold State
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="button"></param>
        public void CheckHoldButtonState(Dice dice, Button button, string buttonContent)
        {
            if (dice.Hold == false)
            {
                dice.Hold = true;
                button.Background = new SolidColorBrush(Colors.Yellow);
                button.Content = "On Hold";
            }
            else
            {
                dice.Hold = false;
                button.Background = new SolidColorBrush(Colors.LightCoral);
                button.Content = buttonContent;
            }

        }

        public void ResetHoldButtonsState(Button[] holdButtonGroup)
        {
            foreach (Button button in holdButtonGroup)
            {
                button.Background = new SolidColorBrush(Colors.LightCoral);

                if (button == holdButtonGroup[0])
                {
                    button.Content = "Hold D1";
                }
                else if (button == holdButtonGroup[1])
                {
                    button.Content = "Hold D2";
                }
                else if (button == holdButtonGroup[2])
                {
                    button.Content = "Hold D3";
                }
                else if (button == holdButtonGroup[3])
                {
                    button.Content = "Hold D4";
                }
                else
                {
                    button.Content = "Hold D5";
                }

                foreach (Dice d in Dices)
                {
                    d.Hold = false;
                }
            }
        }

        /// <summary>
        /// Resetting the game
        /// </summary>
        public void ResetGame(Button[] categoryButtonGroup, Button[] holdButtonGroup, Button rollDicesButton)
        {
            foreach (Button b in categoryButtonGroup)
            {
                if (b.IsEnabled == false)
                {
                    b.IsEnabled = true;
                }
            }

            if (rollDicesButton.IsEnabled == false)
            {
                rollDicesButton.IsEnabled = true;
            }

            player.Score = 0;
            player.Chance = 3;
            player.Rounds = 1;
            AreDicesRolled = false;
            ResetHoldButtonsState(holdButtonGroup);
        }
    }
}
