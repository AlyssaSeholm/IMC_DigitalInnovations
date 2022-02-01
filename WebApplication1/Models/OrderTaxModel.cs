namespace InterviewProject.Models
{
    public class OrderTaxModel
    {      
        public decimal OrderAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal SalesTaxForOrder { get; set; }
        public AddressModel? ToAddress { get; set; }
        public AddressModel? FromAddress { get; set; }
    }
}
