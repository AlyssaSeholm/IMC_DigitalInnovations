using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using InterviewProject.Models;
using InterviewProject.Services;
using InterviewProject.ViewModels;

namespace InterviewProject.Controllers
{
    public class TaxCalculatorController : Controller
    {
        private readonly ITaxService _taxJarService;
        private readonly TaxCalculatorViewModel _model;

        public TaxCalculatorController(ITaxService taxJarService)
        {
            _taxJarService = taxJarService;
            _model = new TaxCalculatorViewModel();
        }

        public IActionResult Index()
        {
            //Wouldn't usually set these, but did so for UI simplicity
            _model.TaxRate.Zip = "90002";
            _model.OrderTax.FromAddress = new AddressModel
            {
                Street = "9500 Gilman Drive",
                City = "La Jolla",
                Country = "US",
                State = "CA",
                Zip = "92093"
            };
            _model.OrderTax.ToAddress = new AddressModel
            {
                Street = "1335 E 103rd St",
                City = "Los Angeles",
                Country = "US",
                State = "CA",
                Zip = "90002"
            };

            return View("Index", _model);
        }

        public async Task<decimal> GetTaxRateForLocation(TaxRateModel model)
        {
            if (model == null || model.Zip == String.Empty) throw new ArgumentException("Zip code for rate needs to be filled in.");

            return await _taxJarService.GetTaxRateForLocation(model);
        }

        public async Task<decimal> GetOrderTaxes(OrderTaxModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return await _taxJarService.GetOrderTaxes(model);
        }

        #region Click Events

        [HttpPost]
        public async Task<IActionResult> Click_Calculate(TaxCalculatorViewModel model)
        {
            _model.TaxRate.Rate = await GetTaxRateForLocation(model.TaxRate);
            _model.OrderTax.SalesTaxForOrder = await GetOrderTaxes(model.OrderTax);

            return View("Index", _model);
        }

        #endregion

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
