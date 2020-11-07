using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservationSystemWorkshop;
using System.Collections.Generic;
using System;

namespace HotelReservationMSTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// UC 2 Gives the date range for normal customer.
        /// </summary>
        [TestMethod]
        public void GiveDateRangeForNormalCustomer()
        {
            // Act
            Icustomer customer = new HotelReservationSystem();
            List<HotelDetails> actual = customer.GetCheapestHotel(new DateTime(2020, 09, 10), new DateTime(2020, 09, 11));
            List<HotelDetails> expected = new List<HotelDetails> { new HotelDetails("Lakewood", 220) };

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
