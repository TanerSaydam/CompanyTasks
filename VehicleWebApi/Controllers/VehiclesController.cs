using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWebApi.Models;
using VehicleWebApi.Models.Abstract;
using VehicleWebApi.Services;

namespace VehicleWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IScopedService _scopedService;

        public VehiclesController(IScopedService scopedService)
        {
            _scopedService = scopedService;
        }

        List<Car> CarList = new List<Car>()
        {
            new Car(){Id=0,Wheels= true, HeadLights = true, Color = "Red"},
            new Car(){Id=1,Wheels= true, HeadLights = true, Color = "Blue"},
            new Car(){Id=2,Wheels= true, HeadLights = true, Color = "Black"},
            new Car(){Id=3,Wheels= true, HeadLights = true, Color = "White"},            
        };

        List<Bus> BusList = new List<Bus>()
        {
            new Bus(){Id=0,Color = "Red"},
            new Bus(){Id=1,Color = "Blue"},
            new Bus(){Id=2,Color = "Black"},
            new Bus(){Id=3,Color = "White"},
        };

        List<Boat> BoatList = new List<Boat>()
        {
            new Boat(){Id=0,Color = "Red"},
            new Boat(){Id=1,Color = "Blue"},
            new Boat(){Id=2,Color = "Black"},
            new Boat(){Id=3,Color = "White"},
        };

        [HttpGet("[action]")]
        public IActionResult GetCarList()
        {
            return Ok(CarList);
        }

        [HttpGet("[action]")]
        public IActionResult GetBusList()
        {
            return Ok(BusList);
        }

        [HttpGet("[action]")]
        public IActionResult GetBoatList()
        {
            return Ok(BoatList);
        }

        [HttpPost("[action]")]
        public IActionResult ChangeCarHeadLight(int id)
        {
            var car = CarList.Where(p => p.Id == id).FirstOrDefault();
            var index = CarList.FindIndex(p=> p.Id == id);
            car.HeadLights = !car.HeadLights;
            CarList[index] = car;
            return Ok(car);
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = CarList.Where(p => p.Id == id).FirstOrDefault();
            CarList.Remove(car);
            return Ok(CarList);
        }


        [HttpGet("[action]/{id}/{type}")]
        public IActionResult SelectVehicle(int id, string type)
        {
            Vehicle vehicle = _scopedService.SelectVehicle(id, type);
            return Ok(vehicle);
        }
    }
}
