using InterviewProject.Models;

namespace InterviewProject.Services
{
    public interface ITaxService
    {
        Task<decimal> GetTaxRateForLocation(TaxRateModel model);

        Task<decimal> GetOrderTaxes(OrderTaxModel model);
    }
}
