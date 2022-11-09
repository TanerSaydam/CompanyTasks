using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OrderAppWebApi.Context;
using OrderAppWebApi.Models.Dtos;
using OrderAppWebApi.Models.Entities;
using OrderAppWebApi.Models.Results;
using OrderAppWebApi.RabbitMq;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System.Collections.Generic;
using System.Text;

namespace OrderAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly OrderContextDb _context;
        private readonly IMapper _mapper;

        public OrdersController(IMemoryCache memoryCache, OrderContextDb context, IMapper mapper)
        {
            _memoryCache = memoryCache;
            _context = context;
            _mapper = mapper;
        }

        #region MemoryCache Loglama
        //[HttpGet]
        //public async Task<IActionResult> Get(string? category)
        //{
        //    var result = new List<Product>();
        //    if (category is null)
        //    {
        //        result = _memoryCache.Get("products") as List<Product>;
        //        if (result is null)
        //        {
        //            result = await _context.Products.ToListAsync();
        //            _memoryCache.Set("products", result, TimeSpan.FromMinutes(10));
        //        }

        //    }
        //    else
        //    {
        //        result = _memoryCache.Get($"products-{category}") as List<Product>;
        //        if (result is null)
        //        {
        //            result = await _context.Products.Where(p => p.Category == category).ToListAsync();
        //            _memoryCache.Set($"products-{category}", result, TimeSpan.FromMinutes(10));
        //        }
        //    }

        //    var produtDtos = _mapper.Map<List<Product>, List<ProductDto>>(result);

        //    return Ok(new ApiResponse<List<ProductDto>>(StatusType.Success, produtDtos));
        //}
        #endregion

        #region Redis Loglama
        [HttpGet]
        public async Task<IActionResult> Get(string? category)
        {
            var redisClient = new RedisClient("localhost", 6379);
            IRedisTypedClient<List<Product>> redisProducts = redisClient.As<List<Product>>();

            var result = new List<Product>();
            if (category is null)
            {
                result = redisClient.Get<List<Product>>("products");
                if (result is null)
                {
                    result = await _context.Products.ToListAsync();
                    redisClient.Set("products", result,TimeSpan.FromMinutes(10));                    
                }

            }
            else
            {
                result = redisClient.Get<List<Product>>($"products-{category}");                
                if (result is null)
                {
                    result = await _context.Products.Where(p => p.Category == category).ToListAsync();
                    redisClient.Set($"products-{category}", result, TimeSpan.FromMinutes(10));
                }
            }

            var produtDtos = _mapper.Map<List<Product>, List<ProductDto>>(result);

            return Ok(new ApiResponse<List<ProductDto>>(StatusType.Success, produtDtos));
        }
        #endregion

        #region Create Order
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequest createOrderRequest)
        {
            Order order = _mapper.Map<Order>(createOrderRequest);
            List<OrderDetail> orderDetails = _mapper.Map<List<ProductDetailDto>, List<OrderDetail>>(createOrderRequest.ProductDetails) as List<OrderDetail>;

            order.TotalAmount = createOrderRequest.ProductDetails.Sum(p => p.Amount);
            order.OrderDetails = orderDetails;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            //Mail işlemi kaldı

            var datas = Encoding.UTF8.GetBytes(createOrderRequest.CustomerEmail);

            SetQueues.SendQueue(datas); 

            return Ok(new ApiResponse<int>(StatusType.Success, order.Id));
        }
        #endregion

        #region Add 100 Product
        //[HttpPost]
        //public async Task<IActionResult> Post()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Product product = new()
        //        {
        //            Category = $"Kategori {i}",
        //            CreateDate = DateTime.Now,
        //            Description = "Açıklama",
        //            Status = true,
        //            Unit = i,
        //            UnitPrice = i * 10
        //        };

        //        await _context.Products.AddAsync(product);
        //        await _context.SaveChangesAsync();

        //    }
        //    return Ok("Productlar başarılı şekilde oluşturuldu!");
        //}
        #endregion

    }
}
