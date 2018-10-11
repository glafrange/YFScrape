using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YFScrape.Scraper
{
	public class Scraper
	{
		public static Portfolio[] newScrape()
		{

			ChromeOptions options = new ChromeOptions();
			options.AddArgument("--headless");
			options.AddArgument("--window-size=1366,768");

			using (IWebDriver driver = new ChromeDriver(options))
			{
				
				driver.Navigate().GoToUrl("https://finance.yahoo.com/");
				driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
				IWebElement SignIn = driver.FindElement(By.XPath("//*[@id='uh-signedin']"));
				SignIn.Click();


				new WebDriverWait(driver, TimeSpan.FromSeconds(10))
					.Until(d => d.Title.EndsWith("login"));

				IWebElement signin = driver.FindElement(By.Id("login-username"));
				signin.SendKeys("gabriellafrange@gmail.com");
				signin.Submit();

				new WebDriverWait(driver, TimeSpan.FromSeconds(10))
					.Until(d => d.Title.EndsWith("Yahoo"));

				IWebElement password = driver.FindElement(By.Id("login-passwd"));
				password.SendKeys(Environment.GetEnvironmentVariable("yfpw", EnvironmentVariableTarget.User));
				driver.FindElement(By.Id("login-signin")).Click();

				new WebDriverWait(driver, TimeSpan.FromSeconds(10))
					.Until(d => d.Title.StartsWith("Yahoo Finance"));

				driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

				new WebDriverWait(driver, TimeSpan.FromSeconds(10))
					.Until(d => d.Title.StartsWith("Stocks"));

				float lastPrice = float.Parse(driver.FindElement(By.XPath("//*[@id='main']/section/section[2]/div[2]/table/tbody/tr[1]/td[2]/span")).Text);

				IWebElement Table = driver.FindElement(By.XPath("//*[@id='main']/section/section[2]/div[2]/table/tbody"));
				ReadOnlyCollection<IWebElement> Rows = Table.FindElements(By.XPath(".//tr"));

				Portfolio[] Portfolios = new Portfolio[Rows.Count];

				//Console.WriteLine("text " + Rows[10].GetAttribute("innerHTML"));
				//Console.WriteLine("text " + Rows[10].FindElement(By.XPath(".//td[1]")).GetAttribute("innerHTML"));
				Console.WriteLine("text " + Rows[10].FindElement(By.XPath(".//td[2]/span")).Text);
				//Console.WriteLine("text " + Rows[10].FindElement(By.XPath(".//td[1]/span/a")).Text);
				//Console.WriteLine(Table.GetAttribute("innerHTML"));

				for (int i = 0; i < Rows.Count; i++)
				{
					Portfolio NewPortfolio = new Portfolio();

					//NewPortfolio.Symbol = Rows[i].FindElement(By.XPath(".//td[1]")).Text;
					NewPortfolio.Symbol = Table.FindElement(By.XPath(string.Format(".//tr[{0}]/td[1]", i+1))).Text;
					//NewPortfolio.Symbol = Rows[i].FindElement(By.XPath(".//td[1]/span/a")).Text;
					//NewPortfolio.Price = float.Parse(Rows[i].FindElement(By.XPath(".//td[2]")).Text.Replace(",", ""));
					//NewPortfolio.Price = float.Parse(Rows[i].FindElement(By.XPath(".//td[2]/span")).Text.Replace(",", ""));
					//NewPortfolio.Change = float.Parse(Rows[i].FindElement(By.XPath(".//td[3]")).Text);
					//NewPortfolio.PercentChange = float.Parse(Rows[i].FindElement(By.XPath(".//td[4]")).Text.Split("%")[0]);
					//NewPortfolio.Volume = float.Parse(Rows[i].FindElement(By.XPath(".//td[2]")).Text);
					//NewPortfolio.MarketCap = float.Parse(Rows[i].FindElement(By.XPath(".//td[13]")).Text.TrimEnd('A', 'B'));

					Portfolios[i] = NewPortfolio;
				}

				return Portfolios;
			}
		}
	}
}
