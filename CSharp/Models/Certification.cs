using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Certification
    {

        public Guid? Id { get; set; }
        public Guid CandidateId { get; set; }

        [DisplayName("Certification")]
        public Guid? CertificationId { get; set; }

        [DisplayName("Certification")]
        public string CertificationTitle { get; set; }

        [DisplayName("Gained")]
        public DateTime? DateGained { get; set; }

        [DisplayName("Valid To")]
        public DateTime? DateValidTo { get; set; }

        [DisplayName("Awarder")]
        public string CertifyingBody { get; set; }

        public string Title { get; set; }

        public string Limitations { get; set; }

        [DisplayName("Additional Info")]
        public string AdditionalInformation1 { get; set; }

        [DisplayName("Additional Info 2")]
        public string AdditionalInformation2 { get; set; }

        public string Grade { get; set; }
    }
}