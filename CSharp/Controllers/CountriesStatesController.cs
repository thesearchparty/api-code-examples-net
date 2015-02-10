using CSharp.API;
using CSharp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace CSharp.Controllers
{
    public class CountriesStatesController : Controller
    {

        public ActionResult Index(int? countryID)
        {
            CountriesStatesModel model = new CountriesStatesModel();

            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });

            model.Countries = countryItems;

            return View(model);
        }

        public ActionResult FindLocality(int? countryID)
        {
            CountriesStatesModel model = new CountriesStatesModel();

            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });

            model.Countries = countryItems;

            if (countryID.HasValue)
            {
                var states = JArray.Parse(SearchPartyAPI.ListStates((int)countryID).JsonString);
                IEnumerable<SelectListItem> items = (from s in states
                                                     select new SelectListItem()
                                                     {
                                                         Text = s.Value<string>("ShortTitle"),
                                                         Value = s.Value<string>("Id")
                                                     });
                model.States = items;
            }
            else
            {
                model.States = new List<SelectListItem>() { new SelectListItem() { Text = "Select State" } };
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult FindStates(CountriesStatesModel model)
        {
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.ListStates(model.CountryId).JsonString);
            model.StateList = JsonConvert.DeserializeObject<List<State>>(model.RawOutput);


            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });

            model.Countries = countryItems;

            return View("index", model);
        }

        [HttpPost]
        public ActionResult FindLocality(CountriesStatesModel model)
        {
            model.RawOutput = SearchPartyAPI.LocalityBestMatch(model.CountryId, model.StateId.HasValue ? (int)model.StateId : -1, model.PostCode, model.Suburb).JsonString;
            model.Location = JsonConvert.DeserializeObject<Location>(model.RawOutput);

            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });

            model.Countries = countryItems;


            var states = JArray.Parse(SearchPartyAPI.ListStates((int)model.CountryId).JsonString);
            IEnumerable<SelectListItem> items = (from s in states
                                                 select new SelectListItem()
                                                 {
                                                     Text = s.Value<string>("ShortTitle"),
                                                     Value = s.Value<string>("Id")
                                                 });
            model.States = items;



            return View(model);
        }

        public ActionResult getStates(int countryID)
        {
            var jss = new JavaScriptSerializer();

            dynamic data = jss.Deserialize<dynamic>(SearchPartyAPI.ListStates((int)countryID).JsonString);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
