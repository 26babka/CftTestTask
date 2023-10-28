using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    static class BullsAndCowsGame
    {
        public static void Start()
        {
            Console.WriteLine(LocalizedStrings.Menu);
            int.TryParse(Console.ReadLine(), out int mode);

            switch (mode)
            {
                case 1:
                    VsPlayer();
                    break;
                case 2:
                    VsComputer();
                    break;
                default:
                    throw new ArgumentException(LocalizedStrings.WrongMode);
            }
        }
        static void VsComputer()
        {
            var bnc = new BullsAndCowsSolver();
            bnc.Play();
        }

        public static void VsPlayer()
        {
            while (true)
            {
                Console.WriteLine("Input 1st player number to guess: ");
                var bncPlayer1 = new BullsAndCowsSolver(GetNumber());
                bool isP1Win = bncPlayer1.Play();

                Console.WriteLine("Input 2nd player number to guess: ");
                var bncPlayer2 = new BullsAndCowsSolver(GetNumber());
                bool isP2Win = bncPlayer2.Play();

                if(!(isP1Win && isP2Win))
                {
                    if (isP1Win)
                    {
                        Console.WriteLine("Player1 win!");
                    }
                    else
                    {
                        Console.WriteLine("Player2 win!");
                    }
                    return;
                }
            }
        }

        public static string GetNumber()
        {
            var sb = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter) break;

                Console.Write("*");
                sb.Append(key.KeyChar);

            }
            Console.WriteLine();
            return sb.ToString();
        }
    }
}
