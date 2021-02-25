using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTradingSimulator.Models;

namespace StockTradingSimulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly StocksContext _context;

        public StocksController(StocksContext context)
        {
            _context = context;
        }

        // GET: api/Stocks
        [HttpGet]
        public IEnumerable<Stock> GetStock()
        {
            return _context.Stock;
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = await _context.Stock.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        // PUT: api/Stocks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStock([FromRoute] int id, [FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stock.ID)
            {
                return BadRequest();
            }

            _context.Entry(stock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Stocks
        [HttpPost]
        public async Task<IActionResult> PostStock([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Stock.Add(stock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.ID }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stock.Remove(stock);
            await _context.SaveChangesAsync();

            return Ok(stock);
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.ID == id);
        }
    }
}