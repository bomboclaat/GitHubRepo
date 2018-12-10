using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NYCTaxiFareMeter.Domain.ValueObjects;
using NYCTaxiFareMeter.Service.DataTransferObjects;

namespace NYCTaxiFareMeter.Service.Services
{
    /// <summary>
    /// Service for calculating fare.
    /// </summary>
    public class CalculationService : ICalculationService
    {
        private const double UnitCost = 0.35;
        private const double EntryFee = 3.00;
        private const double StateTax = 0.50;
        private const double NightSurcharge = 0.50;
        private const double PeakSurcharge = 1;

        /// <summary>
        /// Calculate fare.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public double CalculateFare(TripDto dto)
        {
            TripValueObject tripValueObject = Mappers.TripMapper.MapDtoToValueObject(dto);

            double fare = EntryFee + StateTax + UnitCost * (tripValueObject.Miles + tripValueObject.Minutes);

            if (tripValueObject.StartDateTime.Hour > 20 || tripValueObject.StartDateTime.Hour < 6)
                fare =+ NightSurcharge;
            else if ((tripValueObject.StartDateTime.DayOfWeek != DayOfWeek.Saturday && tripValueObject.StartDateTime.DayOfWeek != DayOfWeek.Sunday)
                && (tripValueObject.StartDateTime.Hour > 16 && tripValueObject.StartDateTime.Hour < 20))
                fare =+ PeakSurcharge;

            return fare;
        }
    }
}