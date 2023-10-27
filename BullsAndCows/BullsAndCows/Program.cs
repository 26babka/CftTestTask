using BullsAndCows;
using System.Runtime.InteropServices;

static void Start()
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

static void VsPlayer()
{
    Console.WriteLine("Enter number to guess: ");
    string number = Console.ReadLine();
    Console.Clear();
    var bnc = new BullsAndCowsSolver(number);

    bnc.Play();
}

static void VsComputer()
{
    var bnc = new BullsAndCowsSolver();
    bnc.Play();
}

try
{
    Start();
} 
catch(Exception ex)
{
   Console.WriteLine(ex.ToString());
}


