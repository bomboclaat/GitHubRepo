using NYCTaxiFareMeter.Mappers;
using NYCTaxiFareMeter.Service.DataTransferObjects;
using NYCTaxiFareMeter.Service.Services;
using NYCTaxiFareMeter.ViewModels;
using System.Web.Mvc;

namespace NYCTaxiFareMeter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculationService calculationService;

        public HomeController(CalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Calculate(TripViewModel model)
        {
            TripDto dto = TripMapper.MapViewModelToDto(model);
            double fare = calculationService.CalculateFare(dto);

            return View();
        }
    }
}