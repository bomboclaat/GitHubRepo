using NYCTaxiFareMeter.Service.DataTransferObjects;
using NYCTaxiFareMeter.ViewModels;

namespace NYCTaxiFareMeter.Mappers
{
    /// <summary>
    /// Contains mappers for Trip objects.
    /// </summary>
    public static class TripMapper
    {
        /// <summary>
        /// Map <see cref="TripViewModel"/> to <see cref="TripDto"/>.
        /// </summary>
        /// <param name="tripViewModel"></param>
        /// <returns></returns>
        public static TripDto MapViewModelToDto(TripViewModel tripViewModel)
        {
            return new TripDto()
            {
                StartDateTime = tripViewModel.StartDateTime,
                Miles = tripViewModel.Miles,
                Minutes = tripViewModel.Minutes
            };
        }
    }
}