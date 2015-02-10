using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class PublicationModel
    {
        [Display(Name="Candidate Id")]
        public Guid? CandidateId { get; set; }
        public Publication Publication { get; set; }

        public string RawOutput { get; set; }
        public string ResponseCode { get; set; }
    }
}