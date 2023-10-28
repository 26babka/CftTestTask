using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    internal class BullsAndCowsSolver
    {
        readonly int TotalAttempts = 10;
        
        readonly int NumLength = 4;

        private string GuessNum { get; set; }

        private int AttemptsLeft { get; set; }

        public BullsAndCowsSolver(string number)
        {
            if (!ValidateNumber(number))
                throw new ArgumentException(LocalizedStrings.InvalidNumber);

            GuessNum = number;
            AttemptsLeft = TotalAttempts;
        }

        public BullsAndCowsSolver()
        {
            string number = GenerateNumber();
            if (!ValidateNumber(number))
                throw new ArgumentException(LocalizedStrings.InvalidNumber);

            GuessNum = number;
            AttemptsLeft = TotalAttempts;
        }

        public bool Play()
        {
            while (AttemptsLeft > 0)
            {
                Console.Write("Enter your number: ");
                string number = Console.ReadLine();

                if (!ValidateNumber(number))
                    throw new ArgumentException(LocalizedStrings.InvalidNumber);

                if (IsGuessed(number))
                {
                    Console.WriteLine(LocalizedStrings.Guessed);
                    return true;
                }

                AttemptsLeft--;
            }
            Console.WriteLine(LocalizedStrings.NotGuessed);
            return false;
        }

        private bool IsGuessed(string number)
        {
            int bulls = 0;
            int cows = 0;
            for (int i = 0; i < number?.Length; i++)
            {
                for (int j = 0; j < GuessNum.Length; j++)
                {
                    if (number[i] == GuessNum[j])
                    {
                        if (i == j)
                            bulls++;
                        else
                            cows++;
                    }
                }
            }
            Console.WriteLine($"Cows: {cows}\nBulls: {bulls}");

            if (bulls == GuessNum.Length)
                return true;

            return false;
        }

        private bool ValidateNumber(string number) => int.TryParse(number, out _) && 
            number.Length == NumLength && number.Distinct().Count() == number.Length;

        private string GenerateNumber()
        {
            if (NumLength <= 0)
                throw new ArgumentException(string.Format(LocalizedStrings.InvalidLength, NumLength));

            var rand = new Random();
            var list = new List<int> { rand.Next(1, 9) };
            while (list.Count < NumLength)
            {
                int value = rand.Next(0, 9);
                if (list.Contains(value))
                    continue;

                list.Add(value);    
            }

            var sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item);
            }

            return sb.ToString();
        }
    }
}
