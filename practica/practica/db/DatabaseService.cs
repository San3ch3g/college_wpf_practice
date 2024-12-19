using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using pracrica.models;

namespace pracrica.db
{
    public class DatabaseService
    {
        public List<T> ExecuteQuery<T>(string query, Func<SqlDataReader, T> mapper, SqlParameter[] parameters = null)
        {
            var result = new List<T>();

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(mapper(reader));
                        }
                    }
                }
            }

            return result;
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        public T ExecuteScalar<T>(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    object result = command.ExecuteScalar();
                    if (result == null || result == DBNull.Value)
                    {
                        return default(T);
                    }

                    return (T)Convert.ChangeType(result, typeof(T));
                }
            }
        }

        public User GetUserByLogin(string login)
        {
            string query = "SELECT * FROM Users WHERE Login = @Login";
            var users = ExecuteQuery(query, reader => new User
            {
                Id = (int)reader["Id"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                Login = reader["Login"].ToString(),
                Password = reader["Password"].ToString()
            }, new SqlParameter[]
            {
                new SqlParameter("@Login", login)
            });

            return users.FirstOrDefault();
        }

        public bool RegisterUser(string firstName, string lastName, string login, string hashedPassword)
        {
            string query = "INSERT INTO Users (FirstName, LastName, Login, Password) VALUES (@FirstName, @LastName, @Login, @Password)";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@FirstName", firstName),
                new SqlParameter("@LastName", lastName),
                new SqlParameter("@Login", login),
                new SqlParameter("@Password", hashedPassword)
            });

            return rowsAffected > 0; 
        }

        public List<Category> GetCategories()
        {
            string query = "SELECT * FROM Categories";
            return ExecuteQuery(query, reader => new Category
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString()
            });
        }

        public bool CreateCategory(string name)
        {
            string query = "INSERT INTO Categories (Name) VALUES (@Name)";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Name", name)
            });

            return rowsAffected > 0;
        }
        
        public bool UpdateCategory(int id, string name)
        {
            string query = "UPDATE Categories SET Name = @Name WHERE Id = @Id";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@Name", name)
            });

            return rowsAffected > 0;
        }
        
        public bool DeleteCategory(int id)
        {
            string query = "DELETE FROM Categories WHERE Id = @Id";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            });

            return rowsAffected > 0;
        }

        public List<Product> GetProducts()
        {
            string query = "SELECT * FROM Products";
            return ExecuteQuery(query, reader => new Product
            {
                Id = (int)reader["Id"],
                CategoryId = (int)reader["CategoryId"],
                Name = reader["Name"].ToString(),
                Price = (decimal)reader["Price"]
            });
        }

        public bool CreateProduct(int categoryId, string name, decimal price)
        {
            string query = "INSERT INTO Products (CategoryId, Name, Price) VALUES (@CategoryId, @Name, @Price)";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@CategoryId", categoryId),
                new SqlParameter("@Name", name),
                new SqlParameter("@Price", price)
            });

            return rowsAffected > 0;
        }

        public bool UpdateProduct(int id, int categoryId, string name, decimal price)
        {
            string query = "UPDATE Products SET CategoryId = @CategoryId, Name = @Name, Price = @Price WHERE Id = @Id";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@CategoryId", categoryId),
                new SqlParameter("@Name", name),
                new SqlParameter("@Price", price)
            });

            return rowsAffected > 0;
        }

        public bool DeleteProduct(int id)
        {
            string query = "DELETE FROM Products WHERE Id = @Id";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            });

            return rowsAffected > 0;
        }

        public List<Payment> GetPayments()
        {
            string query = "SELECT * FROM Payments";
            return ExecuteQuery(query, reader => new Payment
            {
                Id = (int)reader["Id"],
                UserId = (int)reader["UserId"],
                ProductId = (int)reader["ProductId"],
                Quantity = (int)reader["Quantity"],
                PaymentDate = (DateTime)reader["PaymentDate"],
                TotalAmount = (decimal)reader["TotalAmount"]
            });
        }

        public bool CreatePayment(int userId, int productId, int quantity, decimal totalAmount)
        {
            string query = "INSERT INTO Payments (UserId, ProductId, Quantity, TotalAmount) VALUES (@UserId, @ProductId, @Quantity, @TotalAmount)";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@UserId", userId),
                new SqlParameter("@ProductId", productId),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@TotalAmount", totalAmount)
            });

            return rowsAffected > 0;
        }

        public bool UpdatePayment(int id, int userId, int productId, int quantity, decimal totalAmount)
        {
            string query = "UPDATE Payments SET UserId = @UserId, ProductId = @ProductId, Quantity = @Quantity, TotalAmount = @TotalAmount WHERE Id = @Id";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@ProductId", productId),
                new SqlParameter("@Quantity", quantity),
                new SqlParameter("@TotalAmount", totalAmount)
            });

            return rowsAffected > 0;
        }

        public bool DeletePayment(int id)
        {
            string query = "DELETE FROM Payments WHERE Id = @Id";
            int rowsAffected = ExecuteNonQuery(query, new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            });

            return rowsAffected > 0;
        }
        public List<User> GetUsers()
        {
            string query = "SELECT * FROM Users";
            return ExecuteQuery(query, reader => new User
            {
                Id = (int)reader["Id"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                Login = reader["Login"].ToString()
            });
        }
        public string GetCategoryNameById(int categoryId)
        {
            string query = "SELECT Name FROM Categories WHERE Id = @Id";
            var result = ExecuteScalar<string>(query, new SqlParameter[]
            {
        new SqlParameter("@Id", categoryId)
            });

            return result;
        }

        public string GetUserNameById(int userId)
        {
            string query = "SELECT Login FROM Users WHERE Id = @Id";
            var result = ExecuteScalar<string>(query, new SqlParameter[]
            {
        new SqlParameter("@Id", userId)
            });

            return result;
        }

        public string GetProductNameById(int productId)
        {
            string query = "SELECT Name FROM Products WHERE Id = @Id";
            var result = ExecuteScalar<string>(query, new SqlParameter[]
            {
        new SqlParameter("@Id", productId)
            });

            return result;
        }
    }
}