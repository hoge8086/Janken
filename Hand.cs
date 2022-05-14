using System;
using System.Collections.Generic;

namespace JankenGame
{
    class Hand
    {
        public enum ResultOfBattle
        {
            Win,
            Lose,
            Draw,
        }
        public HandType Type { get; private set; }
        private Predicate<Hand> BeatCondition;

        private Hand(HandType type, Predicate<Hand> beatCondition)
        {
            Type = type;
            BeatCondition = beatCondition;
        }

        public ResultOfBattle Battle(Hand opponent)
        {
            if(this.Type == opponent.Type)
                return ResultOfBattle.Draw;

            if (BeatCondition(opponent))
                return ResultOfBattle.Win;

            if (opponent.BeatCondition(this))
                return ResultOfBattle.Lose;

            return ResultOfBattle.Draw;
        }

        public enum HandType
        {
            Rock,
            Paper,
            Scissors,
            King,
            Joker,
        }

        public readonly static List<Hand> Hands = new List<Hand>
        {
            //new Hand(HandType.Rock, x => x.Type == HandType.Scissors),
            //new Hand(HandType.Scissors, x => x.Type == HandType.Paper),
            //new Hand(HandType.Paper, x => x.Type == HandType.Rock),
            new Hand(HandType.Rock, x => x.Type == HandType.Scissors || x.Type == HandType.Joker),
            new Hand(HandType.Scissors, x => x.Type == HandType.Paper || x.Type == HandType.Joker),
            new Hand(HandType.Paper, x => x.Type == HandType.Rock || x.Type == HandType.Joker),
            new Hand(HandType.King, x => x.Type != HandType.Joker),
            new Hand(HandType.Joker, x => x.Type == HandType.King),
        };

        public override string ToString()
        {
            return Type.ToString();
        }
    }
}
