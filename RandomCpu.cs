using System;

namespace JankenGame
{
    class RandomCpu : IPlayer
    {
        public string Name => "CPU";

        public Hand GetHand()
        {
            return Hand.Hands[new Random().Next(0, Hand.Hands.Count)];
        }
    }
}
