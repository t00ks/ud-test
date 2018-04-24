using System.Data.SqlClient;
using UniDaysTest.API.Contracts;
using UniDaysTest.API.Models;
using System.Linq;
using System;

namespace UniDaysTest.API.Data
{
    public class UserRepository : IUserRepository
    {
        private string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User GetUser(string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "dbo.GetUserByEmail";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var sale = new User(
                            userId:(int)reader["UserId"],
                            email:reader["Email"].ToString(),
                            password: reader["Password"].ToString(),
                            createdDate: Convert.ToDateTime(reader["CreatedDate"]),
                            lastUpdateDate: Convert.ToDateTime(reader["LastUpdatedDate"])
                        );

                        return sale;
                    }
                }
            }
            
            return null;
        }

        public void InsertUser(User user, string encryptedPassword)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "dbo.InsertUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", encryptedPassword);

                conn.Open();
                cmd.ExecuteReader();
            }
        }

        public void UpdateUser(User user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = "dbo.UpdateUser";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Password", user.Password);

                conn.Open();
                cmd.ExecuteReader();
            }
        }
    }
}