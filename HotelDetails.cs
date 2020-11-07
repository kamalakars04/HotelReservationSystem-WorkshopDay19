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
        double costOnWeekDay;
        double costOnWeekEnd;
        public double ratings;

        /// <summary>
        /// Initializes a new instance of the <see cref="HotelDetails"/> class.
        /// </summary>
        /// <param name="hotelName">Name of the hotel.</param>
        /// <param name="costPerDay">The cost per day.</param>
        public HotelDetails(string hotelName, double costOnWeekDay, double costOnWeekEnd, double ratings)
        {
            this.hotelName = hotelName;
            this.costOnWeekDay = costOnWeekDay;
            this.costOnWeekEnd = costOnWeekEnd;
            this.ratings = ratings;
        }

        /// <summary>
        /// UC 2 Gets the total fare.
        /// UC 3 Refactor the code to include weekDay and weekEnd rates
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        public double GetTotalFare(DateTime startDate, DateTime endDate)
        {
            double presentFare = 0;
            // Continue loop till all the dates are covered
            while (startDate != endDate.AddDays(1))
            {
                // if the dya is weekend take cost of week end
                // else take cost of week day
                if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    presentFare += costOnWeekEnd;
                }
                else
                    presentFare += costOnWeekDay;
                startDate = startDate.AddDays(1);
            }
            totalFare = presentFare;
            return totalFare;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            // If obj passed is null
            if (obj == null)
                return false;

            // If object passed is of other datatype
            if (!(obj is HotelDetails))
                return false;

            // Convert the obj into Hotel Details object
            HotelDetails hotelOutput = ((HotelDetails)obj);

            // return true if hotel name are same else false
            return this.hotelName == hotelOutput.hotelName && this.totalFare == hotelOutput.totalFare;
        }
    }
}
