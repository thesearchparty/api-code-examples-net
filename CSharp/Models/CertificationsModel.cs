using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class CertificationsModel
    {

        public Guid? CandidateId { get; set; }
        public Certification Certification { get; set; }
        
        public IEnumerable<SelectListItem> CertificationTypes { get; set; }
 
        public string RawOutput { get; set; }
        public string ResponseCode { get; set; }
    }
}