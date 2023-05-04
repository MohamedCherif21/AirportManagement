using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;


namespace AM.ApplicationCore.Services;

public class ServicePlane :Service<Plane>, IServicePlane
{
    private readonly IUnitOfWork unitOfWork;
    public ServicePlane(IUnitOfWork utk):base(utk)
    {
        unitOfWork = utk;
    }

    public bool AvailablePlane(Flight flight, int n)
    {
        int capacity = Get(p => p.Flights.Contains(flight) == true).Capacity;
        int nbPassengers = flight.Tickets.Count();
        return capacity >= (nbPassengers + n);
    }

    public void DeletePlanes()
    {
        Delete(p=>p.ManufactureDate.AddYears(10)<=DateTime.Now);
        
    }

    public IList<IGrouping<int, Flight>> GetFlights(int n)
    {
        return GetAll().OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p =>
        p.Flights).GroupBy(f => f.Plane.PlaneId).ToList();
    }

    public IList<Passenger> GetPassengers(Plane plane)
    {
        return plane.Flights.SelectMany(f => f.Tickets.Select(t =>
        t.Passenger)).ToList();
    }
}
