using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystemWorkshop

{
    public interface Icustomer
    {
        List<HotelDetails> GetCheapestHotel(DateTime startDate, DateTime endDate);
        List<HotelDetails> GetCheapestBestRatedHotel(DateTime startDate, DateTime endDate);
    }
}
