﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookedReservations = GetBookedReservations();
            DisplayReservations(bookedReservations);

            Console.WriteLine("Insert new booking start date: (yyyy-MM-dd)");

            string startDateString = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", null);

            Console.WriteLine("Insert new booking end date: (yyyy-MM-dd)");
            string endDateString = Console.ReadLine();
            DateTime endDate = DateTime.ParseExact(endDateString, "yyyy-MM-dd", null);

            bool isNewReservationPossible = IsNewReservationPossible(startDate, endDate, bookedReservations);

            if (isNewReservationPossible)
            {
                Console.WriteLine("Reservation booked");
            }
            else
            {
                Console.WriteLine("Select other booking dates");
            }
        }

        static bool IsNewReservationPossible(DateTime startDate, DateTime endDate, List<Reservation> bookedReservations)
        {
            //TODO: Implement the logic
            foreach (var bookedReservtion in bookedReservations)
            {
                if (startDate.Date >= bookedReservtion.From.Date && startDate.Date <= bookedReservtion.To.Date 
                    || endDate.Date >= bookedReservtion.From.Date && endDate.Date <= bookedReservtion.To.Date)
                {
                    return false;
                }

                if(startDate.Date <= bookedReservtion.From.Date && endDate.Date >= bookedReservtion.To.Date)
                {
                    return false;
                }
            }

            return true;
        }

        static void DisplayReservations(List<Reservation> bookedReservations)
        {
            Console.WriteLine("Booked reservations:");
            foreach (var bookedReservation in bookedReservations)
            {
                Console.WriteLine($"From: {bookedReservation.From.ToString("yyyy-MM-dd")}, To: {bookedReservation.To.ToString("yyyy-MM-dd")}");
            }
        }

        static List<Reservation> GetBookedReservations()
        {
            var reservations = new List<Reservation>()
            {
                new Reservation(new DateTime(2021, 6, 10), new DateTime(2021, 6, 12)),
                new Reservation(new DateTime(2021, 6, 19), new DateTime(2021, 6, 20)),
                new Reservation(new DateTime(2021, 6, 24), new DateTime(2021, 6, 26)),
                new Reservation(new DateTime(2021, 7, 24), new DateTime(2021, 7, 25)),
            };

            return reservations;
        }
    }
    
}
