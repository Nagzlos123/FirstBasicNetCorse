﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApp
{
    class Reservation
    {
        public Reservation(DateTime @from, DateTime to)
        {
            From = @from;
            To = to;
        }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}