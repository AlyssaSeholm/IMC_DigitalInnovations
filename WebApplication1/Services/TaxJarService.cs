using Taxjar;
using InterviewProject.Models;
using AutoMapper;

namespace InterviewProject.Services
{
    public class TaxJarService : ITaxService
    {
        private readonly TaxjarApi _taxjarApi;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly string TAXJAR_API_SETTINGSPATH = "APIKeys:TaxJar";

        public TaxJarService(IConfiguration configuration, IMapper mapper) 
        {
            _configuration = configuration;
            _mapper = mapper;
            _taxjarApi = new TaxjarApi(_configuration.GetValue<string>(TAXJAR_API_SETTINGSPATH));
        }
        public async Task<decimal> GetTaxRateForLocation(TaxRateModel model)
        {
            try
            {
                var rates = await _taxjarApi.RatesForLocationAsync(model.Zip);
                return rates.CombinedRate;
            }
            catch 
            {
                throw; 
            }
        }

        public async Task<decimal> GetOrderTaxes(OrderTaxModel model)
        {
            var tax = _mapper.Map<Tax>(model);

            var taxResponse = await _taxjarApi.TaxForOrderAsync(tax);

            return taxResponse.AmountToCollect;
        }
    }
}
