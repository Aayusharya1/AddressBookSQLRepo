using NUnit.Framework;
using AddressBookProblem;
using System;

namespace AddressBookTest
{
    public class Tests
    {
        AddressRepo repo = new AddressRepo();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenNewContactDetails_WhenUpdated_ShouldSyncWithDataBase()
        {
            Contact contact = new Contact()
            {
                FirstName = "Aayu",
                LastName = "Arya",
                PhoneNumber = "9111111111",
                Email = "aayush.aryaaa"
            };
            bool result = repo.UpdateContact(contact);
            Assert.AreEqual(true, result);
        }
        [Test]
        public void GivenADateRange_WhenAnalysed_ShouldDeleteContactsAddedInThatRange()
        {
            int expected = 1;
            int actual = repo.DeleteContactsAddedInADateRange("2020-01-01", "2020-12-31");
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GivenContactInformation_WhenAdded_ShouldBeAddedInTheDB()
        {
            Contact contact = new Contact()
            {
                FirstName = "Aayush",
                LastName = "Arya",
                PhoneNumber = "+91 9988899999",
                Email = "aaayush@gmail",
                Address = "xyz",
                City = "New Delhi",
                State = "Delhi",
                DateAdded = Convert.ToDateTime("08-06-2020"),
                RelationType = "Friend",
                Zipcode = "110011"
            };
            bool result = repo.AddContact(contact);
            Assert.AreEqual(true, result);
        }
    }
}