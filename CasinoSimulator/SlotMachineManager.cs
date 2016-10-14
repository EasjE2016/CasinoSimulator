using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoSimulator
{
    // This class manages a simulation of the slot machine.
    // Its main responsibility is to communicate with the player,
    // and keep the game running as long as the player wants
    class SlotMachineManager
    {
        // Only one instance variable; a slot machine simulator
        private SlotMachineSimulator theSimulator;

        public SlotMachineManager()
        {
            theSimulator = new SlotMachineSimulator();
        }


        // This method runs the slot machine simulation.
        // As long as the player wants to play (and has money left),
        // a new spin on the slot machine is done
        public void RunSimulation()
        {
            // Reset the simulator, so we start from the initial state
            theSimulator.Reset();

            Console.WriteLine("Slot Machine Simulator Starting...");
            Console.WriteLine();

            // Print the winning table, for the players convenience
            theSimulator.PrintWinningTable();

            Console.WriteLine("You get 10 credits to play for...");
            Console.WriteLine();

            // Add 10 credits to play for
            theSimulator.AddCredits(10);

            // The main loop: while the player still wants to play - and
            // has money left - a new spin is performed
            bool playAgain = true;
            while (playAgain && (theSimulator.GetCredits() > 0))
            {
                // Do another spin on the machine
                theSimulator.Spin();

                if (theSimulator.GetCredits() > 0)
                {
                    // The player has money left, so ask the player
                    // if (s)he wants to play again
                    playAgain = AskPlayerToPlayOrQuit();
                }
                else
                {
                    // Player has no money left, so the game must stop
                    Console.WriteLine("Sorry, you have no money left...");
                    Console.WriteLine();
                    playAgain = false;
                }
            }

            Console.WriteLine("Slot Machine Simulator Ending...");
            Console.WriteLine();
        }

        // This method asks the player if (s)he wants to play again.
        // If the method returns true, the player wants to play again.
        // Otherwise, the player wants to quit.
        // You do not need to understand the details of this method...
        private bool AskPlayerToPlayOrQuit()
        {
            // Ask the player if (s)he wants to play again.
            // The only acceptable answer is to press either "y" or "n"
            Console.Write("Play again? (press y for Yes, n for No) : ");
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            // keyStr now holds the players response
            String keyStr = key.KeyChar.ToString();

            if (keyStr == "y")
            {
                // Player pressed "y", so we play again
                return true;
            }
            else if (keyStr == "n")
            {
                // Player pressed "n", so we do NOT play again
                return false;
            }
            else
            {
                // Player entered something else than "y" or "n",
                // so ask the user again...
                Console.WriteLine("Please enter either y or n");
                return AskPlayerToPlayOrQuit();
            }
        }

        // This method can be used to get a number from the player.
        // The text given as parameter is displayed to the player.
        // The method will keep asking until the player enters a number.
        // You do not need to understand the details of this method...
        private int AskPlayerToEnterANumber(string textToShowUser)
        {
            Console.WriteLine();
            Console.Write(textToShowUser + ": ");
            string answer = Console.ReadLine();

            int number = 0;
            try
            {
                number = Int32.Parse(answer);
            }
            catch (Exception)
            {
                Console.WriteLine("Please enter a valid number...");
                AskPlayerToEnterANumber(textToShowUser);
            }

            return number;
        }
    }
}
