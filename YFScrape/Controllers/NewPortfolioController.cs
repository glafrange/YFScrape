using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YFScrape.Models;
using YFScrape.Scraping;
using Newtonsoft.Json;

namespace YFScrape.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NewPortfolioController : Controller
	{
		private readonly PortfolioContext _context;

		public NewPortfolioController(PortfolioContext context)
		{
			_context = context;
		}

		[HttpGet]
		public JsonResult GetPortfolios()
		{
			Response.StatusCode = 200;
			return Json(_context.Stocks.ToList());
		}

		[HttpPost]
		public ActionResult NewPortfolio()
		{
			ICollection<Stock> NewScrape = Scraper.newScrape();
			Portfolio NewPortfolio = new Portfolio(DateTime.Now.ToString());
			_context.Portfolios.Add(NewPortfolio);
			foreach (Stock newStock in NewScrape)
			{
				newStock.PortfolioId = NewPortfolio.Id;
				_context.Stocks.Add(newStock);
			}

			_context.SaveChanges();

			Response.StatusCode = 200;
			return Json(NewScrape);
		}
	}
}
