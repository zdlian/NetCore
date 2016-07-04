using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KTU.Services;
using KTU.WebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KTU.WebApp.Controllers
{
	public class LoginController : Controller
	{
		private readonly IUserService _userService;

		public LoginController(IUserService userService)
		{
			this._userService = userService;
		}

		[AllowAnonymous]
		[HttpGet]
		public ActionResult Login()
		{
			var loginModel = new LoginViewModel();
			return View(loginModel);
		}
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<ActionResult> Login(LoginViewModel login)
		{
			if (login == null) {
				return View(new LoginViewModel());
			}

			if (ModelState.IsValid)
			{
				if (_userService.CheckUser(login.UserName, login.Password))
				{
					var claims = new List<Claim>
					{
						new Claim("sub", login.UserName),
					};

					ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "local"));
					await HttpContext.Authentication.SignInAsync(".AppCookie", principal);

					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError("gg", "Try again!");
			}

			return View(login);
		}

		public ActionResult LogOut()
		{
			HttpContext.Authentication.SignOutAsync(".AppCookie");
			return RedirectToAction("login");
		}
	}
}
