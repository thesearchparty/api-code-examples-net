using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class CandidateModel
    {
        public Candidate Candidate { get; set; }

        public IEnumerable<SelectListItem> Countries {get; set;}
        public IEnumerable<SelectListItem> States { get; set; }

        public Guid? Id { get; set; }

        public string RawOutput { get; set; }
        public string IsError { get; set; }
    }
}