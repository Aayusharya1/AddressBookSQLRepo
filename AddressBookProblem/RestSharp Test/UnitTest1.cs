using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
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

        [TestMethod]
        public void GivenMultipleContacts_WhenPosted_ShouldReturnAddedContacts()
        {
            //arrange
            List<Contact> list = new List<Contact>();
            list.Add(new Contact { name = "Aay", Address = "Street lmn" });
            list.Add(new Contact { name = "Aay1", Address = "Street lmn1" });
            foreach (Contact contact in list)
            {
                //act
                RestRequest request = new RestRequest("/Address", Method.POST);
                JObject jObject = new JObject();
                jObject.Add("Name", contact.name);
                jObject.Add("Address", contact.Address);
                request.AddParameter("application/json", jObject, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                //Assert
                Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
                Contact dataResponse = JsonConvert.DeserializeObject<Contact>(response.Content);
                Assert.AreEqual(contact.name, dataResponse.name);
                Assert.AreEqual(contact.Address, dataResponse.Address);
            }
        }

        [TestMethod]
        public void GivenContact_WhenUpdated_ShouldReturnUpdatedContact()
        {
            //arrange
            RestRequest request = new RestRequest("/Address/5", Method.PUT);
            JObject jObject = new JObject();
            jObject.Add("Name", "Aay");
            jObject.Add("Address", "Street 123");
            //act
            request.AddParameter("application/json", jObject, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //assert
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            Contact dataResponse = JsonConvert.DeserializeObject<Contact>(response.Content);
            Assert.AreEqual("Aay", dataResponse.name);
            Assert.AreEqual("Street 123", dataResponse.Address);
            Console.WriteLine(response.Content);
        }
    }
}
