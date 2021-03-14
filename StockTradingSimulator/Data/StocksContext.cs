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
            this.Database.Migrate();
        }

        public DbSet<StockTradingSimulator.Models.Stock> Stock { get; set; }
        public DbSet<StockTradingSimulator.Models.Company> Company { get; set; }
        public DbSet<StockTradingSimulator.Models.Order> Order { get; set; }
        public DbSet<StockTradingSimulator.Models.StockCandlestick> StockCandlestick { get; set; }
    }
}
