using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharp.Models
{
    public class Vacancy
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public int SectorId { get; set; }
        public string SectorTitle { get; set; }
        public int? SubSectorId { get; set; }
        public string SubSectorTitle { get; set; }
        public string UserReference { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string FullDescription { get; set; }
        public DateTime? DateCommences { get; set; }
        public DateTime? DateFinishes { get; set; }
        public decimal FullTimeEquivalent { get; set; }
        public string PaymentRateType { get; set; }
        public bool IsPayRateVisible { get; set; }
        public string DisplayRateOverride { get; set; }
        public decimal? MinHourlyRate { get; set; }
        public decimal? MinDailyRate { get; set; }
        public decimal? MinYearlyRate { get; set; }
        public decimal? MaxHourlyRate { get; set; }
        public decimal? MaxDailyRate { get; set; }
        public decimal? MaxYearlyRate { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public int? LocationStateId { get; set; }
        public string LocationPostCode { get; set; }
        public string LocationCountry { get; set; }
        public int? LocationCountryId { get; set; }
        public string DisplayLocationOverride { get; set; }
        public string VacancyType { get; set; }
        public string ApplyURL { get; set; }
    }
}