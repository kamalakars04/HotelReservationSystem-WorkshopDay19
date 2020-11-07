// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace HotelReservationSystemWorkshop
{
    using System;
    using System.Runtime.Serialization;

    public class HotelReservationException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DATE_RANGE
        }

        public ExceptionType type;
        public HotelReservationException(ExceptionType type,string message) : base(message)
        {
            this.type = type;
        }
    }
}