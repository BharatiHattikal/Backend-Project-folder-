
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultislotUsingWrapper
{
    class ParkingLotWrapper
    {
        private ParkingLot parkingLot;

        public ParkingLotWrapper()
        {
            parkingLot = new ParkingLot();
        }

        public void Initialization(int numberOfSlots)
        {
            parkingLot.Initialization(numberOfSlots);
        }

        public void DisplayOccupancyDetails()
        {
            Console.WriteLine("Occupancy Details for Parking Slots:");

            foreach (var slot in parkingLot.Slots)
            {
                Console.WriteLine($"Lot: {slot.Lot}, Slot Number: {slot.SlotNumber}, Type: {slot.Type}, Occupied: {slot.IsOccupied}, Vehicle Number: {slot.VehicleNumber}");
            }
        }


        public void DisplayMenu()
        {
            parkingLot.DisplayMenu();
        }
    }
}
