﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCalendar.BLL.Entities
{
    public class Person : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
