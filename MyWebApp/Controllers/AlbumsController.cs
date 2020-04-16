using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
	public class AlbumsController : Controller
	{
		public IActionResult Index()
		{
			MusicStoreContext context = HttpContext.RequestServices.GetService(typeof(MyWebApp.Models.MusicStoreContext)) as MusicStoreContext;

			return View(context.GetAllAlbums());
		}


	}
}