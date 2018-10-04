#region Statements
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Yahtzee.Models;
#endregion

namespace Yahtzee.UserControls
{
    /// <summary>
    /// Interaction logic for DiceView.xaml
    /// </summary>
    public partial class DiceView : UserControl
    {
        #region Declaration
        private GameManager _game = new GameManager();
        #endregion

        #region Initializaion
        public DiceView()
        {
            InitializeComponent();
            InitialDicesView();
            lbl_results.Content = "Roll the Dice!";
            _game.player.Chances = 25;
        }
        #endregion

        #region Event Handlers
        private void OnRollButtonClick(object sender, RoutedEventArgs e)
        {
            _game.player.Chances--;

            if (_game.player.Chances >= 0)
            {
                if (_game._isScoreBoardSelected == true)
                {
                    _game.ResetGameCounters();
                }

                _game.player.RollDices();
                _game.CalculateDiceTopNumberCount();
                DicesViewAfterRoll();
                lbl_results.Content = "Current Score : " + _game.player.Score + " Chances left : " + _game.player.Chances;
            }
            else
            {
                lbl_results.Content = "Your total score is : " + _game.player.Score;
                MessageBox.Show("You have exhausted your 25 chances! Game Over");
                ResetGame();
            }
        }

        private void OnScoreBoardClick(object sender, RoutedEventArgs e)
        {
            _game._isScoreBoardSelected = true;
            //Button buttonClicked = (Button)sender;
            if (sender.Equals(Aces))
            {
                if (_game.CheckIfValidUpperCategory(_game.scoreBoard.ScoreCategory[0]))
                {
                    _game.EvaluateDiceSumUpperCategory(_game.scoreBoard.ScoreCategory[1]);
                    _game.EnableOrDisableButton(Aces, false);
                }
            }
            //
            else if (sender.Equals(Twos))
            {
                if (_game.CheckIfValidUpperCategory(_game.scoreBoard.ScoreCategory[1]))
                {
                    _game.EvaluateDiceSumUpperCategory(_game.scoreBoard.ScoreCategory[2]);
                    _game.EnableOrDisableButton(Twos, false);
                }
            }
            else if (sender.Equals(Threes))
            {
                if (_game.CheckIfValidUpperCategory(_game.scoreBoard.ScoreCategory[2]))
                {
                    _game.EvaluateDiceSumUpperCategory(_game.scoreBoard.ScoreCategory[3]);
                    _game.EnableOrDisableButton(Threes, false);
                }
            }
            else if (sender.Equals(Fours))
            {
                if (_game.CheckIfValidUpperCategory(_game.scoreBoard.ScoreCategory[3]))
                {
                    _game.EvaluateDiceSumUpperCategory(_game.scoreBoard.ScoreCategory[4]);
                    _game.EnableOrDisableButton(Fours, false);
                }
            }
            else if (sender.Equals(Fives))
            {
                if (_game.CheckIfValidUpperCategory(_game.scoreBoard.ScoreCategory[4]))
                {
                    _game.EvaluateDiceSumUpperCategory(_game.scoreBoard.ScoreCategory[5]);
                    _game.EnableOrDisableButton(Fives, false);

                }
            }
            else if (sender.Equals(Sixes))
            {
                if (_game.CheckIfValidUpperCategory(_game.scoreBoard.ScoreCategory[5]))
                {
                    _game.EvaluateDiceSumUpperCategory(_game.scoreBoard.ScoreCategory[6]);
                    _game.EnableOrDisableButton(Sixes, false);
                }
            }
            else if (sender.Equals(ThreeOfAKind))
            {
                if (_game.CheckIfValidLowerCategory(_game.scoreBoard.ScoreCategory[3]))
                {
                    _game.EvaluateDiceSumLowerCategory(_game.scoreBoard.ScoreCategory[3]);
                    _game.EnableOrDisableButton(ThreeOfAKind, false);
                }
            }
            else if (sender.Equals(FourOfAKind))
            {
                if (_game.CheckIfValidLowerCategory(_game.scoreBoard.ScoreCategory[4]))
                {
                    _game.EvaluateDiceSumLowerCategory(_game.scoreBoard.ScoreCategory[4]);
                    _game.EnableOrDisableButton(FourOfAKind, false);
                }
            }
            else if (sender.Equals(Yahtzee)) // score 50
            {
                if (_game.CheckIfValidLowerCategory(_game.scoreBoard.ScoreCategory[5]))
                {
                    _game.player.Score += 50;
                    _game.EnableOrDisableButton(Yahtzee, false);
                }
            }
            else if (sender.Equals(FullHouse)) //score 25
            {
                if (_game.CheckIfValidFullHouse())
                {
                    _game.player.Score += 25;
                    _game.EnableOrDisableButton(FullHouse, false);
                }
            }
            else if (sender.Equals(SmallStraight)) //score 30
            {
                if (_game.CheckIfValidSmallStraight())
                {
                    _game.player.Score += 30;
                    _game.EnableOrDisableButton(SmallStraight, false);
                }
            }
            else if (sender.Equals(LargeStraight)) // score 40
            {
                if (_game.CheckIfValidLargeStraight())
                {
                    _game.player.Score += 40;
                    _game.EnableOrDisableButton(LargeStraight, false);
                }
            }
            lbl_results.Content = "Current Score : " + _game.player.Score + " Chances left : " + _game.player.Chances;
            _game.ResetGameCounters();
        }
        #endregion

        #region Private Methods
        private void InitialDicesView()
        {
            _game.DiceTopPattern[0].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_blank.png"));
            _game.DiceTopPattern[1].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_1.png"));
            _game.DiceTopPattern[2].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_2.png"));
            _game.DiceTopPattern[3].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_3.png"));
            _game.DiceTopPattern[4].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_4.png"));
            _game.DiceTopPattern[5].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_5.png"));
            _game.DiceTopPattern[6].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_6.png"));
        }

        private void DicesViewAfterRoll()
        {
            lbl_dice1.Source = _game.DiceTopPattern[_game.player.Dices[0].TopNumber].Source;
            lbl_dice2.Source = _game.DiceTopPattern[_game.player.Dices[1].TopNumber].Source;
            lbl_dice3.Source = _game.DiceTopPattern[_game.player.Dices[2].TopNumber].Source;
            lbl_dice4.Source = _game.DiceTopPattern[_game.player.Dices[3].TopNumber].Source;
            lbl_dice5.Source = _game.DiceTopPattern[_game.player.Dices[4].TopNumber].Source;
        }

        private void ResetGame()
        {
            _game.EnableOrDisableButton(Aces, true);
            _game.EnableOrDisableButton(Twos, true);
            _game.EnableOrDisableButton(Threes, true);
            _game.EnableOrDisableButton(Fours, true);
            _game.EnableOrDisableButton(Fives, true);
            _game.EnableOrDisableButton(Sixes, true);
            _game.EnableOrDisableButton(ThreeOfAKind, true);
            _game.EnableOrDisableButton(FourOfAKind, true);
            _game.EnableOrDisableButton(FullHouse, true);
            _game.EnableOrDisableButton(SmallStraight, true);
            _game.EnableOrDisableButton(LargeStraight, true);
            _game.EnableOrDisableButton(Yahtzee, true);
            lbl_results.Content = "Roll the Dice!";
            _game._isScoreBoardSelected = false;
            _game.player.Chances = 25;
            _game.player.Score = 0;
        }
    }
}

#endregion