﻿using System.Web.Mvc;

namespace CustomModelBindingWithDateTime.Controllers 
{
    public class HomeController : Controller 
    {
        public ActionResult Index()
        {
            ViewBag.PageTitle = "Custom Model Binder w/ Date Time Conversion";
            ViewBag.Message = "Custom Model Binder for Date Time Conversion Test MVC Application.";
            return View();
        }

        public ActionResult UiDateTimeModel() 
        {
            ViewBag.PageTitle = "C# MVC DateTime Conversions | Custom Model Binding w/ UiDateTimeModel";
            return View();
        }

        public ActionResult DateAndTimeModelBinder() 
        {
            ViewBag.PageTitle = "C# MVC DateTime Conversions | Custom Model Binder w/ UiDateTimeModel";
            return View();
        }

        public ActionResult SourceCode()
        {
            ViewBag.PageTitle = "C# MVC DateTime Conversions | Custom Model Binding";
            return View();
        }

        public ActionResult Usage() 
        {
            ViewBag.PageTitle = "C# MVC DateTime Conversions | Examples";
            return View();
        }
    }
}
