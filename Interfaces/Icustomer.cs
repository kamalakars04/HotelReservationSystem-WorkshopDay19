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

    public interface Icustomer
    {
        List<HotelDetails> GetCheapestHotel(DateTime startDate, DateTime endDate);
        List<HotelDetails> GetCheapestBestRatedHotel(DateTime startDate, DateTime endDate);
        List<HotelDetails> GetBestRatedHotel(DateTime startDate, DateTime endDate);
    }
}
