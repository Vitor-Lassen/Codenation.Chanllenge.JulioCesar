using Codenation.Chanllenge.JulioCesar.Interfaces;
using Codenation.Chanllenge.JulioCesar.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
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
            _restClient.Encoding = Encoding.UTF8;
        }
         
        public CriptDTO GetCript(string token)
        {
            RestRequest req = new RestRequest("v1/challenge/dev-ps/generate-data", Method.GET);
            req.AddParameter("token", token);
            var response = _restClient.Execute(req);
            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<CriptDTO>(response.Content);
            }
            else
            {
                throw response.ErrorException;
            }
        }

        public string SendFileDecript(string path, string fileName, string token)
        {
            RestRequest req = new RestRequest($"v1/challenge/dev-ps/submit-solution", Method.POST);
            req.AddParameter("token", token,ParameterType.QueryString);
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
