using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Host = "Hostname:" + Environment.GetEnvironmentVariable("HOSTNAME_MYSQL");
			ViewBag.User = "MYSQL_USER:" + Environment.GetEnvironmentVariable("MYSQL_USER");
			ViewBag.Password = "MYSQL_PASSWORD:" + Environment.GetEnvironmentVariable("MYSQL_PASSWORD");
			ViewBag.DBName = "MYSQL_DATABASE:" + Environment.GetEnvironmentVariable("MYSQL_DATABASE");
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
