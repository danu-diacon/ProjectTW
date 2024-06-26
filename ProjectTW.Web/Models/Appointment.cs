﻿using ProjectTW.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTW.Web.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }
    }
}