using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YFScrape.Models
{
	public class Portfolio
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Date { get; set; }
		public ICollection<Stock> Stocks { get; set; }

		public Portfolio(string date)
		{
			Date = date;
		}
	}
}
