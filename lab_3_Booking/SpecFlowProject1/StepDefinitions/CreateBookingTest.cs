using lab_3.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using static lab_3.Models.BookingModel;

namespace lab_3.StepDefinitions
{
    [Binding]
    public class CreateBookingTest
    {
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private RestResponse response;
        private RestRequest request;

        [Given(@"I send create booking request")]
        public void GivenISendCreateBookingRequest()
        {
            request = new RestRequest("booking", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddHeaders(new Dictionary<string, string>
            {
                {"Accept", "application/json"},
                {"Content-Type", "application/json"}
            });
            request.AddJsonBody(new
            {
                firstname = "Jim",
                lastname = "Brown",
                totalprice = 111,
                depositpaid = true,
                bookingdates = new
                {
                    checkin = "2018-01-01",
                    checkout = "2019-01-01"
                },
                additionalneeds = "Breakfast"
            });
 
            response = client.Execute(request);
        }

        [Then(@"booking is created")]
        public void ThenBookingIsCreated()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}

