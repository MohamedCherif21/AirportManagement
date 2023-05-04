using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces;

public interface IServiceFlight:IService<Flight>
{
    public IList<DateTime> GetFlightDates(string destination);
    public void GetFlights(string filterType, string filterValue);
    public void ShowFlightDetails(Plane plane);
    public int ProgrammedFlightNumber(DateTime startDate);
    public double DurationAverage(string destination);
    public IList<Flight> OrdredDurationFlights();
    public IList<Passenger> SeniorTravellers(Flight flight);
    public void DestinationGroupedFlights();
}
