using Aventyrliga_Kontakter.Model.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Aventyrliga_Kontakter.Model.DAL
{
    public class ContactDAL
    {
        private static string _connectionString;


        static ContactDAL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["1dv406_AdventureWorksAssignmentConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Contact>GetContacts()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var contacts = new List<Contact>(100);

                    var cmd = new SqlCommand("app.uspGetContacts", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactIdIndex = reader.GetOrdinal("ContactId");
                        var nameIndex = reader.GetOrdinal("NameId");
                        var lastNameIndex = reader.GetOrdinal("LastNameId");
                        var emailIdIndex = reader.GetOrdinal("EmailIdIndex");

                        while(reader.Read())
                        {
                            contacts.Add(new Contact
                            {
                                ContactId = reader.GetInt32(contactIdIndex),
                                Name = reader.GetString(nameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                Email = reader.GetString(emailIdIndex)
                            });
                        }
                    }
                    contacts.TrimExcess();
                    return contacts;
                }
                catch
                {
                    throw new ApplicationException("An Error occured");
                }
            }
        }
 
        public Contact GetContactById(int contactId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("app.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactId", contactId);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int contactIdIndex = reader.GetOrdinal("ContactId");
                            int nameIdIndex = reader.GetOrdinal("Name");
                            int lastNameIdIndex = reader.GetOrdinal("LastName");
                            int emailIdIndex = reader.GetOrdinal("Email");
                        };
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured");
                }
            }
        }

        internal static void InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        internal static void DeleteContact(int contactId)
        {
            throw new NotImplementedException();
        }

        internal static void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }    
}