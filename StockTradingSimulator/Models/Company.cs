﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockTradingSimulator.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string TickerSymbol { get; set; }
        public DateTime StartDataDate { get; set; }
    }
}