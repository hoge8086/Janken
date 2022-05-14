using System;
using System.Linq;

namespace JankenGame
{
    class CommandLineImput : IPlayer
    {
        public string Name => "あなた";
        public Hand GetHand()
        {
            Hand hand = null;
            do
            {
                Console.Write("手を入力してください>");
                var input = Console.ReadLine();
                var handName = input.Trim();

                hand = Hand.Hands.FirstOrDefault(x => {
                    var name = x.Type.ToString();
                    return name.StartsWith(handName, StringComparison.InvariantCultureIgnoreCase);
                });

            } while (hand == null);

            return hand;
        }
    }
}
