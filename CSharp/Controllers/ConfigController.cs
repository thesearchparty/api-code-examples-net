using CSharp.API;
using CSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class ConfigController : Controller
    {
        public ActionResult Index(Guid? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string apiKey, string apiSecret)
        {
            if (!string.IsNullOrEmpty(apiKey) && !string.IsNullOrEmpty(apiSecret))
            {
                Session.Add("apiKey", apiKey);
                Session.Add("apiSecret", apiSecret);

                ViewBag.ReturnVal = "ok";
            }

            return View();
        }
    }
}
