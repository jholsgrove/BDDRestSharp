namespace Rest.API.Tests.Helpers
{
    using RestSharp;

    public class RestHelper
    {
        public RestClient endpoint = null;

        public RestClient SetEndpoint(string endpointUrl)
        {
            endpoint = new RestClient(endpointUrl);
            return endpoint;
        }

        public string RestGetQuery(string query)
        {
            var request = new RestRequest(query, Method.GET);
            IRestResponse response = endpoint.Execute(request);
            var content = response.Content; // raw content as string
            return content;
        }

        public string GetQuery(string query)
        {
            var request = new RestRequest(query, Method.GET);
            IRestResponse response = endpoint.Execute(request);
            var content = response.Content; // raw content as string
            return content;
        }

        public void UpdatePrice(string query, string price)
        {
            var request = new RestRequest(query, Method.POST) { RequestFormat = DataFormat.Xml };
            var body = ("<resource><PRICE>" + price + "</PRICE></resource>");
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            endpoint.Execute(request);
        }

        public void DeleteCustomer(string query)
        {
            var request = new RestRequest(query, Method.DELETE);
            endpoint.Execute(request);
        }
    }
}