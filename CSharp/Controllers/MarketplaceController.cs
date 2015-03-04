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

            var model = new MarketplaceModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult Publish(string candidateId)
        {

            Guid id_guid;

            var model = new MarketplaceModel();

            if (Guid.TryParse(candidateId, out id_guid))
            {
                var returnResult = SearchPartyAPI.PublishCandidateMarketplace(id_guid);

                model.RawOutput = JsonHelper.FormatJson(returnResult.JsonString);
                model.ResponseCode = returnResult.StatusCode.ToString();
                
            }

            return View("index", model);
        }

        [HttpPost]
        public ActionResult Delete(string candidateId)
        {

            Guid id_guid;

            var model = new MarketplaceModel();

            if (Guid.TryParse(candidateId, out id_guid))
            {
                var returnResult = SearchPartyAPI.UnPublishCandidateMarketplace(id_guid);
                model.RawOutput = JsonHelper.FormatJson(returnResult.JsonString);
                model.ResponseCode = returnResult.StatusCode.ToString();
            }

            return View("index", model);
        }
    }


}
