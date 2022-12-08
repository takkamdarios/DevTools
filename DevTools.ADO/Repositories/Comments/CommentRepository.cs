using DevTools.ADO.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTools.ADO.Repositories.Comments
{
    /// <summary>
    /// This class manages all the methods described in ICommentRepository
    /// </summary>
    internal class CommentRepository : ICommentRepository
    {
        #region Properties (Private)
        private readonly string connectionString;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public CommentRepository()
        {
            connectionString = "Data Source=localhost;port=3306;Initial Catalog=contact_management_db;User Id=root;password=@susOwijO1";
            //connectionString = "Data Source=localhost user=root password=@susOwijO1";
        }
        #endregion

        #region Methods (Public)
        public void Add(Comment entity)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_create_comment", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_content", entity.Content);
                cmd.Parameters.AddWithValue("_contact_id", entity.ContactId);
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
                MySqlCommand cmd = new MySqlCommand("sp_delete_comment", con);
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

        public Comment Get(int id)
        {
            Comment comment = null;
            using (var con = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("sp_get_comment", con);
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
                        comment = new Comment()
                        {
                            Id = reader.GetInt32("id"),
                            Content = reader.GetString("content"),
                            ContactId = reader.GetInt32("contact_id"),
                            CreateOn = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime("createon"),
                            UpdateOn = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime("updateon"),
                        };
                    }
                }
            }
            return comment;
        }

        public ICollection<Comment> GetAll()
        {
            List<Comment> comments = new List<Comment>();
            using (var con = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("sp_get_comments", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                // fetch data if rows exists
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var comment = new Comment()
                        {
                            Id = reader.GetInt32("id"),
                            Content = reader.GetString("content"),
                            ContactId = reader.GetInt32("contact_id"),
                            CreateOn = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime("createon"),
                            UpdateOn = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime("updateon"),
                        };
                        // add comment to list
                        comments.Add(comment);
                    }
                }
            }
            return comments;
        }

        public ICollection<Comment> GetAllByContact(int contactId)
        {
            List<Comment> comments = new List<Comment>();
            using (var con = new MySqlConnection(connectionString))
            {
                var cmd = new MySqlCommand("sp_get_comments_by_contact", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_contact_id", contactId);

                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                // fetch data if rows exists
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var comment = new Comment();
                        comment = new Comment()
                        {
                            Id = reader.GetInt32("id"),
                            Content = reader.GetString("content"),
                            ContactId = reader.GetInt32("contact_id"),
                            CreateOn = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime("createon"),
                            UpdateOn = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime("updateon"),
                        };
                        // add comment to list
                        comments.Add(comment);
                    }
                }
            }
            return comments;
        }

        public void Update(int id, Comment entity)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand("sp_update_comment", con);
                // specify that we use store procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // define the parameters of store procedure / request
                cmd.Parameters.AddWithValue("_id", id);
                cmd.Parameters.AddWithValue("_content", entity.Content);
                cmd.Parameters.AddWithValue("_contact_id", entity.ContactId);
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
