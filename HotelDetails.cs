using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemWorkshop
{
    public class HotelDetails
    {
        // Variables
        public string hotelName;
        public double totalFare;
        int costPerDay;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelDetails"/> class.
        /// </summary>
        /// <param name="hotelName">Name of the hotel.</param>
        /// <param name="costPerDay">The cost per day.</param>
        public HotelDetails(string hotelName, int costPerDay)
        {
            this.hotelName = hotelName;
            this.costPerDay = costPerDay;
        }
    }
}
