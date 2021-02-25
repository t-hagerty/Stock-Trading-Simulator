using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockTradingSimulator.Models
{
    public class OrdersContext : DbContext
    {
        public OrdersContext (DbContextOptions<OrdersContext> options)
            : base(options)
        {
        }

        public DbSet<StockTradingSimulator.Models.Order> Order { get; set; }
    }
}
