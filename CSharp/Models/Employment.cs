using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Employment
    {
        [Display(Name="Employment ID")]
        public Guid? Id { get; set; }

        [Display(Name="Candidate ID")]
        public Guid? CandidateId { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public int? StartDateYear { get; set; }

        public int? StartDateMonth { get; set; }

        public int? EndDateYear { get; set; }

        public int? EndDateMonth { get; set; }

        public string Duration { get; set; }

        public bool IsCurrent { get; set; }
    }
}