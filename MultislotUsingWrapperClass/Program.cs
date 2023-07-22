using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultislotUsingWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLotWrapper parkingLotWrapper = new ParkingLotWrapper();

            Console.Write("Enter the number of slots in the parking lot: ");
            int numberOfSlots = int.Parse(Console.ReadLine() ?? "0");

            parkingLotWrapper.Initialization(numberOfSlots);
            parkingLotWrapper.DisplayMenu();
        }
    }
}