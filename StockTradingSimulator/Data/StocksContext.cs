using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockTradingSimulator.Models
{
    public class StocksContext : DbContext
    {
        public StocksContext (DbContextOptions<StocksContext> options)
            : base(options)
        {
        }

        public DbSet<StockTradingSimulator.Models.Stock> Stock { get; set; }
    }
}
