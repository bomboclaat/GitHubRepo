using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NYCTaxiFareMeter.Service.DataTransferObjects;

namespace NYCTaxiFareMeter.Service.Services
{
    /// <summary>
    /// Service for calculating fare.
    /// </summary>
    public interface ICalculationService
    {
        /// <summary>
        /// Calculate fare.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        double CalculateFare(TripDto dto);
    }
}
