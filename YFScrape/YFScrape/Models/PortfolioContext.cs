using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YFScrape.Models
{
	public class PortfolioContext : DbContext
	{
		public PortfolioContext(DbContextOptions<PortfolioContext> options)
			:base(options)
		{
		}

		public DbSet<Portfolio> Portfolios { get; set; }
		public DbSet<Stock> Stocks { get; set; }
	}
}
