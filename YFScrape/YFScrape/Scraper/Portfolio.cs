using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YFScrape
{
	public class Portfolio
	{
		public string Symbol { get; set; }
		public float Price { get; set; }
		public float Change { get; set; }
		public float PercentChange { get; set; }
		public float Volume { get; set; }
		public float MarketCap { get; set; }

	}
}
