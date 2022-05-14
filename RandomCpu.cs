using System;

namespace JankenGame
{
    class RandomCpu : IPlayer
    {
        public Hand GetHand()
        {
            return Hand.Hands[new Random().Next(0, Hand.Hands.Count)];
        }
    }
}
