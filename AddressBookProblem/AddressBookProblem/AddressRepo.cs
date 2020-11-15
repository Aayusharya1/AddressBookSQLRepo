using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookProblem
{
    public class AddressRepo
    {
        public static string connectionString = @"Data Source=.;Initial Catalog=Address_Book_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllContacts()
        {
            try
            {
                Contact contact = new Contact();
                using (this.connection)
                {
                    string query = @"select * from AddressBook inner join ContactType1 on AddressBook.FirstName =ContactType1.FirstName";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            contact.FirstName = !dr.IsDBNull(0) ? dr.GetString(0) : "";
                            contact.LastName = !dr.IsDBNull(1) ? dr.GetString(1) : "";
                            contact.PhoneNumber = !dr.IsDBNull(6) ? dr.GetString(6) : "";
                            contact.Email = !dr.IsDBNull(7) ? dr.GetString(7) : "";
                            contact.RelationType = !dr.IsDBNull(10) ? dr.GetString(10) : "";
                            contact.Address = !dr.IsDBNull(2) ? dr.GetString(2) : "";
                            contact.City = !dr.IsDBNull(3) ? dr.GetString(3) : "";
                            contact.State = !dr.IsDBNull(4) ? dr.GetString(4) : "";
                            contact.Zipcode = !dr.IsDBNull(5) ? dr.GetString(5) : "";
                            System.Console.WriteLine(contact.FirstName + "," + contact.LastName + "," + contact.PhoneNumber + "," + contact.Email + "," + contact.RelationType + "," + contact.Address + "," + contact.City +
                                "," + contact.State + "," + contact.Zipcode);
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public bool UpdateContact(Contact contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"Update AddressBook set Phone = '" + contact.PhoneNumber + "', Email = '" + contact.Email +
                        "' where FirstName = '" + contact.FirstName + "' and LastName = '" + contact.LastName + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public int DeleteContactsAddedInADateRange(string startDate, string endDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int contactsDeleted = 0;
            try
            {
                using (connection)
                {
                    string query = @"delete from AddressBook where DateAdded between '" + startDate + "' and '" + endDate + "';";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    contactsDeleted = cmd.ExecuteNonQuery();
                    if (contactsDeleted > 0)
                    {
                        Console.WriteLine(contactsDeleted + " contacts affected");
                    }
                    else
                    {
                        Console.WriteLine("Please check your query");
                    }
                }
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return contactsDeleted;
        }
    }
}