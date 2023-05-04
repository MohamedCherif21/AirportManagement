// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using System.Net.WebSockets;
//cwl + 2tab
#region TP1
//avec constructeur vide
Plane plane1 = new Plane();
plane1.Capacity = 200;
plane1.PlaneType = PlaneType.Airbus;
plane1.ManufactureDate = DateTime.Now;
Console.WriteLine("Plane 1 information = " + plane1.ToString());
//avec constructeur parametré
Plane plane2 = new Plane(150, DateTime.Now, 1, PlaneType.Boing);
Console.WriteLine("Plane 2 information = " + plane2.ToString());
//avec initialiseur d'objet
Plane plane3 = new Plane
{
    Capacity = 200,
    PlaneType = PlaneType.Airbus,
    ManufactureDate = new DateTime(2023, 12, 30),
};
Console.WriteLine("Plane 3 information = " + plane3.ToString());
Passenger passenger = new Passenger()
{
    FullName = new FullName
    {
        FirstName = "Ameni",
        LastName = "Belhadj"
    },
    BirthDate = new DateTime(1999, 08, 15),
    EmailAddress = "ameni.belhadj@esprit.tn",
    PasseportNumber = "152525236",
    PhoneNumber = "+2163333333"
};
Staff staff = new Staff()
{
    FullName = new FullName
    {
        FirstName = "Meriem",
        LastName = "Elleuch"
    },
    BirthDate = new DateTime(2020, 10, 20),
    Function = "Pilote",
    PasseportNumber = "21321321",
    Salary = 10000,
    EmployementDate = new DateTime(2023, 1, 10),
    PhoneNumber = "+2165858585",
    EmailAddress = "ganounou@esprit.tn"
};
Console.WriteLine("first passenger is: " + passenger.PassengerType());
Console.WriteLine("second passenger is: " + staff.PassengerType());
#endregion
//#region TP2
//ServiceFlight sf = new ServiceFlight();
//sf.Flights = TestData.listFlights;
//Console.WriteLine("La fonction GetFlightDates :");
//Console.WriteLine();
//sf.GetFlightDates("Paris");

//Console.WriteLine("La fonction GetFlights :");
//Console.WriteLine();
//sf.GetFlights("Destination", "Paris");

//Console.WriteLine("La fonction DestinationGroupedFlights :");
//Console.WriteLine();
//sf.DestinationGroupedFlights();

///**Console.WriteLine("La fonction ShowFlightDetails :");
//Console.WriteLine();
//sf.ShowFlightDetails(plane: new Plane(PlaneType.Boing));*/

//Console.WriteLine("La fonction ProgrammedFlightNumber :");
//Console.WriteLine();
//sf.ProgrammedFlightNumber(new DateTime(2015, 02, 03));

//Console.WriteLine("La fonction DurationAverage :");
//Console.WriteLine();
//sf.DurationAverage("Madrid");

//Console.WriteLine("La fonction OrderDurationFlights :");
//Console.WriteLine();
//sf.OrdredDurationFlights();

//Console.WriteLine("La fonction DestinationGroupedFlights :");
//Console.WriteLine();
//sf.DestinationGroupedFlights();

//#endregion
#region  Services spécifiques
Console.WriteLine("***************************************************************");
AMContext ctx = new AMContext();
IUnitOfWork utk = new UnitOfWork(ctx);
IServicePlane servicePlane = new ServicePlane(utk);

Plane p = new Plane()
{
    Capacity=200,
    PlaneType=PlaneType.Boing,
    ManufactureDate=new DateTime(2000,10,10)
};
Plane p2 = new Plane()
{
    Capacity = 150,
    PlaneType = PlaneType.Airbus,
    ManufactureDate = new DateTime(2020, 10, 10)
};
//ajout dans la base
servicePlane.Add(p);
servicePlane.Add(p2);
servicePlane.Commit();
foreach (Plane plane in servicePlane.GetAll())
{
    Console.WriteLine("plane capacity ="+p.Capacity);
}
//tester la méthode delete
servicePlane.DeletePlanes();
servicePlane.Commit();
foreach (Plane plane in servicePlane.GetAll())
{
    Console.WriteLine("new plane capacity =" + p.Capacity);
}
Console.ReadKey();
#endregion