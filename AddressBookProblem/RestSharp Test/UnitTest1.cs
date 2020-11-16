using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace RestSharp_Test
{

    class Contact
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
    }


    [TestClass]
    public class UnitTest1
    {
        RestClient client = new RestClient("http://localhost:3000");

        private IRestResponse GetContactList()
        {
            RestRequest request = new RestRequest("/Address", Method.GET);
            //act
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void WhenCallGetApi_ReturnContactList()
        {
            IRestResponse response = GetContactList();
            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            List<Contact> dataResponse = JsonConvert.DeserializeObject<List<Contact>>(response.Content);
            Assert.AreEqual(4, dataResponse.Count);
        }
    }
}
