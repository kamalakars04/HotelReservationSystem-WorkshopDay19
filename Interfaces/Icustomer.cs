using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservationSystem
{
    public interface Icustomer
    {
        HotelOutput GetCheapestHotel(DateTime startDate, DateTime endDate);
    }
}
