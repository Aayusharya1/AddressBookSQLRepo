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
                Console.WriteLine("Choose \n1. View all records \n2. Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.GetAllContacts();
                        break;
                    case 2:
                        loop = 0;
                        break;
                }
            }
        }
    }
}