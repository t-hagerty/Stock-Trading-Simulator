using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockTradingSimulator.Models
{
    public class StockCandlesticksContext : DbContext
    {
        public StockCandlesticksContext (DbContextOptions<StockCandlesticksContext> options)
            : base(options)
        {
        }

        public DbSet<StockTradingSimulator.Models.StockCandlestick> StockCandlestick { get; set; }
    }
}
