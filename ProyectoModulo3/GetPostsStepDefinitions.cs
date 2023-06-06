using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ProyectoModulo3
{
    [Binding]
    public class GetPostsStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product/{id}", Method.Get);
        RestResponse response;
        [Given(@"I have a valid id")]
        public void GivenIHaveAValidId()
        {
            request.AddUrlSegment("id", "17");
        }

        [When(@"Isend a get request")]
        public void WhenIsendAGetRequest()
        {
            response = client.ExecuteGet(request);
        }

        [Then(@"I spected a valid code response")]
        public void ThenISpectedAValidCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
    }
}
