using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockTradingSimulator.Models
{
    /*
     * Models the price range of a stock at a given point in time https://www.investopedia.com/trading/candlestick-charting-what-is-it/
     */
    public class StockCandlestick
    {
        public int ID { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        public decimal Open { get; set; }
        [Required]
        public decimal High { get; set; }
        [Required]
        public decimal Low { get; set; }
        [Required]
        public decimal Close { get; set; }
        [Required]
        public int Volume { get; set; }
    }
}
