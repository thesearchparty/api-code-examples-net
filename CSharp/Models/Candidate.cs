using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Models
{
    public class Candidate
    {
        //#region Members

        public Guid Id { get; set; }

        [DisplayName("Link User")]
        public Guid? ContactSiteUserId { get; set; }

        [DisplayName("Candidate Number")]
        public string CandidateReference { get; set; }

        [DisplayName("Title")]
        public int? TitleId { get; set; }

        [DisplayName("First Name")]
        public string Firstname { get; set; }

        [DisplayName("Middle Name")]
        public string Middlename { get; set; }

        [DisplayName("Last Name")]
        public string Lastname { get; set; }

        [DisplayName("Known As")]
        public string KnownAsName { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Executive Summary")]
        public string ExecutiveSummary { get; set; }

        [DisplayName("Marketplace Summary")]
        public string MarketplaceSummary { get; set; }

        [DisplayName("Quick Notes")]
        public string QuickNotes { get; set; }

        [DisplayName("Home Tel")]
        public string Phone { get; set; }

        [DisplayName("Mobile Tel")]
        public string Mobile { get; set; }

        [DisplayName("Work Tel")]
        public string WorkPhone { get; set; }

        [DisplayName("Other Tel")]
        public string OtherPhone { get; set; }

        public string Fax { get; set; }

        [DisplayName("Gender")]
        public int? GenderId { get; set; }

        public string Twitter { get; set; }

        public string LinkedIn { get; set; }

        [DisplayName("Website Url")]
        public string WebsiteUrl { get; set; }

        [DisplayName("Alternate Email")]
        public string AlternateEmail { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }


        [DisplayName("Job Title")]
        public string CurrentJobTitle { get; set; }

        public string ABN { get; set; }

        public string ACN { get; set; }

        [DisplayName("1st Line")]
        public string PrimaryAddress1 { get; set; }

        [DisplayName("2nd Line")]
        public string PrimaryAddress2 { get; set; }

        [DisplayName("Suburb")]
        public string PrimarySuburb { get; set; }

        [DisplayName("State/Region")]
        public int? PrimaryStateId { get; set; }

        [DisplayName("State/Region")]
        public string PrimaryState { get; set; }

        [DisplayName("Postcode")]
        public string PrimaryPostcode { get; set; }

        [DisplayName("Country")]
        public int? PrimaryCountryId { get; set; }

        [DisplayName("Country")]
        public string PrimaryCountryText { get; protected set; }

        [DisplayName("1st Line")]
        public string SecondaryAddress1 { get; set; }

        [DisplayName("2nd Line")]
        public string SecondaryAddress2 { get; set; }

        [DisplayName("Suburb")]
        public string SecondarySuburb { get; set; }

        [DisplayName("State/Region")]
        public int? SecondaryStateId { get; set; }

        [DisplayName("State/Region")]
        public string SecondaryState { get; set; }

        [DisplayName("Postcode")]
        public string SecondaryPostcode { get; set; }

        [DisplayName("Country")]
        public int? SecondaryCountryId { get; set; }

        [DisplayName("Country")]
        public string SecondaryCountryText { get; protected set; }


        #region Rates

        [DisplayName("Payment Type")]
        public int? SalaryTypeId { get; set; }

        [DisplayName("Minimum")]
        public Decimal? MinHourlyRate { get; set; }

        [DisplayName("Minimum")]
        public Decimal? MinDailyRate { get; set; }

        [DisplayName("Minimum")]
        public Decimal? MinYearlyRate { get; set; }

        [DisplayName("Maximum")]
        public Decimal? MaxHourlyRate { get; set; }

        [DisplayName("Maximum")]
        public Decimal? MaxDailyRate { get; set; }

        [DisplayName("Maximum")]
        public Decimal? MaxYearlyRate { get; set; }

        #endregion

        #region Availbility

        [DisplayName("Availability")]
        public int AvailabilityId { get; set; }

        [DisplayName("Available From")]
        public DateTime? DateAvailableFrom { get; set; }

        [DisplayName("Temporary")]
        public bool IsPreferenceTemporary { get; set; }

        [DisplayName("Part-Time")]
        public bool IsPreferenceParttime { get; set; }

        [DisplayName("Full-Time")]
        public bool IsPreferenceFulltime { get; set; }

        [DisplayName("Contract")]
        public bool IsPreferenceContract { get; set; }

        [DisplayName("Available Relocate")]
        public bool IsAvailableRelocate { get; set; }

        [DisplayName("Available Travel")]
        public bool IsAvailableTravel { get; set; }

        [DisplayName("Has Transport")]
        public bool HasOwnTransport { get; set; }

        #endregion

        #region Notice

        [DisplayName("Notice In")]
        public int? NoticePeriodTypeId { get; set; }

        [DisplayName("Days")]
        public int? NoticePeriod { get; set; }

        #endregion

        #region Employment Preferences

        [DisplayName("Desired Job Title")]
        public string PreferredJobTitle { get; set; }

        [DisplayName("1st")]
        public string PreferredEmployer1 { get; set; }

        [DisplayName("2nd")]
        public string PreferredEmployer2 { get; set; }

        [DisplayName("3rd")]
        public string PreferredEmployer3 { get; set; }

        [DisplayName("4th")]
        public string PreferredEmployer4 { get; set; }

        [DisplayName("5th")]
        public string PreferredEmployer5 { get; set; }

        [DisplayName("1st")]
        public string PreferredSuburb1 { get; set; }

        [DisplayName("2nd")]
        public string PreferredSuburb2 { get; set; }

        [DisplayName("3rd")]
        public string PreferredSuburb3 { get; set; }

        [DisplayName("4th")]
        public string PreferredSuburb4 { get; set; }

        [DisplayName("5th")]
        public string PreferredSuburb5 { get; set; }

        [DisplayName("Radius (km)")]
        public int? TravelRadius { get; set; }

        [DisplayName("From")]
        public string TravelRadiusFromPostcode { get; set; }

        #endregion

        #region Citizenship

        public bool IsCitizen { get; set; }

        [DisplayName("Passport #")]
        public string PassportNumber { get; set; }
        public int? PassportIssueCountryId { get; set; }
        public bool HasVisa { get; set; }

        [DisplayName("Type")]
        public string VisaType { get; set; }

        [DisplayName("Valid Until")]
        public DateTime? VisaValidUntil { get; set; }

        [DisplayName("Restrictions")]
        public string VisaRestrictions { get; set; }

        [DisplayName("Document")]
        public Guid? VisaDocumentId { get; set; }

        [DisplayName("Nationality")]
        public string Nationality { get; set; }

        [DisplayName("Skills String")]
        public string SkillsString { get; set; }

        #endregion


    }

        //#endregion
}