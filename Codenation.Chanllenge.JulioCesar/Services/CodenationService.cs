using Codenation.Chanllenge.JulioCesar.Interfaces;
using Codenation.Chanllenge.JulioCesar.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Chanllenge.JulioCesar.Services
{
    public class CodenationService : ICodenationService
    {
        private readonly IRestClient _restClient;
        public CodenationService(IRestClient restClient)
        {
            _restClient = restClient;
            _restClient.BaseUrl = new Uri("https://api.codenation.dev");
        }
         
        public Cript GetCript(string token)
        {
            RestRequest req = new RestRequest("v1/challenge/dev-ps/generate-data", Method.GET);
            req.AddParameter("token", token);
            var response = _restClient.Execute(req);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<Cript>(response.Content);
            }
            else
            {
                throw response.ErrorException;
            }
        }

        public string SendFileDecript(string path, string fileName, string token)
        {
            RestRequest req = new RestRequest("v1/challenge/dev-ps/submit-solution", Method.GET);
            req.AddParameter("token", token);
            req.AlwaysMultipartFormData = true;
            req.AddHeader("Content-Type", "multipart/form-data");
            req.AddFile(fileName, path);

            var response = _restClient.Execute(req);
            if (response.IsSuccessful)
            {
                return response.Content;
            }
            else
            {
                throw response.ErrorException;
            }
        }
    }
}
