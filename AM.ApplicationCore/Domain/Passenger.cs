using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key] //primary key
        [StringLength(7)] // fixed length
        public string PasseportNumber { get; set; }

        [Display(Name ="Date of birth"), DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string EmailAddress { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string PhoneNumber { get; set; }

        //[MinLength(3,ErrorMessage ="Taille minimum 3")]
        //[MaxLength(25, ErrorMessage = "Taille maximum 25")]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public FullName FullName { get; set; }

        //propriete de navigation
        //ManyToMany avec flight
        public virtual IList<Flight> Flights { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }
        public override string ToString()
        {
            return "BirthDate = " + BirthDate + " , PassportNumber = " + PasseportNumber + " , EmailAddress = " + EmailAddress + ", FirstName = " + FullName.FirstName + " ,  LastName = " + FullName.LastName + " , PhoneNumber = " + PhoneNumber + "";
        }
        public bool CheckProfile(string firstName,string lastName)
        {
            if(this.FullName.FirstName==firstName && this.FullName.LastName==lastName) return true;
            return false;
            //return this.FirstName==firstName && this.LastName== lastName;
        }
        public bool CheckProfile(string firstName, string lastName,string email)
        {
            if (this.FullName.FirstName == firstName && this.FullName.LastName == lastName && this.EmailAddress==email) return true;
            return false;
            //return this.FirstName==firstName && this.LastName== lastName&& this.EmailAddress== emaillastName;
        }
        public virtual string PassengerType()
        {
            return "I am a passenger";
        }
       
    }
}
