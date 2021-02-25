using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockTradingSimulator.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext (DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public DbSet<StockTradingSimulator.Models.Company> Company { get; set; }
    }
}
