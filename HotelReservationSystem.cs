using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemWorkshop
{
    public class HotelReservationSystem : IAdmin,Icustomer
    {
        static Dictionary<string, HotelDetails> regularHotelMap = new Dictionary<string, HotelDetails>();

        public HotelReservationSystem()
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
        }

        static HotelReservationSystem()
        {
            IAdmin admin = new HotelReservationSystem();
            admin.AddNewHotel(new HotelDetails("Lakewood", 110,90));
            admin.AddNewHotel(new HotelDetails("Bridgewood", 150,50));
            admin.AddNewHotel(new HotelDetails("Ridgewood", 220,150));
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

        /// <summary>
        /// UC 2 Gets the cheapest hotel.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <exception cref="HotelReservationException">startDate is after endDate</exception>
        public List<HotelDetails> GetCheapestHotel(DateTime startDate, DateTime endDate)
        {
            List<HotelDetails> hotelOutput = new List<HotelDetails>();
            double costOfPresentHotel = 0;
            double totalFare = 0;

            // Check for proper start and end date
            if (startDate > endDate)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE_RANGE, "startDate is after endDate");
            }

            // Iterate through all the hotels
            foreach (KeyValuePair<string, HotelDetails> hotel in regularHotelMap)
            {
                // Calculate total fare of each hotel
                costOfPresentHotel = hotel.Value.GetTotalFare(startDate,endDate);

                // If the cost of present hotel is less than previous 
                if (costOfPresentHotel.CompareTo(totalFare) < 0 || totalFare == 0)
                {
                    hotelOutput.Clear();
                    hotelOutput.Add(hotel.Value);
                    totalFare = costOfPresentHotel;
                }
                
                // If the cost of hotel is equal to least cost
                else if(costOfPresentHotel.CompareTo(totalFare) == 0)
                {
                    hotelOutput.Add(hotel.Value);
                }
            }
            return hotelOutput;
        }
    }
}
