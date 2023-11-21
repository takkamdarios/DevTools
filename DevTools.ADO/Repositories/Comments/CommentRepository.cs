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
    public class CommentRepository : ICommentRepository
    {
        #region Properties (Private)
        private readonly string _connectionString;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public CommentRepository()
        {
            _connectionString = "Data Source=localhost;port=3306;Initial Catalog=contact_management_db;User Id=root;password=@susOwijO1";
            //connectionString = "Data Source=localhost user=root password=@susOwijO1";
        }
        #endregion

        #region Methods (Public)


        public IEnumerable<Comment> GetAllComments(){
            var comments = new List<Comment>();

            using (var connection = new MySqlConnection(_connectionString)){
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM comments", connection);

                using (var reader = command.ExecuteReader()){
                    while (reader.Read()){
                        comments.Add(new Comment{
                            Id = reader.GetInt32("id"),
                            Content = reader.GetString("content"),
                            ContactId = reader.GetInt32("contact_id"),
                            CreateOn = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime("createon"),
                            UpdateOn = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime("updateon"),
                        });
                    }
                }
            }
            return comments;
        }


        public void Add(Comment entity)
        {
            using (MySqlConnection con = new MySqlConnection(_connectionString))
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

        public CommentRepository GetCommentById(int id){
            var comment = new CommentRepository();

            using (var connection = new MySqlConnection(_connectionString)){
                connection.Open();

                var command = new MySqlCommand("SELECT * FROM comments WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader()){
                    while (reader.Read()){
                        comment = new CommentRepository{
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

        public void UpdateComment(Comment comment){
            using (var connection = new MySqlConnection(_connectionString)){
                connection.Open();

                var command = new MySqlCommand("UPDATE comments SET content = @content, contact_id = @contact_id, updateon = @updateon WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", comment.Id);
                command.Parameters.AddWithValue("@content", comment.Content);
                command.Parameters.AddWithValue("@contact_id", comment.ContactId);
                command.Parameters.AddWithValue("@updateon", DateTime.Now.ToString("yyyy/MM/dd"));

                command.ExecuteNonQuery();
            }
        }

        public void DeleteComment(int id){
            using (var connection = new MySqlConnection(_connectionString)){
                connection.Open();

                var command = new MySqlCommand("DELETE FROM comments WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public ICollection<Comment> GetAll()
        {
            List<Comment> comments = new List<Comment>();
            using (var con = new MySqlConnection(_connectionString))
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
            using (var con = new MySqlConnection(_connectionString))
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

        #endregion
    }
}
