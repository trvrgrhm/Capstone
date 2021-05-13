using System;

namespace GenericStrategyGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new StrategyGame())
                game.Run();
        }
    }
}
