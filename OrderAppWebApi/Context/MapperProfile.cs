using AutoMapper;
using OrderAppWebApi.Models.Dtos;
using OrderAppWebApi.Models.Entities;

namespace OrderAppWebApi.Context
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Order, CreateOrderRequest>();
            CreateMap<CreateOrderRequest, Order>();            
            CreateMap<ProductDetailDto, OrderDetail>();            
            CreateMap<OrderDetail, ProductDetailDto>();            
        }
    }
}
