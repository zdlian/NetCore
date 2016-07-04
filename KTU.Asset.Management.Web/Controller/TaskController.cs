﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KTU.Asset.Management.Web
{
	[Authorize]
	public class TaskController : Controller
    {
		[Route("task")]
		public IActionResult Index()
        {
            return View();
        }
    }
}
