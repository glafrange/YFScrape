using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YFScrape.Models;

namespace YFScrape.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewPortfolioController : ControllerBase
	{
		private readonly PortfolioContext _context;

		public NewPortfolioController(PortfolioContext context)
		{
			_context = context;
		}

		[HttpGet]
		public ICollection<Stock> GetPortfolio()
		{
			return _context.Stocks.ToList();
		}

		[HttpPost]
		public void NewPortfolio()
		{
			ICollection<Stock> NewScrape = Scraper.Scraper.newScrape();
			Portfolio NewPortfolio = new Portfolio(DateTime.Now.ToString());
			//NewPortfolio.Stocks = NewScrape;
			_context.Portfolios.Add(NewPortfolio);
			foreach (Stock newStock in NewScrape)
			{
				newStock.PortfolioId = NewPortfolio.Id;
				_context.Stocks.Add(newStock);
			}

			_context.SaveChanges();
		}
	}
}
