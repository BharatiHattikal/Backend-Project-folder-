using System;
using System.Text.RegularExpressions;

namespace MultislotUsingWrapper
{

    class ParkingLot
    {
        public List<ParkingSlot> Slots { get; private set; }

          public void Initialization(int numberOfSlots)
            {
                Slots = new List<ParkingSlot>();
                int slotNumber = 1;

                for (int i = 1; i <= numberOfSlots; i++)
                {
                    Console.WriteLine("Enter details for Slot " + i);
                    Console.Write("Enter the number of TwoWheeler slots: ");
                    int twoWheelerSlots = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter the number of FourWheeler slots: ");
                    int fourWheelerSlots = int.Parse(Console.ReadLine() ?? "0");
                    Console.Write("Enter the number of HeavyVehicle slots: ");
                    int heavyVehicleSlots = int.Parse(Console.ReadLine() ?? "0");

                    for (int j = 0; j < twoWheelerSlots; j++)
                    {
                        Slots.Add(new ParkingSlot { SlotNumber = slotNumber++, Lot = i, Type = VehicleType.TwoWheeler });
                    }

                    for (int j = 0; j < fourWheelerSlots; j++)
                    {
                        Slots.Add(new ParkingSlot { SlotNumber = slotNumber++, Lot = i, Type = VehicleType.FourWheeler });
                    }

                    for (int j = 0; j < heavyVehicleSlots; j++)
                    {
                        Slots.Add(new ParkingSlot { SlotNumber = slotNumber++, Lot = i, Type = VehicleType.HeavyVehicle });
                    }
                }
            }

            public void DisplayMenu()
            {
                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("1. Display Parking Lot Details");
                    Console.WriteLine("2. Park a Vehicle");
                    Console.WriteLine("3. Unpark a Vehicle");
                    Console.WriteLine("4. Exit");

                    int choice;
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    switch (choice)
                    {
                        case 1:
                            DisplayOccupancyDetails();
                            break;
                        case 2:
                            ParkVehicle();
                            break;
                        case 3:
                            UnparkVehicle();
                            break;
                        case 4:
                            Console.WriteLine("Thank you!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid Choice.");
                            break;
                    }
                }
            }

            public void DisplayOccupancyDetails()
            {
                Console.WriteLine("Occupancy Details for Parking Slots:");

                foreach (var slot in Slots)
                {
                    Console.WriteLine("Lot:" + slot.Lot + ": Slot " + slot.SlotNumber + ":" + slot.Type + " :" + (slot.IsOccupied ? "Occupied" : "Empty"));
                }
            }

            public bool ValidateVehicleNumber(string vehicleNumber)
            {
                string pattern = @"^[a-zA-Z]{2}\d{2}[a-zA-Z]{2}\d{4}$";
                bool valid = Regex.IsMatch(vehicleNumber, pattern);
                return valid;
            }

            

          public void ParkVehicle()
        {
            Console.WriteLine("Enter the vehicle number:");
            string vehicleNumber = Console.ReadLine() ?? "0";

            if (!ValidateVehicleNumber(vehicleNumber))
            {
                Console.WriteLine("Invalid vehicle number.");
                ParkVehicle();
                return;
            }
            Console.WriteLine("Enter the vehicle type");
            Console.WriteLine("1.TwoWheeler");
            Console.WriteLine("2.FourWheeler");
            Console.WriteLine("3. HeavyVehicle");
            Console.WriteLine("Enter the vehicle type");
            int vehicleTypeChoice = int.Parse(Console.ReadLine() ?? "0");
            VehicleType vehicleType;
            switch (vehicleTypeChoice)
            {
                case 1:
                    vehicleType = VehicleType.TwoWheeler;
                    break;
                case 2:
                    vehicleType = VehicleType.FourWheeler;
                    break;
                case 3:
                    vehicleType = VehicleType.HeavyVehicle;
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type.");
                    return;
            }
            ParkingSlot availableSlot = null;
            availableSlot = Slots.FirstOrDefault(slot => slot.Type == vehicleType && !slot.IsOccupied);

            if (availableSlot != null)
            {
                availableSlot.IsOccupied = true;
                availableSlot.VehicleNumber = vehicleNumber;
                availableSlot.Ticket = new ParkingTicket
                {
                    VehicleNumber = vehicleNumber,
                    SlotNumber = availableSlot.Lot,
                    InTime = DateTime.Now
                };
                Console.WriteLine("Vehicle parked successfully");
                Console.WriteLine("Vehicle Number: " + vehicleNumber);
                Console.WriteLine("LotNumber: " + availableSlot.Lot);
                Console.WriteLine("Slot Number: " + availableSlot.SlotNumber);
                Console.WriteLine("Ticket Number: " + availableSlot.Ticket.TicketNumber);
                Console.WriteLine("In Time: " + availableSlot.Ticket.InTime);
            }
            else
            {
                Console.WriteLine("No available slot found for the vehicle type.");
            }
        }
        public void UnparkVehicle()
        {
            Console.WriteLine("Enter the Ticket number:");
            int ticketNumber;
            if (int.TryParse(Console.ReadLine(), out ticketNumber))
            {
                ParkingSlot occupiedSlot = null;

                occupiedSlot = Slots.FirstOrDefault(slot => slot.IsOccupied && slot.Ticket != null && slot.Ticket.TicketNumber == ticketNumber);

                if (occupiedSlot != null)
                {
                    occupiedSlot.IsOccupied = false;
                    occupiedSlot.Ticket.OutTime = DateTime.Now;

                    Console.WriteLine("Vehicle unparked successfully");
                    Console.WriteLine("Ticket Number: " + ticketNumber);
                    Console.WriteLine("Vehicle Number: " + occupiedSlot.Ticket.VehicleNumber);
                    Console.WriteLine("Lot Number: " + occupiedSlot.Lot);
                    Console.WriteLine("Slot Number: " + occupiedSlot.SlotNumber);
                    Console.WriteLine("In Time: " + occupiedSlot.Ticket.InTime);
                    Console.WriteLine("Out Time: " + occupiedSlot.Ticket.OutTime);
                }
                else
                {
                    Console.WriteLine("Invalid ticket number");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid ticket number");
            }
        }
    }
}









