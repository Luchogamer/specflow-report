using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ProyectoModulo3
{
    [Binding]
    public class PostItemStepDefinitions
    {
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product", Method.Post);
        RestResponse response;

        [Given(@"\[I have a valid auth token]")]
        public void GivenIHaveAValidAuthToken()
        {
            string authToken = GetAuthToken();
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddJsonBody(new
            {
                id = 40,
                name = "NewTestGlasses",
                slug = "NewTestGlasses",
                description = "<p>Some casual black &amp; blue glasses</p>",
                image = "casual-blackblue-open.jpg",
                price = 100,
                categoryId = 5,
                createdAt = "",
                updatedAt = ""
            });
        }

        [When(@"\[I do a call on a post request]")]
        public void WhenIDoACallOnAPostRequest()
        {
            var response = client.ExecutePost(request);
        }

        [Then(@"\[I got a valid Ok code response]")]
        public void ThenIGotAValidOkCodeResponse()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        private string GetAuthToken()
        {
            var client = new RestClient("http://demostore.gatling.io/api/authenticate");
            var request = new RestRequest("", Method.Post);
            request.AddJsonBody(new { username = "admin", password = "admin" });
            var response = client.Execute(request);
            var content = response.Content;
            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(content);
            return tokenResponse.Token;
        }
        public class TokenResponse
        {
            public string Token { get; set; }
        }
    }
}
