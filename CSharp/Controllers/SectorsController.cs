using CSharp.API;
using CSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CSharp.Controllers
{
    public class SectorsController : Controller
    {
        //
        // GET: /Sectors/

        public ActionResult Index()
        {
            SectorsModel model = new SectorsModel();

            var sectors = JArray.Parse(SearchPartyAPI.ListSectors().JsonString);
            IEnumerable<SelectListItem> sectorsList = (from s in sectors
                                                       select new SelectListItem()
                                                       {
                                                           Text = s.Value<string>("Name"),
                                                           Value = s.Value<string>("Id")
                                                       });

            model.Sectors = sectorsList;

            return View(model);
        }



        [HttpPost]
        public ActionResult findSectors(SectorsModel model)
        {
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.ListSectors(model.SectorId).JsonString);
            model.SubSectors = JsonConvert.DeserializeObject<List<Sector>>(model.RawOutput);

            var sectors = JArray.Parse(SearchPartyAPI.ListSectors().JsonString);
            IEnumerable<SelectListItem> sectorsList = (from s in sectors
                                                       select new SelectListItem()
                                                       {
                                                           Text = s.Value<string>("Name"),
                                                           Value = s.Value<string>("Id")
                                                       });

            model.Sectors = sectorsList;

            return View("index", model);
        }

        /// <summary>
        /// Method used by UI to fill sub select list for sector
        /// </summary>
        public ActionResult GetSubSector(int parentSectorId)
        {
            var jss = new JavaScriptSerializer();

            dynamic data = jss.Deserialize<dynamic>(SearchPartyAPI.ListSectors(parentSectorId).JsonString);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
