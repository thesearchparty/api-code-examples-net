using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class EmploymentModel
    {

        public Guid? CandidateId { get; set; }
        public Employment Employment { get; set; }

        public string RawOutput { get; set; }
        public string ResponseCode { get; set; }
    }
}