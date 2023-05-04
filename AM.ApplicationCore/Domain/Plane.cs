using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boing,Airbus}
    public class Plane
    {
        private PlaneType planeType;
        //ctor+ 2tab
        public Plane()
        {

        }
        public Plane(int capacity, DateTime manufactureDate, int planeId, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneId = planeId;
            PlaneType = planeType;
        }

        //prop + 2tab
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }
        /* //propfull+2tab
         private int myVar;

         public int MyProperty
         {
             get { return myVar; }
             set { myVar = value; }
         }
         //propg+2tab
         public int MyProperty2 { get; private set; }*/
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public PlaneType PlaneType { get; set; }

        //propriete de navigation 
        //OneToMany avec Flight
        public virtual IList<Flight> Flights { get; set; }

        //reimplementation de ToString override ToString
        public override string ToString()
        {
            return "Capacity =" + Capacity + " ,ManufactureDate = " + ManufactureDate + " , PlaneId = " + PlaneId + " , PlaneType =" + PlaneType + "" ;
        }


    }
}
