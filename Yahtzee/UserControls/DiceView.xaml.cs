#region Statements
using System;
using System.ComponentModel;
using System.Linq;
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
    public partial class DiceView : UserControl, INotifyPropertyChanged​
    {
        #region Declaration
        private GameManager _gmanager = new GameManager();

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Initializaion
        public DiceView()
        {
            InitializeComponent();
            InitialDicesView();
            lblResults.Content = "Roll the Dice!";
            CategoryButtonGroup = new Button[] { btnAces, btnTwos, btnThrees, btnFours, btnFives, btnSixes, btnThreeOfAKind, btnFourOfAKind, btnYahtzee, btnSmallStraight, btnLargeStraight, btnFullHouse };
            HoldButtonGroup = new Button[] { btnHoldD1, btnHoldD2, btnHoldD3, btnHoldD4, btnHoldD5 };
        }
        #endregion

        #region Properties
        public Button[] CategoryButtonGroup
        {
            get;
            set;
        }

        public Button[] HoldButtonGroup
        {
            get;
            set;
        }

        #endregion

        #region Event Handlers
        private void OnRollButtonClick(object sender, RoutedEventArgs e)
        {
            _gmanager.player.Chance--;

            if (_gmanager.player.Chance >= 0)
            {
                _gmanager.RollDices();
                _gmanager.AreDicesRolled = true;
                DicesViewAfterRoll();
                if(_gmanager.player.Chance == 0)
                {
                    btnRollDices.IsEnabled = false;
                }
            }
            lblResults.Content = "Current Score : " + _gmanager.player.Score + ", Round : " + _gmanager.player.Rounds + ",  Rolls Left : " + _gmanager.player.Chance;
        }

        private void OnScoreBoardClick(object sender, RoutedEventArgs e)
        {
            if (_gmanager.AreDicesRolled)
            {
                if (sender.Equals(btnAces))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryAces")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[0]);

                }
                else if (sender.Equals(btnTwos))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryTwos")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[1]);
                }
                else if (sender.Equals(btnThrees))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryThrees")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[2]);
                }
                else if (sender.Equals(btnFours))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryFours")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[3]);
                }
                else if (sender.Equals(btnFives))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryFives")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[4]);
                }
                else if (sender.Equals(btnSixes))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategorySixes")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[5]);
                }

                else if (sender.Equals(btnThreeOfAKind))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryThreeOfAKind")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[6]);
                }
                else if (sender.Equals(btnFourOfAKind))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryFourOfAKind")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[7]);
                }
                else if (sender.Equals(btnYahtzee))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryFiveOfAKind")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[8]);
                }
                else if (sender.Equals(btnSmallStraight))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategorySmallStraight")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[9]);
                }
                else if (sender.Equals(btnLargeStraight))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryLargeStraight")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[10]);
                }
                else if (sender.Equals(btnFullHouse))
                {
                    _gmanager.player.AddToScore(_gmanager.Categories.FirstOrDefault(c => c.Name.Equals("CategoryFullHouse")).Evaluate(_gmanager.Dices));
                    _gmanager.DisableCategoryButton(CategoryButtonGroup[11]);
                }


                _gmanager.player.Chance = 3;
                _gmanager.player.Rounds++;
                lblResults.Content = "Current Score : " + _gmanager.player.Score + ", Round : " + _gmanager.player.Rounds + ",  Rolls Left : " + _gmanager.player.Chance;
       
                btnRollDices.IsEnabled = true;
                _gmanager.ResetHoldButtonsState(HoldButtonGroup);
                _gmanager.AreDicesRolled = false;


                if (CountTrues(CategoryButtonGroup) >= 12)
                {
                    MessageBox.Show("Game Over. Your Score is : " + _gmanager.player.Score);
                    _gmanager.ResetGame(CategoryButtonGroup, HoldButtonGroup, btnRollDices);
                    //_gmanager.player.Rounds = 0;
                    lblResults.Content = "Roll the Dice!";


                    if (btnRollDices.IsEnabled == false)
                    {
                        btnRollDices.IsEnabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Roll Dices, before selecting any category!");
            }

            
        }

        public int CountTrues(Button[] buttons)
        {
            int result = 0;
            foreach (Button b in buttons)
            {
                if (b.IsEnabled ==false)
                result++;
            }
            return result;
        }

        public int CountTrues(bool[] booleans)
        {
            int result = 0;
            foreach (bool b in booleans)
            {
                if (b) result++;
            }

            return result;
        }

        public static int Truth(params bool[] booleans)
        {
            return booleans.Count(b => b);
        }

        private void OnHoldButtonClick(object sender, RoutedEventArgs e)
        {
            if (_gmanager.AreDicesRolled)
            {
                if (sender.Equals(btnHoldD1))
                {
                    _gmanager.CheckHoldButtonState(_gmanager.Dices[0], btnHoldD1, "Hold D1");
                }
                else if (sender.Equals(btnHoldD2))
                {
                    _gmanager.CheckHoldButtonState(_gmanager.Dices[1], btnHoldD2, "Hold D2");
                }
                else if (sender.Equals(btnHoldD3))
                {
                    _gmanager.CheckHoldButtonState(_gmanager.Dices[2], btnHoldD3, "Hold D3");
                }
                else if (sender.Equals(btnHoldD4))
                {
                    _gmanager.CheckHoldButtonState(_gmanager.Dices[3], btnHoldD4, "Hold D4");
                }
                else if (sender.Equals(btnHoldD5))
                {
                    _gmanager.CheckHoldButtonState(_gmanager.Dices[4], btnHoldD5, "Hold D5");
                }
            }
        }

        private void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            _gmanager.ResetGame(CategoryButtonGroup, HoldButtonGroup, btnRollDices);

            lblResults.Content = "Roll the Dice!";
        }
        #endregion

        #region Private Methods
        private void InitialDicesView()
        {
            _gmanager.DiceTopPattern[0].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_blank.png"));
            _gmanager.DiceTopPattern[1].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_1.png"));
            _gmanager.DiceTopPattern[2].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_2.png"));
            _gmanager.DiceTopPattern[3].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_3.png"));
            _gmanager.DiceTopPattern[4].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_4.png"));
            _gmanager.DiceTopPattern[5].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_5.png"));
            _gmanager.DiceTopPattern[6].Source = new BitmapImage(new Uri("D:/Yahtzee/Yahtzee/Images/dice_6.png"));
        }

        private void DicesViewAfterRoll()
        {
            lblDice1.Source = _gmanager.DiceTopPattern[_gmanager.Dices[0].TopNumber].Source;
            lblDice2.Source = _gmanager.DiceTopPattern[_gmanager.Dices[1].TopNumber].Source;
            lblDice3.Source = _gmanager.DiceTopPattern[_gmanager.Dices[2].TopNumber].Source;
            lblDice4.Source = _gmanager.DiceTopPattern[_gmanager.Dices[3].TopNumber].Source;
            lblDice5.Source = _gmanager.DiceTopPattern[_gmanager.Dices[4].TopNumber].Source;
        }
        #endregion
    }
}