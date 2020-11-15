using System;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Database");
            AddressRepo repo = new AddressRepo();
            int loop = 1;
            while (loop == 1)
            {
                Console.WriteLine("Choose \n1. View all records \n2. Update PhoneNumber or Email \n3. Delete contacts added in a date range \n4. Retrieve contacts by city and state \n5. Add new contact \n6. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.GetAllContacts();
                        break;
                    case 2:
                        Contact contact = new Contact();
                        Console.WriteLine("Enter FirstName");
                        contact.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter LastName");
                        contact.LastName = Console.ReadLine();
                        Console.WriteLine("Enter PhoneNumber");
                        contact.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Enter Email");
                        contact.Email = Console.ReadLine();
                        repo.UpdateContact(contact);
                        break;
                    case 3:
                        Console.WriteLine("Enter Start date");
                        DateTime startDate = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter End date");
                        DateTime endDate = Convert.ToDateTime(Console.ReadLine());
                        int contactsDeleted = repo.DeleteContactsAddedInADateRange(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
                        break;
                    case 4:
                        Console.WriteLine("Enter city");
                        string city = Console.ReadLine();
                        Console.WriteLine("Enter state");
                        string state = Console.ReadLine();
                        repo.RetrieveContactByCityOrState(city, state);
                        break;
                    case 5:
                        Contact newContact = new Contact();
                        Console.WriteLine("Enter the person details to be added in the address book");
                        Console.WriteLine("First Name");
                        newContact.FirstName = Console.ReadLine();
                        Console.WriteLine("Last Name");
                        newContact.LastName = Console.ReadLine();
                        Console.WriteLine("Address");
                        newContact.Address = Console.ReadLine();
                        Console.WriteLine("City");
                        newContact.City = Console.ReadLine();
                        Console.WriteLine("State");
                        newContact.State = Console.ReadLine();
                        Console.WriteLine("Zip code");
                        newContact.Zipcode = Console.ReadLine();
                        Console.WriteLine("Phone Number");
                        newContact.PhoneNumber = Console.ReadLine();
                        Console.WriteLine("Email");
                        newContact.Email = Console.ReadLine();
                        Console.WriteLine("ContactType");
                        newContact.RelationType = Console.ReadLine();
                        Console.WriteLine("Date added");
                        newContact.DateAdded = Convert.ToDateTime(Console.ReadLine());
                        bool isContactAdded = repo.AddContact(newContact);
                        break;
                    case 6:
                        loop = 0;
                        break;
                }
            }
        }
    }
}