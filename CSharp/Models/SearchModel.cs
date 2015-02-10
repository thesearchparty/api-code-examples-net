using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class SearchModel
    {
        public IEnumerable<SelectListItem> Sectors {get; set;}
        public IEnumerable<SelectListItem> SubSectors {get; set;}
        public IEnumerable<SelectListItem> SalaryTypeList {get; set;}
        public IEnumerable<SelectListItem> Countries {get; set;}
        public IEnumerable<SelectListItem> States { get; set; }


        

        public List<Vacancy> Vacancies { get; set; }

        public int PageIndex { get; set; } 
        public string Query { get; set; }

        public string RawOutput { get; set; }

        public int SalaryTypeId { get; set; }



        public string SalaryMin { get; set; }
        public string SalaryMax { get; set; }
        public string StartDateFrom { get; set; }
        public string StartDateTo { get; set; }
        public string EndDateFrom { get; set; }
        public string EndDateTo { get; set; }
        public string SectorId { get; set; }
        public string SubSectorId { get; set; }
        public string LocationRadius { get; set; }
        public string LocalityId { get; set; }
        public string CountryId { get; set; }
        public string StateId { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }

        


        //public string LocationRadius { get; set; }

        


    }
}