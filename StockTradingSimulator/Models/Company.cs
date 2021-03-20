using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTradingSimulator.Models
{
    public class Company
    {
        public int ID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string TickerSymbol { get; set; }
        public DateTime StartDataDate { get; set; }
    }
}
