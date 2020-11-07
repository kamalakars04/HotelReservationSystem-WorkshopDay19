using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemWorkshop
{
    class HotelReservationSystem : IAdmin
    {
        static Dictionary<string, HotelDetails> regularHotelMap = new Dictionary<string, HotelDetails>();

        public HotelReservationSystem()
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
        }

        static HotelReservationSystem()
        {
            IAdmin admin = new HotelReservationSystem();
            admin.AddNewHotel(new HotelDetails("Lakewood", 110));
            admin.AddNewHotel(new HotelDetails("Bridgewood", 150));
            admin.AddNewHotel(new HotelDetails("Ridgewood", 220));
        }

        /// <summary>
        /// UC 1 Adds the new hotel.
        /// </summary>
        /// <param name="hotel">The hotel.</param>
        public void AddNewHotel(HotelDetails hotel)
        {
            if (!regularHotelMap.ContainsKey(hotel.hotelName))
            {
                regularHotelMap.Add(hotel.hotelName,hotel);
            }
        }
    }
}
