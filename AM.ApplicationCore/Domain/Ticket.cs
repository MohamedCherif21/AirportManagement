using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Price { get; set; }
        public bool VIP { get; set; }
        public int Siege { get; set; }
        public string PassengerFk { get; set; }
        public int FlightFk { get; set; }
        //prop de navig
        public virtual Flight Flight { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
