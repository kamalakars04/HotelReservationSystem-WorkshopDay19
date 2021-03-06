// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright � 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationMSTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using HotelReservationSystemWorkshop;
    using System.Collections.Generic;
    using System;

    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// TC 2 Gives the date range for normal customer.
        /// </summary>
        [TestMethod]
        public void GiveDateRangeForNormalCustomer()
        {
            //Arrange
            HotelDetails expectedHotel = new HotelDetails("Lakewood", 110, 150,3);
            expectedHotel.GetTotalFare(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11));

            // Act
            Icustomer customer = new HotelReservationSystem(CustomerType.REGULAR_CUSTOMER);
            List<HotelDetails> actual = customer.GetCheapestHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11));
            List<HotelDetails> expected = new List<HotelDetails> {expectedHotel};
            

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 4 Gives the date range for normal customer get cheapest hotel.
        /// </summary>
        [TestMethod]
        public void GiveDateRangeForNormalCustomerGetCheapestHotel()
        {
            //Arrange
            List<HotelDetails> expected = new List<HotelDetails> { new HotelDetails("Lakewood", 110, 90,3) ,
                                                                   new HotelDetails("Bridgewood", 150, 50,4) };
            expected.ForEach(hotel => hotel.GetTotalFare(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12)));

            // Act
            Icustomer customer = new HotelReservationSystem(CustomerType.REGULAR_CUSTOMER);
            List<HotelDetails> actual = customer.GetCheapestHotel(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 6 Gives the date range for normal customer get cheapest best rated hotel.
        /// </summary>
        [TestMethod]
        public void GiveDateRangeForNormalCustomerGetCheapestBestRatedHotel()
        {
            //Arrange
            List<HotelDetails> expected = new List<HotelDetails> { new HotelDetails("Bridgewood", 150, 50, 4) };
            expected.ForEach(hotel => hotel.GetTotalFare(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12)));

            // Act
            Icustomer customer = new HotelReservationSystem(CustomerType.REGULAR_CUSTOMER);
            List<HotelDetails> actual = customer.GetCheapestBestRatedHotel(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 7 Gives the date range for normal customer best rated hotel.
        /// </summary>
        [TestMethod]
        public void GiveDateRangeForNormalCustomerBestRatedHotel()
        {
            //Arrange
            List<HotelDetails> expected = new List<HotelDetails> { new HotelDetails("Ridgewood", 220, 150, 4) };
            expected.ForEach(hotel => hotel.GetTotalFare(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12)));

            // Act
            Icustomer customer = new HotelReservationSystem(CustomerType.REGULAR_CUSTOMER);
            List<HotelDetails> actual = customer.GetBestRatedHotel(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GiveDateRangeForRewardCustomerGetCheapestBestRatedHotel()
        {
            //Arrange
            List<HotelDetails> expected = new List<HotelDetails> { new HotelDetails("Ridgewood", 100, 40, 5) };
            expected.ForEach(hotel => hotel.GetTotalFare(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12)));

            // Act
            Icustomer customer = new HotelReservationSystem(CustomerType.REWARD_CUSTOMER);
            List<HotelDetails> actual = customer.GetCheapestBestRatedHotel(new DateTime(2020, 09, 11), new DateTime(2020, 09, 12));

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
