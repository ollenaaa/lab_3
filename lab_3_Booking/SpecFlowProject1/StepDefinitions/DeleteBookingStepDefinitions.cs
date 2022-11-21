using lab_3.Models;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;
using JsonSerializer = System.Text.Json.JsonSerializer;
using static lab_3.Models.BookingIdModel;

namespace lab_3.StepDefinitions
{
    [Binding]
    public class DeleteBookingStepDefinitions
    {
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private RestResponse<BookingModel> response;
        private string token;
        private int id;

        public void GetAuthTokenAndId()
        {
            var authRequest = new RestRequest("auth", Method.Post);
            authRequest.AddJsonBody(new { username = "admin", password = "password123" });
            var authResponse = client.Execute(authRequest);

            token = JsonConvert.DeserializeObject<TokenModel>(authResponse.Content).token;
            id = JsonConvert.DeserializeObject<List<BookingIdModel>>(client.Execute(new RestRequest("booking")).Content).FirstOrDefault().bookingid;
            
        }

        [When(@"I send request for delete the booking")]
        public void WhenISendRequestForDeleteTheBooking()
        {
            GetAuthTokenAndId();

            RestRequest request = new RestRequest($"booking/{id}", Method.Delete);
            
            request.AddHeaders(new Dictionary<string, string>
            {
                {"Content-Type", "application/json"},
                {"Cookie", $"token={token}" }
            });

            response = client.Execute<BookingModel>(request);
        }

        [Then(@"booking is deleted")]
        public void ThenBookingIsDeleted()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }
    }
}
