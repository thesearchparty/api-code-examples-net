using CSharp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CSharp.API
{
    public class SearchPartyAPI
    {

        // Production api and authorisation urls
        private static string _baseApiUrl = ConfigurationManager.AppSettings["apiUrl"];
        private static string _baseAuthUrl = ConfigurationManager.AppSettings["authUrl"];
        private static string _protocolAuthServer = Convert.ToBoolean(ConfigurationManager.AppSettings["useSSL"]) == true ? "https" : "http";
        private static string _protocolAPI = "http";
        private static string _getAccessTokenUrl = String.Format("{0}://{1}/oauth2/token", _protocolAuthServer, _baseAuthUrl);

        public static SearchPartyWebResponse ListSectors()
        {
            var scopes = new List<string>() { "basic", "/services/filters.svc/listsectors" };
            var serviceUrl = String.Format("{0}://{1}/services/filters.svc/listsectors", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse ListSectors(int sectorId)
        {
            var scopes = new List<string>() { "basic", "/services/filters.svc/listsubsectors" };
            var serviceUrl = String.Format("{0}://{1}/services/filters.svc/listsubsectors?si=" + sectorId.ToString(), _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse ListCountries()
        {
            var scopes = new List<string>() { "basic", "/services/filters.svc/listcountries" };
            var serviceUrl = String.Format("{0}://{1}/services/filters.svc/listcountries", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse ListStates(int countryId)
        {
            var scopes = new List<string>() { "basic", "/services/filters.svc/liststates" };
            var serviceUrl = String.Format("{0}://{1}/services/filters.svc/liststates?co=" + countryId.ToString(), _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }


        public static SearchPartyWebResponse LocalityBestMatch(int countryId, int stateId, string postcode, string suburb)
        {
            string _stateID = stateId == -1 ? "" : stateId.ToString();

            var scopes = new List<string>() { "basic", "/services/filters.svc/localitybestmatch" };
            var serviceUrl = String.Format("{0}://{1}/services/filters.svc/localitybestmatch?lco=" + countryId.ToString() + "&lst=" + _stateID + "&lpo=" + postcode + "&lsu=" + suburb, _protocolAPI, _baseApiUrl);


            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse SearchVacancy(int pageIndex, string query)
        {
            var scopes = new List<string>() { "basic", "/services/vacancy.svc/search" };
            var serviceUrl = String.Format("{0}://{1}/services/vacancy.svc/search?q=" + query + "&page=" + pageIndex.ToString(), _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse SearchVacancy(SearchModel searchModel)
        {
            var scopes = new List<string>() { "basic", "/services/vacancy.svc/search" };
            var serviceUrl = String.Format("{0}://{1}/services/vacancy.svc/search?q=" + searchModel.Query + "&page=" + searchModel.PageIndex.ToString()
                                                    + "&si=" + searchModel.SectorId
                                                    + "&ssi=" + searchModel.SubSectorId
                                                    + "&pt=" + searchModel.SalaryTypeId
                                                    + "&minrate=" + searchModel.SalaryMin
                                                    + "&maxrate=" + searchModel.SalaryMax
                                                    + "&sdf=" + searchModel.StartDateFrom
                                                    + "&sdt=" + searchModel.StartDateTo
                                                    + "&edf=" + searchModel.EndDateFrom
                                                    + "&edt=" + searchModel.EndDateTo
                                                    + "&locid=" + searchModel.LocalityId
                                                    + "&lco=" + searchModel.CountryId
                                                    + "&lst=" + searchModel.StateId
                                                    + "&lsu=" + searchModel.Suburb
                                                    + "&lpo=" + searchModel.Postcode
                                                    + "&locrad=" + searchModel.LocationRadius
                                                    + "&type=Advanced"
                , _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse GetVacancy(string id)
        {
            var scopes = new List<string>() { "basic", "/services/vacancy.svc/get" };
            var serviceUrl = String.Format("{0}://{1}/services/vacancy.svc/get/" + id, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }


        public static SearchPartyWebResponse ListSalaryTypes()
        {
            var scopes = new List<string>() { "basic", "/services/filters.svc/listsalarytypes" };
            var serviceUrl = String.Format("{0}://{1}/services/filters.svc/listsalarytypes", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);

        }

        public static SearchPartyWebResponse GetCandidate(Guid id)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/candidates/" + id.ToString(), _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, "GET");
        }

        public static SearchPartyWebResponse AddCandidate(Candidate candidate)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/candidates", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(candidate), "POST");
        }

        public static SearchPartyWebResponse GetSkills(Guid CandidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/skills?candidateid=" + CandidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, "GET");
        }

        public static SearchPartyWebResponse AddSkill(Skill skill)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/skills", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(skill), "POST");
        }

        public static SearchPartyWebResponse DeleteSkill(Guid id, Guid candidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/skills?id=" + id + "&candidateId=" + candidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, method: "DELETE");
        }


        public static SearchPartyWebResponse AddEducationType(EducationType educationType)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/educationType", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(educationType), "POST");
        }

        public static SearchPartyWebResponse GetEducationTypes()
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/educationType", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse GetEducationRecords(Guid CandidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/education?candidateid=" + CandidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }


        public static SearchPartyWebResponse AddEducation(Education education)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/education", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(education), "POST");
        }

        public static SearchPartyWebResponse DeleteEducation(Guid id)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/education/" + id, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, method: "DELETE");

        }

        public static SearchPartyWebResponse GetEmploymentRecords(Guid CandidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/employment?candidateid=" + CandidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse AddEmployment(Employment employment)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/employment", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(employment), "POST");
        }

        public static SearchPartyWebResponse DeleteEmployment(Guid employmentId, Guid candidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/employment?employmentId=" + employmentId + "&candidateId=" + candidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, method: "DELETE");
        }


        public static SearchPartyWebResponse GetPublicationRecords(Guid CandidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/publications?candidateid=" + CandidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse AddPublication(Publication publication)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/publications", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(publication), "POST");
        }

        public static SearchPartyWebResponse DeletePublication(Guid publicationId, Guid candidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/publications?publicationId=" + publicationId + "&candidateId=" + candidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, method: "DELETE");
        }

        public static SearchPartyWebResponse GetCertificationRecords(Guid CandidateId)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/certifications?candidateid=" + CandidateId, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse AddCertification(Certification certification)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/certifications", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(certification), "POST");
        }

        public static SearchPartyWebResponse DeleteCertification(Guid id)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/certifications/" + id, _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, method: "DELETE");
        }

        public static SearchPartyWebResponse GetCertificationTypes()
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/certificationType", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl);
        }

        public static SearchPartyWebResponse AddCertificationType(CertificationType certificationType)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/certificationType", _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, Newtonsoft.Json.JsonConvert.SerializeObject(certificationType), "POST");
        }

        public static SearchPartyWebResponse PublishCandidateMarketplace(Guid id)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/marketplace/" + id.ToString(), _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, "", "POST");
        }

        public static SearchPartyWebResponse UnPublishCandidateMarketplace(Guid id)
        {
            var scopes = new List<string>() { "basic" };
            var serviceUrl = String.Format("{0}://{1}/1.0/marketplace/" + id.ToString(), _protocolAPI, _baseApiUrl);

            return CallApiServiceUsingHttp(scopes, serviceUrl, method: "DELETE");
        }


        /// <summary>
        /// Call Api using pure HTTP calls only.
        /// </summary>
        private static SearchPartyWebResponse CallApiServiceUsingHttp(IEnumerable<string> scopes, string serviceUrl, string data = "", string method = "GET")
        {
            string _clientName = HttpContext.Current.Session["apiKey"] != null ? HttpContext.Current.Session["apiKey"].ToString() : ConfigurationManager.AppSettings["apiKey"];
            string _clientSecret = HttpContext.Current.Session["apiSecret"] != null ? HttpContext.Current.Session["apiSecret"].ToString() : ConfigurationManager.AppSettings["apiSecret"];


            SearchPartyWebResponse apiResponse = new SearchPartyWebResponse();
            // ------------------------------------------------
            // STEP 1: GetClientAccessToken
            // ------------------------------------------------

            // Create POST data and convert it to a byte array.
            Console.WriteLine("Auth token url: " + _getAccessTokenUrl);
            var request1 = WebRequest.Create(_getAccessTokenUrl);
            request1.Method = "POST";
            request1.ContentType = "application/x-www-form-urlencoded";

            var postDataString = "grant_type=client_credentials";
            var scopesString = HttpUtility.UrlEncode(String.Join(" ", scopes));
            if (scopesString.Length > 0)
            {
                postDataString = postDataString + "&scope=" + scopesString;
            }

            var postData = Encoding.UTF8.GetBytes(postDataString);
            request1.ContentLength = postData.Length;

            var base64details = Base64Encode(String.Format("{0}:{1}", _clientName, _clientSecret));
            var authHeader = String.Format("Basic {0}", base64details);
            request1.Headers[HttpRequestHeader.Authorization] = authHeader;

            // Get the request stream.
            var dataStream = request1.GetRequestStream();
            dataStream.Write(postData, 0, postData.Length);
            dataStream.Close();

            // Get the response.
            var response1 = request1.GetResponse();
            var status = ((HttpWebResponse)response1).StatusDescription;
            dataStream = response1.GetResponseStream();
            var reader1 = new StreamReader(dataStream);
            var responseFromServer1 = reader1.ReadToEnd();
            reader1.Close();
            if (dataStream != null)
            {
                dataStream.Close();
            }
            response1.Close();

            var json = JObject.Parse(responseFromServer1);   // Server response string: { "access_token":"your_token_value", "token_type":"bearer", "expires_in":"3600", "scope":"basic \/services\/vacancy.svc\/list" }
            var accessToken = json["access_token"].Value<string>();

            try
            {

                // ------------------------------------------------
                // STEP 2: Call webservice with Auth token in Header
                // ------------------------------------------------
                var request2 = (HttpWebRequest)WebRequest.Create(serviceUrl);

                request2.Method = method;
                request2.Headers[HttpRequestHeader.Authorization] = String.Format("Bearer {0}", accessToken);
                request2.ContentType = "application/json";

                var postDataString2 = data;
                var postData2 = Encoding.UTF8.GetBytes(postDataString2);

                if (method == "POST")
                {
                    request2.ContentLength = postData2.Length;

                    var dataStream2 = request2.GetRequestStream();
                    dataStream2.Write(postData2, 0, postData2.Length);
                    dataStream2.Close();
                }

                var response2 = (HttpWebResponse)request2.GetResponse();
                apiResponse.StatusCode = response2.StatusCode;
                var reader2 = new StreamReader(response2.GetResponseStream());
                var responseFromServer2 = reader2.ReadToEnd();
                reader2.Close();


                response2.Close();
                apiResponse.JsonString = responseFromServer2;
                return apiResponse;

            }
            catch (WebException e)
            {
                // check e.Status as above etc..
                // return e.Response.GetResponseStream().
                var reader2 = new StreamReader(e.Response.GetResponseStream());
                var responseFromServer2 = reader2.ReadToEnd();
                apiResponse.StatusCode = ((HttpWebResponse)e.Response).StatusCode;
                apiResponse.JsonString = responseFromServer2;
                return apiResponse;
            }



        }

        private static string Base64Encode(string input)
        {
            var toEncodeAsBytes = Encoding.ASCII.GetBytes(input);
            return Convert.ToBase64String(toEncodeAsBytes);
        }

    }
}