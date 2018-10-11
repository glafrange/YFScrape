using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YFScrape.Controllers
{
	[Route("api/[controller]")]
	public class NewPortfolioController : Controller
	{
		[HttpGet]
		public Portfolio[] GetPortfolio()
		{
			return Scraper.Scraper.newScrape();
		}
	}
}
