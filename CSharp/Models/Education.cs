using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Education
    {

        public Guid? Id { get; set; }

        [DisplayName("Candidate ID")]
        public Guid? CandidateId { get; set; }

        [DisplayName("Type")]
        public string EducationType { get; set; }

        [DisplayName("Type")]
        public Guid? EducationTypeId { get; set; }

        [DisplayName("Title")]
        public string EducationTitle { get; set; }

        public string City { get; set; }

        [DisplayName("Country")]
        public int? CountryId { get; set; }

        [DisplayName("Country")]
        public string CountryText { get; set; }

        public string Institution { get; set; }

        public string Grade { get; set; }

        [DisplayName("Award")]
        public string AwardType { get; set; }

        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
    }
}