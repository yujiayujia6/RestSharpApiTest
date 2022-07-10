using RestSharp;
using RestSharpUtilities;
using System;
using TechTalk.SpecFlow;

namespace DemoTest.StepDefinitions
{
    [Binding]
    public class GetMethodTestStepDefinitions
    {
        private const string BASE_URL = "https://reqres.in/";
        private RestResponse? response;

        [Given(@"I send create user request")]
        public async System.Threading.Tasks.Task GivenISendCreateUserRequest()
        {
            var api = new ApiFunctions();
            response = await api.GetUsers(BASE_URL);
        }

        [Then(@"validate user list get success")]
        public void ThenValidateUserListGetSuccess()
        {
            // Console.WriteLine(response.ToString());
            //TODO Assert.AreEqual("OK", statusCode);
        }
    }
}
