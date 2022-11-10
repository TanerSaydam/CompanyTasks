using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehberWebApi.Models.Context;

namespace RehberWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporsController : ControllerBase
    {
        private readonly RehberDbContext _context;

        public RaporsController(RehberDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var konumlar = _context.IletisimBilgileris.GroupBy(p => p.Konum).Select(s => s.Key).ToList();
            var result = from konum in konumlar
                         select new
                         {
                             Konum = konum,
                             KisiSayisi = _context.IletisimBilgileris.Where(p => p.Konum == konum).Count(),
                             TelefonSayisi = _context.IletisimBilgileris.Where(p => p.Konum == konum && p.TelefoNumarasi != "").Count(),
                         };

            return Ok(result.OrderBy(p => p.KisiSayisi).ToList());
        }
    }
}
