using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using YFScrape.Models;

namespace YFScrape
{
	public class Stock
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Symbol { get; set; }
		public float Price { get; set; }
		public float Change { get; set; }
		public float PercentChange { get; set; }
		public float Volume { get; set; }
		public float MarketCap { get; set; }
		public int PortfolioId { get; set; }
	}
}
