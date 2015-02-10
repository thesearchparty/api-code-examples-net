using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class EducationModel
    {

        public Guid? CandidateId { get; set; }
        public Education Education { get; set; }

        public IEnumerable<SelectListItem> EducationTypes {get; set;}
        public IEnumerable<SelectListItem> Countries { get; set; }

        public string RawOutput { get; set; }
        public string ResponseCode { get; set; }
        
    }
}