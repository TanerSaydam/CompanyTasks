using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RehberWebApi.Models.Context;
using RehberWebApi.Models.Entities;

namespace RehberWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimBilgilerisController : ControllerBase
    {
        private readonly RehberDbContext _context;

        public IletisimBilgilerisController(RehberDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IletisimBilgileri iletisimBilgileri)
        {
            await _context.IletisimBilgileris.AddAsync(iletisimBilgileri);
            await _context.SaveChangesAsync();

            Rehber rehber = await _context.Rehbers.Include(p => p.IletisimBilgileri).FirstAsync(p => p.Id == iletisimBilgileri.RehberId);

            return Ok(rehber);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            IletisimBilgileri iletisimBilgileri = await _context.IletisimBilgileris.FindAsync(id);
            _context.IletisimBilgileris.Remove(iletisimBilgileri);
            await _context.SaveChangesAsync();

            Rehber rehber = await _context.Rehbers.Include(p => p.IletisimBilgileri).FirstAsync(p => p.Id == iletisimBilgileri.RehberId);

            return Ok(rehber);
        }
    }
}
