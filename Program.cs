using System;
using static JankenGame.Hand;

namespace JankenGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // BugCheck
            Hand.Hands.ForEach(x =>
            {
                Hand.Hands.ForEach(y =>
                {
                    //Console.WriteLine($"{x.Type} vs {y.Type} => {x.Battle(y)}");
                    if(x.Battle(y) == Hand.ResultOfBattle.Win)
                        if(y.Battle(x) != Hand.ResultOfBattle.Lose)
                            Console.WriteLine($"BugReport:勝敗結果が非対称な手があります({x},{y})");
                    else if(x.Battle(y) == Hand.ResultOfBattle.Lose)
                        if(y.Battle(x) != Hand.ResultOfBattle.Win)
                            Console.WriteLine($"BugReport:勝敗結果が非対称な手があります({x},{y})");
                    else
                        if(y.Battle(x) != Hand.ResultOfBattle.Draw || y.Battle(x) != Hand.ResultOfBattle.Draw)
                            Console.WriteLine($"BugReport:勝敗結果が非対称な手があります({x},{y})");
                });
            });

            //IPlayer p1 = new RandomCpu();
            IPlayer p1 = new CommandLineImput();
            IPlayer p2 = new RandomCpu();
            PrintBattle(p1, p2);
        }

        static void PrintBattle(IPlayer p1, IPlayer p2)
        {
            var p1Hand = p1.GetHand();
            var p2Hand = p2.GetHand();
            PrintHand(p1, p1Hand);
            PrintHand(p2, p2Hand);
            PrintResult(p1, p1Hand.Battle(p2Hand));
            PrintResult(p2, p2Hand.Battle(p1Hand));
        }
        static void PrintHand(IPlayer player, Hand hand)
        {
            Console.WriteLine($"{player.Name}の手:{hand}");
        }
        static void PrintResult(IPlayer player, ResultOfBattle result)
        {
            Console.WriteLine($"{player.Name}の結果:{result}");
        }
    }

}
