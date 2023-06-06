using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace ProyectoModulo3
{
    [Binding]
    

    public class PutItemStepDefinitions
    {
        
        RestClient client = new RestClient("http://demostore.gatling.io/");
        RestRequest request = new RestRequest("api/product/{id}", Method.Put);
        RestResponse response;

        [Given(@"I have a checked id")]
        public void GivenIHaveACheckedId()
        {
            string authToken = GetAuthToken();
            request.AddHeader("Authorization", "Bearer " + authToken);
            request.AddUrlSegment("id", "17");
            request.AddJsonBody(new
            {
                id = 17,
                name = "TestGlasses",
                slug = "TestGlasses",
                description = "<p>Some casual black &amp; blue glasses</p>",
                image = "casual-blackblue-open.jpg",
                price = 24.99,
                categoryId = 5,
                createdAt = "2020-11-10T10:05:14",
                updatedAt = ""
            });
        }
        [When(@"I send a put request")]
        public void WhenISendAPutRequest()
        {
            response = client.ExecutePut(request);
        }

        [Then(@"I got an OK code response")]
        public void ThenIGotAnOKCodeResponse()
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
