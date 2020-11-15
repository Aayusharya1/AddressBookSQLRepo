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
                Console.WriteLine("Choose \n1. View all records \n2. Update PhoneNumber or Email \n3. Exit");
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
                        loop = 0;
                        break;
                }
            }
        }
    }
}