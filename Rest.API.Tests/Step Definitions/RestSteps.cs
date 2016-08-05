namespace Rest.API.Tests.Step_Definitions
{
    using Helpers;
    using TechTalk.SpecFlow;
    using NUnit.Framework;

    [Binding]
    internal class RestSteps
    {
        private readonly RestHelper Rest = new RestHelper();

        private string queryResult = null;

        [Given(@"I have an example endpoint (.*)")]
        public void GivenIHaveAnExampleEndpoint(string restEndpoint)
        {
            Rest.SetEndpoint(restEndpoint);
        }

        [When(@"I search for all customers")]
        public void WhenISearchForAllCustomers()
        {
            queryResult = Rest.GetQuery("CUSTOMER/0/");
        }

        [When(@"I search for customer record (.*)")]
        public void WhenISearchForCustomerRecord(string customerNo)
        {
            queryResult = Rest.GetQuery("CUSTOMER/" + customerNo + "/");
        }

        [Then(@"the result contains customer (.*)")]
        public void ThenTheResultContainsCustomer(string customerNo)
        {
            Assert.IsTrue(queryResult.Contains(customerNo));
        }

        [Given(@"I update the price of Product (.*) to (.*)")]
        [Then(@"I reset the price of product (.*) to (.*)")]
        public void GivenIUpdateThePriceOfProductTo(int productNo, string newPrice)
        {
            Rest.UpdatePrice("PRODUCT/" + productNo +"/", newPrice);
        }

        [When(@"I search for Product (.*)")]
        public void WhenISearchForProduct(int productNo)
        {
            queryResult = Rest.GetQuery("PRODUCT/" + productNo + "/");
        }

        [Then(@"the price is (.*)")]
        public void ThenThePriceIs(string newPrice)
        {
            Assert.IsTrue(queryResult.Contains(newPrice), "Price did not update.");
        }
    }
}