using System;

namespace JankenGame
{
    class Program
    {
        static void Main(string[] args)
        {

            //Hand.Hands.ForEach(x =>
            //{
            //    Hand.Hands.ForEach(y =>
            //    {
            //        Console.WriteLine($"{x.Type} vs {y.Type} => {x.Battle(y)}");
            //    });
            //});

            IPlayer player = new CommandLineImput();
            IPlayer cpu = new RandomCpu();
            var yourHand = player.GetHand();
            var cpuHnad = cpu.GetHand();

            Console.WriteLine($"あなたの手:{yourHand}");
            Console.WriteLine($"CPUの手:{cpuHnad}");
            Console.WriteLine($"結果:{yourHand.Battle(cpuHnad)}");
        }
    }

}
