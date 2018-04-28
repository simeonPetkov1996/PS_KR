using ProjectYahtzee.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee
{
    
    class ScoreSheet
    {
        public String Type { get; set; }
        public int Ones { get; set; }
        public int Twos { get; set; }
        public int Threes { get; set; }
        public int Fours { get; set; }
        public int Fives { get; set; }
        public int Sixes { get; set; }
        public int ThreeOfAKind { get; set; }
        public int FourOfAKind { get; set; }
        public int FullHouse { get; set; }
        public int SmallStraight { get; set; }
        public int LargeStraight { get; set; }
        public int Yahtzee { get; set; }
        public int Chance { get; set; }

        public OneCalculator OnesCalculator = new OneCalculator();
        public TwoCalculator TwoCalculator = new TwoCalculator();
        public ThreeCalculator ThreeCalculator = new ThreeCalculator();
        public FourCalculator FourCalculator = new FourCalculator();
        public FiveCalculator FiveCalculator = new FiveCalculator();
        public SixCalculator SixCalculator = new SixCalculator();
        public ThreeOfAKindCalculator ThreeOfAKindCalculator = new ThreeOfAKindCalculator();
        public FourOfAKindCalculator FourOfAKindCalculator = new FourOfAKindCalculator();
        public FullHouseCalculator FullHouseCalculator = new FullHouseCalculator();
        public SmallStraightCalculator SmallStraightCalculator = new SmallStraightCalculator();
        public LargeStraightCalculator LargeStraightCalculator = new LargeStraightCalculator();
        public YahtzeeCalculator YahtzeeCalculator = new YahtzeeCalculator();
        public ChanceCalculator ChanceCalculator = new ChanceCalculator();

        public ScoreSheet(String Type)
        {
            this.Type = Type;
            Ones = 0;
            Twos = 0;
            Threes = 0;
            Fours = 0;
            Fives = 0;
            Sixes = 0;
            ThreeOfAKind = 0;
            FourOfAKind = 0;
            FullHouse = 0;
            SmallStraight = 0;
            LargeStraight = 0;
            Yahtzee = 0;
            Chance = 0;
        }

        public void Calculate(List<int> CurrentDiceValues)
        {
            Ones = OnesCalculator.Calculate(CurrentDiceValues);
            Twos = TwoCalculator.Calculate(CurrentDiceValues);
            Threes = ThreeCalculator.Calculate(CurrentDiceValues);
            Fours = FourCalculator.Calculate(CurrentDiceValues);
            Fives = FiveCalculator.Calculate(CurrentDiceValues);
            Sixes = SixCalculator.Calculate(CurrentDiceValues);
            ThreeOfAKind = ThreeOfAKindCalculator.Calculate(CurrentDiceValues);
            FourOfAKind = FourOfAKindCalculator.Calculate(CurrentDiceValues);
            FullHouse = FullHouseCalculator.Calculate(CurrentDiceValues);
            SmallStraight = SmallStraightCalculator.Calculate(CurrentDiceValues);
            LargeStraight = LargeStraightCalculator.Calculate(CurrentDiceValues);
            Yahtzee = YahtzeeCalculator.Calculate(CurrentDiceValues);
            Chance = ChanceCalculator.Calculate(CurrentDiceValues);
        }

        public int GetFinalScore()
        {
            return Ones + Twos + Threes + Fours + Fives + Sixes + ThreeOfAKind + FourOfAKind + FullHouse + SmallStraight + LargeStraight + Yahtzee + Chance;
        }
    }
}
