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
    public class SearchController : Controller
    {
        //
        // GET: /Search/

        public ActionResult Index()
        {
            SearchModel model = new SearchModel();

            return View(model);
        }

        public ActionResult Advanced()
        {
            SearchModel model = new SearchModel();

            var salaryTypes = JArray.Parse(SearchPartyAPI.ListSalaryTypes().JsonString);
            IEnumerable<SelectListItem> salaryTypeList = (from s in salaryTypes
                                                          select new SelectListItem()
                                                          {
                                                              Text = s.Value<string>("Title"),
                                                              Value = s.Value<string>("Id")
                                                          });


            var sectors = JArray.Parse(SearchPartyAPI.ListSectors().JsonString);
            IEnumerable<SelectListItem> sectorsList = (from s in sectors
                                                       select new SelectListItem()
                                                       {
                                                           Text = s.Value<string>("Name"),
                                                           Value = s.Value<string>("Id")
                                                       });

            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });



            model.States = new List<SelectListItem>() { new SelectListItem() { Text = "Select State" } };
            model.SubSectors = new List<SelectListItem>() { new SelectListItem() { Text = "Select Sector" } };
            model.Countries = countryItems;
            model.Sectors = sectorsList;
            model.SalaryTypeList = salaryTypeList;

            return View(model);
        }

        [HttpPost]
        public ActionResult simpleSearch(SearchModel model)
        {

            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.SearchVacancy(model.PageIndex, model.Query).JsonString);
            model.Vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(model.RawOutput);

            return View("index", model);
        }

        [HttpPost]
        public ActionResult advancedSearch(SearchModel model)
        {



            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.SearchVacancy(model).JsonString);
            model.Vacancies = JsonConvert.DeserializeObject<List<Vacancy>>(model.RawOutput);


            var salaryTypes = JArray.Parse(SearchPartyAPI.ListSalaryTypes().JsonString);
            IEnumerable<SelectListItem> salaryTypeList = (from s in salaryTypes
                                                          select new SelectListItem()
                                                          {
                                                              Text = s.Value<string>("Title"),
                                                              Value = s.Value<string>("Id")
                                                          });


            var sectors = JArray.Parse(SearchPartyAPI.ListSectors().JsonString);
            IEnumerable<SelectListItem> sectorsList = (from s in sectors
                                                       select new SelectListItem()
                                                       {
                                                           Text = s.Value<string>("Name"),
                                                           Value = s.Value<string>("Id")
                                                       });

            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });



            model.States = new List<SelectListItem>() { new SelectListItem() { Text = "Select State" } };
            model.SubSectors = new List<SelectListItem>() { new SelectListItem() { Text = "Select Sector" } };
            model.Countries = countryItems;
            model.Sectors = sectorsList;
            model.SalaryTypeList = salaryTypeList;


            return View("advanced", model);
        }


        [HttpGet]
        public ActionResult single(string id)
        {
            SearchModel model = new SearchModel();
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetVacancy(id).JsonString);

            return Content(model.RawOutput);
        }
    }
}
