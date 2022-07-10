using RestSharp;
using RestSharpUtilities;
using RestSharpUtilities.Models;

namespace DemoTest.StepDefinitions
{
    [Binding]
    internal class PostStepDefinitions
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserReq createUserReq;
        private RestResponse response;

        public PostStepDefinitions(CreateUserReq createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [Given(@"I input name (.*) and role (.*)")]
        public void GivenIInputNameTomAndRoleQA(string name, string role)
        {
            createUserReq.name = name;
            createUserReq.job = role;
        }

        [When(@"I send create user request")]
        public async System.Threading.Tasks.Task WhenISendCreateUserRequestAsync()
        {
            var api = new ApiFunctions();
            response = await api.CreateNewUser(BASE_URL, createUserReq);
        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserReq.name, content.name);
            Assert.AreEqual(createUserReq.job, content.job);
        }

    }
}
