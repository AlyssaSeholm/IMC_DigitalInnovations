using InterviewProject.Controllers;
using InterviewProject.Models;
using InterviewProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace InterviewProjectTests
{
    [TestClass]
    public class TaxCalculatorTests
    {
        private readonly Mock<ITaxService> _mockJarService;
        private readonly TaxCalculatorController _controller;

        public TaxCalculatorTests()
        {
            _mockJarService = new Mock<ITaxService>();
            _controller = new TaxCalculatorController(_mockJarService.Object);
        }

        [TestMethod]
        public void Index()
        {
            ViewResult? result = _controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Zip code for rate needs to be filled in.")]
        public async Task GetTaxRateForLocation_Error_NoZipcode()
        {
            var model = new TaxRateModel
            {
                Zip = String.Empty 
            };

            _ = await _controller.GetTaxRateForLocation(model);           
           
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "OrderTaxModel")]
        public async Task GetOrderTaxes_Error_Null()
        {
            _ = await _controller.GetOrderTaxes(null);
        }
    }
}