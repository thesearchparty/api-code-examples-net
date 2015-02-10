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
    public class MarketplaceController : Controller
    {

        public ActionResult Index(Guid? id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Publish(string candidateId)
        {

            Guid id_guid;

            if (Guid.TryParse(candidateId, out id_guid))
                ViewBag.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.PublishCandidateMarketplace(id_guid).JsonString);

            return Content(ViewBag.RawOutput);
        }
    }


}
