using System.ComponentModel.DataAnnotations;
using InterviewProject.Models;

namespace InterviewProject.ViewModels
{
    public class TaxCalculatorViewModel
    {
        public TaxRateModel TaxRate { get; set; }
        public OrderTaxModel OrderTax { get; set; }


        public TaxCalculatorViewModel()
        {
            TaxRate = new TaxRateModel();
            OrderTax = new OrderTaxModel();
        }
    }
}
