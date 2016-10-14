using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CasinoSimulator
{
    class Program
    {
        // The main method just starts up the slot machine manager, which takes
        // care of running the slot machine simulation
        static void Main(string[] args)
        {
            Console.WriteLine("Casino Simulator Starting...");
            Console.WriteLine();

            // Start up the slot machine simulation
            SlotMachineManager theManager = new SlotMachineManager();
            theManager.RunSimulation();

            Console.WriteLine("Casino Simulator Ending (press any key to close program)...");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
