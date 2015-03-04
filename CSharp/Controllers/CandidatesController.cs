using CSharp.API;
using CSharp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class CandidatesController : Controller
    {
        //
        // GET: /Candidates/

        public ActionResult Index(Guid? id)
        {

            CandidateModel candidateModel = new CandidateModel();

            if (id.HasValue)
            {
                var candidateString = SearchPartyAPI.GetCandidate((Guid)id).JsonString;
                if (!String.IsNullOrEmpty(candidateString))
                {
                    var candidateObject = JsonConvert.DeserializeObject<Candidate>(candidateString);
                    candidateModel.Id = candidateObject.Id;
                    candidateModel.Candidate = candidateObject;

                    candidateModel.RawOutput = JsonHelper.FormatJson(candidateString);
                }
            }

            SetupModel(candidateModel);


            return View(candidateModel);
        }

        public ActionResult Skills(Guid? CandidateId)
        {
            SkillsModel model = new SkillsModel();

            if (CandidateId.HasValue)
            {
                var apiResponse = SearchPartyAPI.GetSkills(CandidateId.Value);
                model.RawOutput = JsonHelper.FormatJson(apiResponse.JsonString);
                model.ResponseCode = apiResponse.StatusCode.HasValue ? apiResponse.StatusCode.Value.ToString() : "";
            }

            return View("skills", model);
        }

        public ActionResult SkillsAdd()
        {
            SkillsModel model = new SkillsModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult SkillsAdd(SkillsModel model)
        {
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddSkill(model.Skill).JsonString);

            return View("skillsAdd", model);
        }

        [HttpPost]
        public ActionResult SkillsDelete(SkillsModel model)
        {
            if (model.Skill.Id.HasValue && model.Skill.CandidateId.HasValue)
            {
                SearchPartyWebResponse apiResponse = SearchPartyAPI.DeleteSkill(model.Skill.Id.Value, model.Skill.CandidateId.Value);
                model.RawOutput = JsonHelper.FormatJson(apiResponse.JsonString);
                model.ResponseCode = apiResponse.StatusCode.HasValue ? apiResponse.StatusCode.Value.ToString() : "";
            }

            return View("skillsAdd", model);
        }


        public ActionResult Education(Guid? CandidateId)
        {
            EducationModel model = new EducationModel();

            if (CandidateId.HasValue)
            {
                model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetEducationRecords(CandidateId.Value).JsonString);
            }

            return View("education", model);
        }

        public ActionResult EducationAddEdit()
        {
            EducationModel model = new EducationModel();

            SetupEducationModel(model);

            return View("educationAddEdit", model);
        }


        [HttpPost]
        public ActionResult EducationAdd(EducationModel model)
        {
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddEducation(model.Education).JsonString);

            SetupEducationModel(model);

            return View("educationAddEdit", model);
        }

        public ActionResult EducationDelete()
        {
            EducationModel model = new EducationModel();

            SetupEducationModel(model);

            return View("educationDelete", model);
        }

        [HttpPost]
        public ActionResult EducationDelete(EducationModel model)
        {
            if (model.Education.Id.HasValue)
            {
                var response = SearchPartyAPI.DeleteEducation(model.Education.Id.Value);
                model.ResponseCode = response.StatusCode.HasValue ? response.StatusCode.Value.ToString() : "";
            }

            return View("educationDelete", model);
        }


        public ActionResult EducationTypes(Guid? id)
        {
            ViewBag.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetEducationTypes().JsonString);

            return View();
        }

        public ActionResult AddEducationType(EducationType educationType)
        {

            ViewBag.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddEducationType(educationType).JsonString);


            return View("educationTypes");
        }


        public ActionResult Employment(Guid? CandidateId)
        {

            //ViewBag.RawOutput = SearchPartyAPI.AddEducationType(educationType);
            EmploymentModel model = new EmploymentModel();

            if (CandidateId.HasValue)
            {
                model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetEmploymentRecords(CandidateId.Value).JsonString);
            }

            return View("employment", model);
        }

        public ActionResult EmploymentAddEdit()
        {
            EmploymentModel model = new EmploymentModel();
            return View("employmentAddEdit", model);
        }

        [HttpPost]
        public ActionResult EmploymentAddEdit(EmploymentModel model)
        {

            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddEmployment(model.Employment).JsonString);

            return View("employmentAddEdit", model);
        }

        public ActionResult EmploymentDelete()
        {
            EmploymentModel model = new EmploymentModel();
            return View("employmentdelete", model);
        }

        [HttpPost]
        public ActionResult EmploymentDelete(EmploymentModel model)
        {
            if (model.Employment.Id.HasValue && model.Employment.CandidateId.HasValue)
            {
                var response = SearchPartyAPI.DeleteEmployment(model.Employment.Id.Value, model.Employment.CandidateId.Value);
                model.ResponseCode = response.StatusCode.HasValue ? response.StatusCode.Value.ToString() : "";

            }
            return View("EmploymentDelete", model);
        }

        public ActionResult Publications(Guid? CandidateId)
        {
            PublicationModel model = new PublicationModel();

            if (CandidateId.HasValue)
            {
                model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetPublicationRecords(CandidateId.Value).JsonString);
            }


            return View("publications", model);
        }


        public ActionResult PublicationsAddEdit()
        {
            PublicationModel model = new PublicationModel();
            return View("publicationAddEdit", model);
        }

        [HttpPost]
        public ActionResult PublicationsAddEdit(PublicationModel model)
        {
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddPublication(model.Publication).JsonString);

            return View("publicationAddEdit", model);
        }


        public ActionResult PublicationsDelete()
        {
            PublicationModel model = new PublicationModel();
            return View("PublicationsDelete", model);
        }

        [HttpPost]
        public ActionResult PublicationsDelete(PublicationModel model)
        {

            if (model.Publication.Id.HasValue)
            {
                var response = SearchPartyAPI.DeletePublication(model.Publication.Id.Value, model.Publication.CandidateId);
                model.ResponseCode = response.StatusCode.HasValue ? response.StatusCode.Value.ToString() : "";
            }

            return View("PublicationsDelete", model);
        }


        public ActionResult Certifications(Guid? CandidateId)
        {
            CertificationsModel model = new CertificationsModel();

            if (CandidateId.HasValue)
            {
                model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetCertificationRecords(CandidateId.Value).JsonString);
            }


            return View("certifications", model);
        }


        public ActionResult CertificationsAddEdit()
        {
            CertificationsModel model = new CertificationsModel();

            var certTypes = JArray.Parse(SearchPartyAPI.GetCertificationTypes().JsonString);
            IEnumerable<SelectListItem> certTypesItems = (from s in certTypes
                                                          select new SelectListItem()
                                                          {
                                                              Text = s.Value<string>("Title"),
                                                              Value = s.Value<string>("Id")
                                                          });

            model.CertificationTypes = certTypesItems;

            return View("CertificationAddEdit", model);
        }

        [HttpPost]
        public ActionResult CertificationsAddEdit(CertificationsModel model)
        {
            model.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddCertification(model.Certification).JsonString);

            var certTypes = JArray.Parse(SearchPartyAPI.GetCertificationTypes().JsonString);
            IEnumerable<SelectListItem> certTypesItems = (from s in certTypes
                                                          select new SelectListItem()
                                                          {
                                                              Text = s.Value<string>("Title"),
                                                              Value = s.Value<string>("Id")
                                                          });

            model.CertificationTypes = certTypesItems;

            return View("CertificationAddEdit", model);
        }

        public ActionResult CertificationsDelete()
        {
            CertificationsModel certificationsModel = new CertificationsModel();

            return View("CertificationsDelete", certificationsModel);
        }

        [HttpPost]
        public ActionResult CertificationsDelete(CertificationsModel certificationsModel)
        {
            if (certificationsModel.Certification.Id.HasValue)
            {
                var response = SearchPartyAPI.DeleteCertification(certificationsModel.Certification.Id.Value);
                certificationsModel.ResponseCode = response.StatusCode.HasValue ? response.StatusCode.Value.ToString() : "";

            }
            return View("CertificationsDelete", certificationsModel);
        }


        [HttpPost]
        public ActionResult AddCertificationType(CertificationType model)
        {
            ViewBag.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.AddCertificationType(model).JsonString);

            return View("CertificationTypes", model);
        }

        public ActionResult CertificationTypes()
        {

            ViewBag.RawOutput = JsonHelper.FormatJson(SearchPartyAPI.GetCertificationTypes().JsonString);

            return View();
        }


        public ActionResult AddCandidate(CandidateModel candidateModel)
        {

            var returnObject = SearchPartyAPI.AddCandidate(candidateModel.Candidate).JsonString;

            var candidateObject = JsonConvert.DeserializeObject<Candidate>(returnObject);

            //if DeserializeObject failed then id will be empty
            if (candidateObject.Id == Guid.Empty)
            {
                ModelState.Remove("IsError");
                candidateModel.IsError = "true";
                candidateModel.RawOutput = JsonHelper.FormatJson(returnObject);
                SetupModel(candidateModel);
                return View("index", candidateModel);
            }


            return Redirect("/candidates?id=" + candidateObject.Id.ToString());
        }


        private void SetupModel(CandidateModel candidateModel)
        {
            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });

            candidateModel.Countries = countryItems;

            var states = JArray.Parse(SearchPartyAPI.ListStates(6).JsonString);  // Australia ID === 6
            IEnumerable<SelectListItem> stateItems = (from s in states
                                                      select new SelectListItem()
                                                      {
                                                          Text = s.Value<string>("ShortTitle"),
                                                          Value = s.Value<string>("Id")
                                                      });
            candidateModel.States = stateItems;

            if ((candidateModel.Candidate != null && candidateModel.Candidate.Id == Guid.Empty) || candidateModel.Candidate == null)
                candidateModel.Id = null;
            else
                candidateModel.Id = candidateModel.Candidate.Id;

        }

        private void SetupEducationModel(EducationModel model)
        {
            var educationTypes = JArray.Parse(SearchPartyAPI.GetEducationTypes().JsonString);
            IEnumerable<SelectListItem> educationTypeItems = (from s in educationTypes
                                                              select new SelectListItem()
                                                              {
                                                                  Text = s.Value<string>("Title"),
                                                                  Value = s.Value<string>("Id")
                                                              });

            model.EducationTypes = educationTypeItems;

            var countries = JArray.Parse(SearchPartyAPI.ListCountries().JsonString);
            IEnumerable<SelectListItem> countryItems = (from s in countries
                                                        select new SelectListItem()
                                                        {
                                                            Text = s.Value<string>("Name"),
                                                            Value = s.Value<string>("Id")
                                                        });

            model.Countries = countryItems;
        }

    }


}
