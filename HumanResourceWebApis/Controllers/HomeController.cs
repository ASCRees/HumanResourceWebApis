﻿using System.Web.Mvc;

namespace HumanResourceWebApis.Controllers
{
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            ViewBag.Title = "Home Page";

            return Redirect("~/swagger");
        }
    }
}