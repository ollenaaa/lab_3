using lab_3.Models;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ReadBookingTest
    {
        private RestClient client = new RestClient("https://restful-booker.herokuapp.com/");
        private RestResponse response;
        private RestRequest request;

        [When(@"I send read the booking request")]
        public void WhenISendReadTheBookingRequest()
        {
            request = new RestRequest("booking", Method.Get);
            response = client.Execute<BookingModel>(request);
        }

        [Then(@"the response code should be OK")]
        public void ThenTheResponseCodeShouldBeOK()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
