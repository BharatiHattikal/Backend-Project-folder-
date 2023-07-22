using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultislotUsingWrapper
{
    
        class ParkingSlot
        {
            public int Lot { get; set; }
            public VehicleType Type { get; set; }
            public bool IsOccupied { get; set; }
            public string VehicleNumber { get; set; }
            public ParkingTicket Ticket { get; set; }
            public int SlotNumber { get; set; }

        }
    }
