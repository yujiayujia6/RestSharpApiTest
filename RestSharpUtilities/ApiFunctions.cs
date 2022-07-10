using Newtonsoft.Json;
using RestSharp;
using RestSharpUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpUtilities
{
    public class ApiFunctions
    {
        private Helper helper;

        public ApiFunctions()
        {
            helper = new Helper();
        }
        public async Task<RestResponse> GetUsers(string baseUrl)
        {
            //helper.AddCertificate("", "");
            var client = helper.SetUrl(baseUrl, "api/users?page=2");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }

        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}