using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    //[Owned]
    //ou bien
    //builder.OwnsOne(p=>p.FullName); dans la classe de configuration
    public class FullName
    {
        
        [MinLength(3, ErrorMessage = "Taille minimum 3")]
        [MaxLength(25, ErrorMessage = "Taille maximum 25")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //ne contient pas de cle primaire, que des types primitifs, occurence unique ( pas de list)
    }
}
