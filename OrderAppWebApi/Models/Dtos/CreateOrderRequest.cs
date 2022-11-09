namespace OrderAppWebApi.Models.Dtos
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGSM { get; set; } 
        public List<ProductDetailDto> ProductDetails { get; set; }
    }
}
