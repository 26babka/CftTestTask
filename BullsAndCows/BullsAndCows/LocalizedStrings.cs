using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public static class LocalizedStrings
    {
        public static readonly string InvalidNumber = "Invalid number. Numbers should not be repeated";

        public static readonly string InvalidLength = "Invalid length. The length should be {0}";

        public static readonly string NotGuessed = "You didn't guess the number";

        public static readonly string Guessed = "You guessed the number";

        public static readonly string WrongMode = "Wrong mode. Select 1 or 2 mode";

        public static readonly string Menu = "1. Player vs player\n2. Player vs computer";
    }
}
