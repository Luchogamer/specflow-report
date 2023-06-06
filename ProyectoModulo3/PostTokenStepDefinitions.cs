using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ProyectoModulo3
{
    [Binding]
    public class PostTokenStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/api/authenticate");
        RestRequest request = new RestRequest("", Method.Post);
        RestResponse response;
        [Given(@"I have a valid url")]
        public void GivenIHaveAValidUrl()
        {
            request.AddJsonBody(new { username = "admin", password = "admin" });

        }

        [When(@"I send a post request")]
        public void WhenISendAPostRequest()
        {
            response = client.ExecutePost(request);
        }

        [Then(@"I got a valid code response")]
        public void ThenIGotAValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}
