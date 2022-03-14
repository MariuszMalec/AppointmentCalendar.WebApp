using AppointmentCalendar.BLL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Models
{
    public  class UserView : Entity
    {

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide last name")]
        [StringLength(25)]
        public string LastName { get; set; }
    }
}
