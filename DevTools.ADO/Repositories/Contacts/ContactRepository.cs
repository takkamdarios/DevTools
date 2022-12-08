using DevTools.ADO.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Repositories.Contacts
{
    /// <summary>
    /// This class manage all methods describe in IContactRepository
    /// </summary>
    internal class ContactRepository : IContactRepository
    {
        #region Properties (Private)
        private readonly string connectionString;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ContactRepository()
        {
            connectionString = "Data Source=localhost;port=3306;Initial Catalog=contact_management_db;User Id=root;password=@susOwijO1";
            //connectionString = "Data Source=localhost user=root password=@susOwijO1";
        }
        #endregion

        #region Methods (Public)
        public void Add(Contact entity)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_create_contact", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_firstname", entity.FirstName);
                cmd.Parameters.AddWithValue("_lastname", entity.LastName);
                cmd.Parameters.AddWithValue("_postalcode", entity.PostalCode);
                cmd.Parameters.AddWithValue("_email", entity.Email);
                cmd.Parameters.AddWithValue("_city", entity.City);
                cmd.Parameters.AddWithValue("_province", entity.Province);
                cmd.Parameters.AddWithValue("_phonenumber", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("_createon", DateTime.Now.ToString("yyyy/MM/dd"));

                con.Open();
                // 1 = success ; -1 = failed
                var status = cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_delete_contact", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_id", id);

                con.Open();
                // 1 = success ; -1 = failed
                var status = cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public Contact Get(int id)
        {
            Contact contact = null;
            using (var con = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("sp_get_contact", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_id", id);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                // fetch data if rows exists
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        contact = new Contact()
                        {
                            Id = reader.GetInt32("id"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            PostalCode = reader.GetString("PostalCode"),
                            City = reader.GetString("City"),
                            Email = reader.GetString("Email"),
                            Province = reader.GetString("Province"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            CreateOn = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime("createon"),
                            UpdateOn = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime("updateon"),
                        };
                    }
                }
            }
            return contact;
        }

        public ICollection<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            using (var con = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("sp_get_contacts", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                // fetch data if rows exists
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var contact = new Contact()
                        {
                            Id = reader.GetInt32("id"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            PostalCode = reader.GetString("PostalCode"),
                            City = reader.GetString("City"),
                            Email = reader.GetString("Email"),
                            Province = reader.GetString("Province"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            CreateOn = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime("createon"),
                            UpdateOn = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime("updateon"),
                        };
                        // add contact to list
                        contacts.Add(contact);
                    }
                }
            }
            return contacts;
        }

        public void Update(int id, Contact entity)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_update_contact", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_id", id);
                cmd.Parameters.AddWithValue("_firstname", entity.FirstName);
                cmd.Parameters.AddWithValue("_lastname", entity.LastName);
                cmd.Parameters.AddWithValue("_postalcode", entity.PostalCode);
                cmd.Parameters.AddWithValue("_email", entity.Email);
                cmd.Parameters.AddWithValue("_city", entity.City);
                cmd.Parameters.AddWithValue("_province", entity.Province);
                cmd.Parameters.AddWithValue("_phonenumber", entity.PhoneNumber);
                cmd.Parameters.AddWithValue("_updateon", DateTime.Now.ToString("yyyy/MM/dd"));

                con.Open();
                // 1 = success ; -1 = failed
                var status = cmd.ExecuteNonQuery();

                con.Close();
            }
        }
        #endregion
    }
}
