using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ReadTheMealStepDefinitions
    {
        private RestClient client = new RestClient("https://www.themealdb.com/api/json/v1/1/");
        private RestResponse response;
        private string category;

        [Given(@"I input category of meal")]
        public void GivenIInputCategoryOfMeal()
        {
            category = "Seafood";
        }

        [When(@"I send a read meal request")]
        public void WhenISendAReadMealRequest()
        {
            RestRequest request = new RestRequest($"filter.php?c={category}", Method.Get);
            response = client.Execute(request);
        }

        [Then(@"verify that chosen category of meal is readed")]
        public void ThenVerifyThatChosenCategoryOfMealIsReaded()
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
