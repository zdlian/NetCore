using System.Collections.Generic;
using System.Security.Claims;
using KTU.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace KTU.WebApp.Controllers
{
	[Authorize]
	public class HomeController : Controller
    {
	    private readonly IUserService _userService;

		public HomeController(IUserService userService)
		{
			this._userService = userService;
		}
		[Route("home")]
		public IActionResult Index()
		{
			var foo = _userService.Get();
			return View();
        }
    }
}
