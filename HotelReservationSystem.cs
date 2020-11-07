// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystemWorkshop
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class HotelReservationSystem : IAdmin,Icustomer
    {
        static Dictionary<string, HotelDetails> regularHotelMap = new Dictionary<string, HotelDetails>();

        public HotelReservationSystem()
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
        }

        /// <summary>
        /// uc 9 Initializes a new instance of the <see cref="HotelReservationSystem"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="HotelReservationException">INVALID CUSTOMER TYPE</exception>
        public HotelReservationSystem(CustomerType type)
        {
            IAdmin admin;
            switch (type)
            {
                case CustomerType.REGULAR_CUSTOMER:
                    regularHotelMap.Clear();
                    admin = new HotelReservationSystem();
                    admin.AddNewHotel(new HotelDetails("Lakewood", 110, 90, 3));
                    admin.AddNewHotel(new HotelDetails("Bridgewood", 150, 50, 4));
                    admin.AddNewHotel(new HotelDetails("Ridgewood", 220, 150, 5));
                    break;

                case CustomerType.REWARD_CUSTOMER:
                    regularHotelMap.Clear();
                    admin = new HotelReservationSystem();
                    admin.AddNewHotel(new HotelDetails("Lakewood", 80, 80, 3));
                    admin.AddNewHotel(new HotelDetails("Bridgewood", 110, 50, 4));
                    admin.AddNewHotel(new HotelDetails("Ridgewood", 100, 40, 5));
                    break;

                default:
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "INVALID CUSTOMER TYPE");
            }
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

        /// <summary>
        /// UC 6 Gets the cheapest best rated hotel.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <exception cref="HotelReservationException">startDate is after endDate</exception>
        public List<HotelDetails> GetCheapestBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            List<HotelDetails> hotelOutput = new List<HotelDetails>();
            double costOfPresentHotel = 0;
            double totalFare = 0;
            double ratings = 0;

            // Check for proper start and end date
            if (startDate > endDate)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE_RANGE, "startDate is after endDate");
            }

            // Iterate through all the hotels
            foreach (KeyValuePair<string, HotelDetails> hotel in regularHotelMap)
            {
                // Calculate total fare of each hotel
                costOfPresentHotel = hotel.Value.GetTotalFare(startDate, endDate);

                // If the cost of present hotel is less than previous 
                if (costOfPresentHotel.CompareTo(totalFare) < 0 || totalFare == 0)
                {
                    hotelOutput.Clear();
                    hotelOutput.Add(hotel.Value);
                    totalFare = costOfPresentHotel;
                    ratings = hotel.Value.ratings;
                }

                // If the cost of hotel is equal to least cost
                else if (costOfPresentHotel.CompareTo(totalFare) == 0)
                {
                    if(hotel.Value.ratings > ratings)
                    {
                        hotelOutput.Clear();
                        hotelOutput.Add(hotel.Value);
                    }
                    if(hotel.Value.ratings == ratings)
                        hotelOutput.Add(hotel.Value);
                }
            }
            return hotelOutput;
        }

        /// <summary>
        /// UC 7 Gets the best rated hotel.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <exception cref="HotelReservationException">startDate is after endDate</exception>
        public List<HotelDetails> GetBestRatedHotel(DateTime startDate, DateTime endDate)
        {
            List<HotelDetails> hotelOutput = new List<HotelDetails>();
            double ratings = 0;

            // Check for proper start and end date
            if (startDate > endDate)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE_RANGE, "startDate is after endDate");
            }

            // Iterate through all the hotels
            foreach (KeyValuePair<string, HotelDetails> hotel in regularHotelMap)
            {
                // If rating is greater or first element in dictionary
                if (hotel.Value.ratings > ratings || ratings == 0)
                {
                    hotelOutput.Clear();
                    hotelOutput.Add(hotel.Value);
                    hotel.Value.GetTotalFare(startDate, endDate);
                }

                // If rating is equal to highrst rating
                else if (hotel.Value.ratings == ratings)
                    hotelOutput.Add(hotel.Value);
            }
            return hotelOutput;
        }
    }
}
