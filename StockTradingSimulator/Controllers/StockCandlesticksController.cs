﻿using System;
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
    public class StockCandlesticksController : ControllerBase
    {
        private readonly StocksContext _context;

        public StockCandlesticksController(StocksContext context)
        {
            _context = context;
        }

        // GET: api/StockCandlesticks
        [HttpGet]
        public IEnumerable<StockCandlestick> GetStockCandlestick()
        {
            return _context.StockCandlestick.Include(s => s.Company);
        }

        // GET: api/StockCandlesticks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockCandlestick([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockCandlestick = await _context.StockCandlestick.Include(s => s.Company).FirstAsync(s => s.ID == id);

            if (stockCandlestick == null)
            {
                return NotFound();
            }

            return Ok(stockCandlestick);
        }

        // GET: api/StockCandlesticks/Company?ticker=TST
        [HttpGet("Company")]
        [ExactQueryParam("ticker")]
        public async Task<IActionResult> GetStockCandlestick([FromQuery] string ticker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockCandlestick = await _context.StockCandlestick.Where(s => s.Company.TickerSymbol == ticker).ToListAsync();

            if (stockCandlestick == null)
            {
                return NotFound();
            }

            return Ok(stockCandlestick);
        }

        // GET: api/StockCandlesticks/Company?ticker=TST&since=2021-03-31
        [HttpGet("Company")]
        [ExactQueryParam("ticker", "since")]
        public async Task<IActionResult> GetStockCandlestick([FromQuery] string ticker, [FromQuery] DateTime since)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockCandlestick = await _context.StockCandlestick.Where(s => s.Company.TickerSymbol == ticker && s.Timestamp >= since).ToListAsync();

            if (stockCandlestick == null)
            {
                return NotFound();
            }

            return Ok(stockCandlestick);
        }

        // GET: api/StockCandlesticks/Company?ticker=TST&from=2021-03-31&to=2021-04-01
        [HttpGet("Company")]
        [ExactQueryParam("ticker", "from", "to")]
        public async Task<IActionResult> GetStockCandlestick([FromQuery] string ticker, [FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (from > to)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            var stockCandlestick = await _context.StockCandlestick.Where(s => s.Company.TickerSymbol == ticker && s.Timestamp >= from && s.Timestamp <= to).ToListAsync();

            if (stockCandlestick == null)
            {
                return NotFound();
            }

            return Ok(stockCandlestick);
        }

        // PUT: api/StockCandlesticks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockCandlestick([FromRoute] int id, [FromBody] StockCandlestick stockCandlestick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockCandlestick.ID)
            {
                return BadRequest();
            }

            _context.Entry(stockCandlestick).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockCandlestickExists(id))
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

        // POST: api/StockCandlesticks
        [HttpPost]
        public async Task<IActionResult> PostStockCandlestick([FromBody] StockCandlestick stockCandlestick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StockCandlestick.Add(stockCandlestick);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockCandlestick", new { id = stockCandlestick.ID }, stockCandlestick);
        }

        // DELETE: api/StockCandlesticks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockCandlestick([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockCandlestick = await _context.StockCandlestick.FindAsync(id);
            if (stockCandlestick == null)
            {
                return NotFound();
            }

            _context.StockCandlestick.Remove(stockCandlestick);
            await _context.SaveChangesAsync();

            return Ok(stockCandlestick);
        }

        private bool StockCandlestickExists(int id)
        {
            return _context.StockCandlestick.Any(e => e.ID == id);
        }
    }
}