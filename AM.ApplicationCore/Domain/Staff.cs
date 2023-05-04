using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff:Passenger //heritage
    {
        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        [DataType(DataType.Currency)] // ajouter $
        public float Salary { get; set; }
        public override string ToString()
        {
            return base.ToString()+ "EmployementDate= "+ EmployementDate+ " , Function="+ Function+ " ,Salary = "+ Salary+"";
        }
        public override string PassengerType()
        {
            return base.PassengerType()+", and I am a staff member";
        }
    }
}
