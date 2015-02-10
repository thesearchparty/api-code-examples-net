using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Publication
    {
        [Display(Name = "Publication Id")]
        public Guid? Id { get; set; }

        [Display(Name = "Candidate Id")]
        public Guid CandidateId { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? PublicationYear { get; set; }
    }
}