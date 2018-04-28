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

            ScoreSheets.Add(new ScoreSheet("Your score"));
            ScoreSheets.Add(new ScoreSheet("Current throw"));
            ScoreSheetDG.ItemsSource = ScoreSheets;
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            RollIfEnabled(Dice1);
            RollIfEnabled(Dice2);
            RollIfEnabled(Dice3);
            RollIfEnabled(Dice4);
            RollIfEnabled(Dice5);
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

        private void RollIfEnabled(Button button)
        {
            if (button.Background == Brushes.Green)
            {
                int diceValue = random.Next(1, 7);
                button.Content = diceValue;
            }
        }

        private void CalculateAndSetCurrentThrowScores()
        {
            List<int> CurrentDiceValues = new List<int>();
            CurrentDiceValues.Add(Int32.Parse(Dice1.Content.ToString()));
            CurrentDiceValues.Add(Int32.Parse(Dice2.Content.ToString()));
            CurrentDiceValues.Add(Int32.Parse(Dice3.Content.ToString()));
            CurrentDiceValues.Add(Int32.Parse(Dice4.Content.ToString()));
            CurrentDiceValues.Add(Int32.Parse(Dice5.Content.ToString()));
            ScoreSheets[1].Calculate(CurrentDiceValues);
            ScoreSheetDG.Items.Refresh();
        }

        private void Dice1_Click(object sender, RoutedEventArgs e)
        {
            ChangeDiceState(Dice1);
        }

        private void Dice2_Click(object sender, RoutedEventArgs e)
        {
            ChangeDiceState(Dice2);
        }

        private void Dice3_Click(object sender, RoutedEventArgs e)
        {
            ChangeDiceState(Dice3);
        }

        private void Dice4_Click(object sender, RoutedEventArgs e)
        {
            ChangeDiceState(Dice4);
        }

        private void Dice5_Click(object sender, RoutedEventArgs e)
        {
            ChangeDiceState(Dice5);
        }

        private void ChangeDiceState(Button button)
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

        private void OnesButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Ones = ScoreSheets[1].Ones;
            OnesButton.IsEnabled = false;
            Clear();
        }

        private void TwosButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Twos = ScoreSheets[1].Twos;
            TwosButton.IsEnabled = false;
            Clear();
        }

        private void ThreesButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Threes = ScoreSheets[1].Threes;
            ThreesButton.IsEnabled = false;
            Clear();
        }

        private void FoursButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Fours = ScoreSheets[1].Fours;
            FoursButton.IsEnabled = false;
            Clear();
        }

        private void FivesButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Fives = ScoreSheets[1].Fives;
            FivesButton.IsEnabled = false;
            Clear();
        }

        private void SixesButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Sixes = ScoreSheets[1].Sixes;
            SixesButton.IsEnabled = false;
            Clear();
        }

        private void ThreeOfAKindButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].ThreeOfAKind = ScoreSheets[1].ThreeOfAKind;
            ThreeOfAKindButton.IsEnabled = false;
            Clear();
        }

        private void FourOfAKindButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].FourOfAKind = ScoreSheets[1].FourOfAKind;
            FourOfAKindButton.IsEnabled = false;
            Clear();
        }

        private void FullHouseButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].FullHouse = ScoreSheets[1].FullHouse;
            FullHouseButton.IsEnabled = false;
            Clear();
        }

        private void SmallStraightButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].SmallStraight = ScoreSheets[1].SmallStraight;
            SmallStraightButton.IsEnabled = false;
            Clear();
        }

        private void LargeStraightButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].LargeStraight = ScoreSheets[1].LargeStraight;
            LargeStraightButton.IsEnabled = false;
            Clear();
        }

        private void YahtzeeButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Yahtzee = ScoreSheets[1].Yahtzee;
            YahtzeeButton.IsEnabled = false;
            Clear();
        }

        private void ChanceButton_Click(object sender, RoutedEventArgs e)
        {
            ScoreSheets[0].Chance = ScoreSheets[1].Chance;
            ChanceButton.IsEnabled = false;
            Clear();
        }

        private void Clear()
        {
            Dice1.Background = Brushes.Green;
            Dice2.Background = Brushes.Green;
            Dice3.Background = Brushes.Green;
            Dice4.Background = Brushes.Green;
            Dice5.Background = Brushes.Green;
            Dice1.Content = "";
            Dice2.Content = "";
            Dice3.Content = "";
            Dice4.Content = "";
            Dice5.Content = "";
            RollButton.IsEnabled = true;
            ScoreSheets[1] = new ScoreSheet("Current throw");

            if (IsGameEnded())
            {
                MessageBox.Show("Game ended your score is: " + ScoreSheets[0].GetFinalScore());
                ResetGame();
            }
            ScoreSheetDG.Items.Refresh();
        }

        private Boolean IsGameEnded()
        {
            if (OnesButton.IsEnabled == true)
            {
                return false;
            }
            if (TwosButton.IsEnabled == true)
            {
                return false;
            }
            if (ThreesButton.IsEnabled == true)
            {
                return false;
            }
            if (FoursButton.IsEnabled == true)
            {
                return false;
            }
            if (FivesButton.IsEnabled == true)
            {
                return false;
            }
            if (SixesButton.IsEnabled == true)
            {
                return false;
            }
            if (ThreeOfAKindButton.IsEnabled == true)
            {
                return false;
            }
            if (FourOfAKindButton.IsEnabled == true)
            {
                return false;
            }
            if (FullHouseButton.IsEnabled == true)
            {
                return false;
            }
            if (SmallStraightButton.IsEnabled == true)
            {
                return false;
            }
            if (LargeStraightButton.IsEnabled == true)
            {
                return false;
            }
            if (YahtzeeButton.IsEnabled == true)
            {
                return false;
            }
            if (ChanceButton.IsEnabled == true)
            {
                return false;
            }
            return true;
        }

        private void ResetGame()
        {
            ScoreSheets[0] = new ScoreSheet("Current throw");
            SetScoreButtonsIsEnabled(true);
        }

        private void SetScoreButtonsIsEnabled(Boolean isEnabled)
        {
            OnesButton.IsEnabled = isEnabled;
            TwosButton.IsEnabled = isEnabled;
            ThreesButton.IsEnabled = isEnabled;
            FoursButton.IsEnabled = isEnabled;
            FivesButton.IsEnabled = isEnabled;
            SixesButton.IsEnabled = isEnabled;
            ThreeOfAKindButton.IsEnabled = isEnabled;
            FourOfAKindButton.IsEnabled = isEnabled;
            FullHouseButton.IsEnabled = isEnabled;
            SmallStraightButton.IsEnabled = isEnabled;
            LargeStraightButton.IsEnabled = isEnabled;
            YahtzeeButton.IsEnabled = isEnabled;
            ChanceButton.IsEnabled = isEnabled;
        }
    }
}
