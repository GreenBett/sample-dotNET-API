using api.Data;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers
{
    public class StockController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;
        
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Select is similar to javascript map()
            var stocks = _context.Stocks.ToList()
            .Select(s=> s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);
            
            if (stock == null){
                return NotFound();
            }
            return Ok(stock);
        }


    }
}