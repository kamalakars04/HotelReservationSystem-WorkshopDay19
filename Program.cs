using System;

namespace HotelReservationSystemWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            // UC 1 Add new hotel
            IAdmin admin = new HotelReservationSystem();
            admin.AddNewHotel(new HotelDetails("Lakewood", 110));
            admin.AddNewHotel(new HotelDetails("Bridgewood", 150));
            admin.AddNewHotel(new HotelDetails("Ridgewood", 220));
        }
    }
}
