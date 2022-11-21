using lab_3.Models;
using NUnit.Framework;
using RestSharp;
using SpecFlow.Internal.Json;
using System;
using System.Collections.Immutable;
using System.Net;
using System.Text.Json;
using TechTalk.SpecFlow;
using static lab_3.Models.BookingModel;
using static lab_3.Models.BookingIdModel;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Linq;

namespace lab_3.StepDefinitions
{
    [Binding]
    public class UpdateBookingTest
    {
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private RestRequest request;
        private RestResponse response;
        private string token;
        private int id;

        public void GetAuthTokenAndId()
        {
            var authRequest = new RestRequest("auth", Method.Post);
            authRequest.AddHeaders(new Dictionary<string, string>
            {
                {"Content-Type", "application/json" }
            });
            
            authRequest.AddJsonBody(new { username = "admin", password = "password123" });
            var authResponse = client.Execute(authRequest);
            var t = client.Execute(new RestRequest("booking"));
            token = JsonConvert.DeserializeObject<TokenModel>(authResponse.Content).token;
            id = JsonConvert.DeserializeObject<List<BookingIdModel>>(client.Execute(new RestRequest("booking")).Content).LastOrDefault().bookingid;

        }
        [When(@"I create update booking")]
        public void WhenICreateUpdateBooking()
        {
            GetAuthTokenAndId();

            request = new RestRequest($"booking/{id}", Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddHeaders(new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"Content-Type", "application/json" },
                {"Cookie", $"token={token}" }
            });
            request.AddJsonBody(new
            {
                firstname = "Jame",
                lastname = "Dean",
                totalprice = 222,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Dinner"
            });

            response = client.Execute(request);
        }

        [Then(@"verify booking is updated")]
        public void ThenVerifyBookingIsUpdated()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
