using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewlatterWepApi.Context;
using NewlatterWepApi.Models;
using NewlatterWepApi.Result;

namespace NewlatterWepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsLatterDb _context;

        public NewsController(NewsLatterDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Newslatters.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _context.Newslatters.FindAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Newslatter newslatter)
        {
            newslatter.CreatedDate = DateTime.Now;
            await _context.Newslatters.AddAsync(newslatter);
            await _context.SaveChangesAsync();
            var result = new ResultModel()
            {
                Message = "Newslatter added is succesful"
            };
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Newslatter newslatter)
        {
            _context.Newslatters.Update(newslatter);
            await _context.SaveChangesAsync();

            var result = new ResultModel()
            {
                Message = "Newslatter updated is succesful"
            };
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Newslatters.FindAsync(id);
            _context.Newslatters.Remove(result);
            await _context.SaveChangesAsync();

            var resultModel = new ResultModel()
            {
                Message = "Newslatter deleted is succesful"
            };
            return Ok(resultModel);
        }
    }
}
