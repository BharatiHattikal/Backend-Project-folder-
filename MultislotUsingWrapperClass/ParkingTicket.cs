using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultislotUsingWrapper
{

        enum VehicleType
        {

            TwoWheeler,
            FourWheeler,
            HeavyVehicle

        }

        class ParkingTicket
        {
            private static int ticketCounter = 0;
            public int TicketNumber { get; set; }
            public string VehicleNumber { get; set; }
            public int SlotNumber { get; set; }
            public DateTime InTime { get; set; }
            public DateTime OutTime { get; set; }

            public ParkingTicket()
            {
                ticketCounter++;
                TicketNumber = ticketCounter;
            }
        }

    }
