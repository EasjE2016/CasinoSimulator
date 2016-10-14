using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoSimulator
{
    // This class is supposed to simulate a classic slot machine.
    // The slot machine has three "dials"; each dial can show:
    // 7 : "Seven"
    // # : "Sharp"
    // @ : "At"
    //
    // The player can enter "credits" into the machine.
    // Each spin on the machine costs one credit.
    // Certain combinations of the three dials gives the player
    // a winning.
    //
    class SlotMachineSimulator
    {
        // INSTANCE VARIABLES

        // The numbers of credits left in the machine
        private int credits;

        // The three dials on the slot machine
        private string dial1;
        private string dial2;
        private string dial3;

        // This instance variable is used for generating random numbers
        private Random generator;


        // CONSTANTS

        // The probabilities that a dial shows a certain symbol:
        // 10 % for showing "7"
        // 30 % for showing "#"
        // 60 % for showing "@"
        //
        private const int probSeven = 10;
        private const int probSharp = 30;
        private const int probAt = 60;

        // The winnings paid to the player for certain dial combinations
        // 7 7 7 pays 150
        // # # # pays 10
        // @ @ @ pays 1
        // any two 7 pays 5
        // any two # pays 1
        //
        private const int winningSeven3 = 150;
        private const int winningSharp3 = 10;
        private const int winningAt3 = 1;
        private const int winningSeven2 = 5;
        private const int winningSharp2 = 1;
    


        // CONSTRUCTOR
        //
        public SlotMachineSimulator()
        {
            generator = new Random();
            Reset();
        }
 

        // PUBLIC METHODS

        // Sets the simulator back to its starting state
        public void Reset()
        {
            credits = 0;
        }

        // Returns the number of credits left in the machine
        public int GetCredits()
        {
            return credits;
        }
    
        // Adds a number of credits to the machine
        public void AddCredits(int moreCredits)
        {
            credits = credits + moreCredits;
        }

        // Perform one spin on the machine
        public void Spin()
        {
            // Inform the player how many credits are left before spinning
            Console.WriteLine();
            Console.WriteLine("Credits left : {0}, now spinning...", credits);

            // One spin costs one credit
            credits--;
        
            // Spin the dials
            dial1 = SpinDial();
            dial2 = SpinDial();
            dial3 = SpinDial();
        
            // Find the winnings, and update the credits left
            int winnings = CalculateWinnings(dial1,dial2,dial3);
            credits = credits + winnings;

            // Report the outcome of the spin to the player
            Console.WriteLine("You got : {0} {1} {2}", dial1, dial2, dial3);
            Console.WriteLine("You won {0} credit(s)", winnings);
            Console.WriteLine("Credits left : {0}", credits);
        }

        // Print the complete winning table
        public void PrintWinningTable()
        {
            Console.WriteLine("----------- Winning table for slot machine --------------");
            Console.WriteLine(" 7 7 7 pays      {0}", winningSeven3);
            Console.WriteLine(" # # # pays      {0}", winningSharp3);
            Console.WriteLine(" @ @ @ pays      {0}", winningAt3);
            Console.WriteLine(" any two 7 pays  {0}", winningSeven2);
            Console.WriteLine(" any two # pays  {0}", winningSharp2);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();
        }


        // PRIVATE METHODS

        // Generate a "percentage", i.e. a number between 0 and 100 (100 not included)
        private int GeneratePercentage()
        {
            int result = generator.Next(100);
            return result;
        }

        // Spin a dial, using the defined percentages
        private string SpinDial()
        {
            // Generate a random percentage
            int percentage = GeneratePercentage();

            // Given the random percentage, find out what the dial should show
            //
            if (percentage < probSeven)
            {
                return "7";
            }
            else if (percentage < (probSeven + probSharp))
            {
                return "#";
            }
            else
            {
                return "@";
            }
        }

        // Calculate the winnings corresponding to the given dial combination
        private int CalculateWinnings(string dial1, string dial2, string dial3)
        {
            if ((dial1 == "7") && (dial2 == "7") && (dial3 == "7"))
            {
                return winningSeven3;
            }
            else if ((dial1 == "#") && (dial2 == "#") && (dial3 == "#"))
            {
                return winningSharp3;
            }
            else if ((dial1 == "@") && (dial2 == "@") && (dial3 == "@"))
            {
                return winningAt3;
            }
            else if (CountSymbols("7", dial1, dial2, dial3) == 2)
            {
                return winningSeven2;
            }
            else if (CountSymbols("#", dial1, dial2, dial3) == 2)
            {
                return winningSharp2;
            }
            else
            {
                return 0;
            }
        }

        // A helper method for counting how many of the three strings that
        // are equal to the "target" string
        private int CountSymbols(string target, string c1, string c2, string c3)
        {
            int count = 0;

            if (target == c1) count++;
            if (target == c2) count++;
            if (target == c3) count++;

            return count;
        }
    }
}
