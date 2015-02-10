using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class CountriesStatesModel
    {
        public IEnumerable<SelectListItem> Countries {get; set;}
        public IEnumerable<SelectListItem> States { get; set; }

        public List<State> StateList { get; set; }

        public int CountryId { get; set; }
        public int? StateId { get; set; }

        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string RawOutput { get; set; }
        public Location Location { get; set; }
    }
}