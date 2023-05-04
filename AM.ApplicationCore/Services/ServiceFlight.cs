using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services;

public class ServiceFlight:Service<Flight>,IServiceFlight
{
    public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
    #region Tp1+Tp2
    public List<Flight> Flights { get; set; }=new List<Flight>();

    public IList<DateTime> GetFlightDates(string destination)
    {
        List<DateTime> ls = new List<DateTime>();

        //CLASSIQUE
        //for (int j = 0; j < Flights.Count; j++)
        //    if (Flights[j].Destination.Equals(destination))
        //        ls.Add(Flights[j].FlightDate);

        //foreach (Flight f in Flights)
        //{
        //    if (f.Destination == destination)
        //    {
        //        ls.Add(f.FlightDate);
        //    }
        //}
        //return ls;

        //LINQ
        //var query =from flight in Flights
        //           where flight.Destination == destination
        //           select flight.FlightDate;
        //return query.ToList();
        
        //LAMBDA

        return Flights.Where(f=>f.Destination == destination).Select(f=>f.FlightDate).ToList(); 

        
    }
    public void GetFlights(string filterType, string filterValue)
    {
        switch (filterType)
        {
            case "Destination":
                foreach (Flight f in Flights)
                {
                    if (f.Destination.Equals(filterValue))
                        Console.WriteLine(f);
                }
                break;
            case "FlightDate":
                foreach (Flight f in Flights)
                {
                    if (f.FlightDate == DateTime.Parse(filterValue))
                        Console.WriteLine(f);
                }
                break;
            case "EffectiveArrival":
                foreach (Flight f in Flights)
                {
                    if (f.EffectiveArrival == DateTime.Parse(filterValue))
                        Console.WriteLine(f);
                }
                break;
        }
    }
    public void ShowFlightDetails(Plane plane)
    {
        //LINQ
        //var query=from f in Flights
        //          where f.Plane == plane
        //          select new { f.Destination, f.FlightDate };

        //LAMBDA
        var query=Flights.Where(f=>f.Plane== plane).Select(f=>new { f.FlightDate, f.Destination });
        foreach (var f in query) 
        Console.WriteLine("flight destination:"+f.Destination+"flight date: "+f.FlightDate);
    }
    public int ProgrammedFlightNumber(DateTime startDate)
    {
        var query = from f in Flights
                    where f.FlightDate > startDate && f.FlightDate < startDate.AddDays(7)
                    select f;
        return query.Count(); 
    }
    public double DurationAverage(string destination)
    {
       var query = from f in Flights
                    where f.Destination==destination
                    select f.EstimatedDuration;
        /*return query.Average();*/
        if (query != null)
        {
            return Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);
        }
        throw new Exception("No Flights Found !!");
    }
    public IList<Flight> OrdredDurationFlights()
    {
        return (from f in Flights
                orderby f.EstimatedDuration descending
                select f).ToList();
    }
    public IList<Passenger> SeniorTravellers(Flight flight)
    {
        return (from p in flight.Passengers
                orderby p.BirthDate ascending
                select p).Take(3).ToList();
    }
    public void DestinationGroupedFlights()
    {
        var query = from f in Flights
                    group f by f.Destination;
        foreach (var f in query)
        {
            Console.WriteLine("Destination =" + f.Key);
            foreach (var item in f)
                Console.WriteLine("Décollage: " + item.FlightDate);

        }
    }
    #endregion
    #region delegate
    //public Action<Plane> FlightDetailsDel;
    //public Func<string, double> DurationAverageDel;
    //public ServiceFlight()
    //{
    //    //DurationAverageDel = DurationAverage;
    //    DurationAverageDel = dest =>
    //    {
    //        return (from f in Flights
    //                where f.Destination.Equals(dest)
    //                select f.EstimatedDuration).Average();
    //    };
    //    //FlightDetailsDel = ShowFlightDetails;
    //    FlightDetailsDel = p =>
    //    {
    //        var req = from f in Flights
    //                  where f.Plane == p
    //                  select new { f.FlightDate, f.Destination };
    //        foreach (var v in req)
    //            Console.WriteLine("Flight Date; " + v.FlightDate + " Flight destination: " + v.Destination);
    //    };
    //}
    #endregion
}
