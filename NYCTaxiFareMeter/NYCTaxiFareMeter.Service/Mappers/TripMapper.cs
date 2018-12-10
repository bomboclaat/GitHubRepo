using NYCTaxiFareMeter.Domain.ValueObjects;
using NYCTaxiFareMeter.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NYCTaxiFareMeter.Service.Mappers
{
    /// <summary>
    /// Contains mappers for Trip objects.
    /// </summary>
    public static class TripMapper
    {
        /// <summary>
        /// Map <see cref="TripDto"/> to <see cref="TripValueObject"/>.
        /// </summary>
        /// <param name="TripDto"></param>
        /// <returns></returns>
        public static TripValueObject MapDtoToValueObject(TripDto tripViewModel)
        {
            return TripValueObject.Create(tripViewModel.StartDateTime, tripViewModel.Miles, tripViewModel.Minutes);
        }
    }
}