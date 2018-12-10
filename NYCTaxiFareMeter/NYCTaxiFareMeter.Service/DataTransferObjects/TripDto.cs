using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYCTaxiFareMeter.Service.DataTransferObjects
{
    /// <summary>
    /// Data transfer object containing trip data.
    /// </summary>
    public class TripDto
    {
        /// <summary>
        /// Time and date ride started.
        /// </summary>
        public DateTime StartDateTime { get; set; }

        /// <summary>
        /// Trip mileage while driving under 6 mph in units of 1/5 of a mile. 
        /// </summary>
        public int Miles { get; set; }

        /// <summary>
        /// Trip time while not in motion or traveling at 6 miles per hour or more.
        /// </summary>
        public int Minutes { get; set; }
    }
}