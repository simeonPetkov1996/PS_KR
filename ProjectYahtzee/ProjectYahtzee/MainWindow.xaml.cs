using ProjectYahtzee.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectYahtzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random random = new Random();
        private List<ScoreSheet> ScoreSheets = new List<ScoreSheet>();
        int CurrentThrow = 0;

        public MainWindow()
        {
            InitializeComponent();

            InitDiceButtons();
            InitScoreSheetButtons();
            ScoreSheets.Add(new ScoreSheet("Your score"));
            ScoreSheets.Add(new ScoreSheet("Current throw"));
            ScoreSheetDG.ItemsSource = ScoreSheets;
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            RollButtonsIfGreen();
            CalculateAndSetCurrentThrowScores();
            if (CurrentThrow == 2)
            {
                RollButton.IsEnabled = false;
                CurrentThrow = 0;
            }
            else
            {
                CurrentThrow++;
            }
        }

        private void RollButtonsIfGreen()
        {
            foreach (Button button in DiceButtons.Buttons)
            {
                if (button.Background == Brushes.Green)
                {
                    int diceValue = random.Next(1, 7);
                    button.Content = diceValue;
                }
            }
        }

        private void CalculateAndSetCurrentThrowScores()
        {
            List<int> CurrentDiceValues = new List<int>();
            foreach (Button button in DiceButtons.Buttons)
            {
                CurrentDiceValues.Add(Int32.Parse(button.Content.ToString()));
            }
            ScoreSheets[1].Calculate(CurrentDiceValues);
            ScoreSheetDG.Items.Refresh();
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            ChangeDiceState(sender as Button);
        }

        private void ChangeDiceState(Button button)
        {
            if (button.Content != null)
            {
                if (button.Background == Brushes.Green)
                {
                    button.Background = Brushes.Red;
                }
                else
                {
                    button.Background = Brushes.Green;
                }
            }
        }

        private void OnesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Ones = ScoreSheets[1].Ones;
                OnesButton.IsEnabled = false;
                Clear();
            }
        }

        private void TwosButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Twos = ScoreSheets[1].Twos;
                TwosButton.IsEnabled = false;
                Clear();
            }
        }

        private void ThreesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Threes = ScoreSheets[1].Threes;
                ThreesButton.IsEnabled = false;
                Clear();
            }
        }

        private void FoursButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Fours = ScoreSheets[1].Fours;
                FoursButton.IsEnabled = false;
                Clear();
            }
        }

        private void FivesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Fives = ScoreSheets[1].Fives;
                FivesButton.IsEnabled = false;
                Clear();

            }
        }

        private void SixesButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Sixes = ScoreSheets[1].Sixes;
                SixesButton.IsEnabled = false;
                Clear();
            }
        }

        private void ThreeOfAKindButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].ThreeOfAKind = ScoreSheets[1].ThreeOfAKind;
                ThreeOfAKindButton.IsEnabled = false;
                Clear();
            }
        }

        private void FourOfAKindButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].FourOfAKind = ScoreSheets[1].FourOfAKind;
                FourOfAKindButton.IsEnabled = false;
                Clear();
            }
        }

        private void FullHouseButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].FullHouse = ScoreSheets[1].FullHouse;
                FullHouseButton.IsEnabled = false;
                Clear();
            }
        }

        private void SmallStraightButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].SmallStraight = ScoreSheets[1].SmallStraight;
                SmallStraightButton.IsEnabled = false;
                Clear();
            }
        }

        private void LargeStraightButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].LargeStraight = ScoreSheets[1].LargeStraight;
                LargeStraightButton.IsEnabled = false;
                Clear();
            }
        }

        private void YahtzeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Yahtzee = ScoreSheets[1].Yahtzee;
                YahtzeeButton.IsEnabled = false;
                Clear();
            }
        }

        private void ChanceButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreDicesRolled())
            {
                ScoreSheets[0].Chance = ScoreSheets[1].Chance;
                ChanceButton.IsEnabled = false;
                Clear();
            }
        }

        private Boolean AreDicesRolled()
        {
            foreach(Button button in DiceButtons.Buttons)
            {
                if(button.Content == null || button.Content.Equals(""))
                {
                    return false;
                }
            }
            return true;
        }

        private void Clear()
        {
            ClearDiceButtons();
            CurrentThrow = 0;
            RollButton.IsEnabled = true;
            ScoreSheets[1] = new ScoreSheet("Current throw");
            if (IsGameEnded())
            {
                MessageBox.Show("Game ended your score is: " + ScoreSheets[0].GetFinalScore());
                ResetGame();
            }
            ScoreSheetDG.Items.Refresh();
        }

        private void ClearDiceButtons()
        {
            foreach (Button button in DiceButtons.Buttons)
            {
                button.Background = Brushes.Green;
                button.Content = "";
            }
        }

        private Boolean IsGameEnded()
        {
            foreach (Button button in ScoreSheetButtons.Buttons)
            {
                if (button.IsEnabled == true)
                {
                    return false;
                }
            }
            return true;
        }

        private void ResetGame()
        {
            ScoreSheets[0] = new ScoreSheet("Current throw");
            SetScoreButtonsIsEnabled(true);
        }

        private void SetScoreButtonsIsEnabled(Boolean IsEnabled)
        {
            foreach (Button button in ScoreSheetButtons.Buttons)
            {
                button.IsEnabled = IsEnabled;
            }
        }

        private void InitDiceButtons()
        {
            DiceButtons.Buttons = new List<Button>();
            DiceButtons.Buttons.Add(Dice1);
            DiceButtons.Buttons.Add(Dice2);
            DiceButtons.Buttons.Add(Dice3);
            DiceButtons.Buttons.Add(Dice4);
            DiceButtons.Buttons.Add(Dice5);
        }

        private void InitScoreSheetButtons()
        {
            ScoreSheetButtons.Buttons = new List<Button>();
            ScoreSheetButtons.Buttons.Add(OnesButton);
            ScoreSheetButtons.Buttons.Add(TwosButton);
            ScoreSheetButtons.Buttons.Add(ThreesButton);
            ScoreSheetButtons.Buttons.Add(FoursButton);
            ScoreSheetButtons.Buttons.Add(FivesButton);
            ScoreSheetButtons.Buttons.Add(SixesButton);
            ScoreSheetButtons.Buttons.Add(ThreeOfAKindButton);
            ScoreSheetButtons.Buttons.Add(FourOfAKindButton);
            ScoreSheetButtons.Buttons.Add(FullHouseButton);
            ScoreSheetButtons.Buttons.Add(SmallStraightButton);
            ScoreSheetButtons.Buttons.Add(LargeStraightButton);
            ScoreSheetButtons.Buttons.Add(YahtzeeButton);
            ScoreSheetButtons.Buttons.Add(ChanceButton);
        }
    }
}
