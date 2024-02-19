using Microsoft.Data.SqlClient;
using SoftTradeTEST.DB;
using SoftTradeTEST.Models;
using SoftTradeTEST.Models.Enum;
using SoftTradeTEST.Repository.IRepository;
namespace SoftTradeTEST.Repository
{
    class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;
        public ProductRepository(IDbConnection dbConnection) 
        {
            _dbConnection=dbConnection;
        }

        public void Add(Product item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"INSERT INTO [dbo].[Products]([Name],[Type],[Period]) VALUES ('{item.Name}',{(int)item.Type},{((int)item.Period)})";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        public Product Get(int id)
        {
            Product product = new Product();

            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[Products] WHERE [id] = {id}";


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        product.ProductId = (int)reader.GetValue(0);
                        product.Name = reader.GetValue(1).ToString();
                        product.Type = (Models.Enum.Type)reader.GetValue(2);
                        product.Period = (SubscriptionPeriod)reader.GetValue(3);
                    }

                }
            }

            return product;
        }
        public IEnumerable<Product> GetAll()
        {
            var productList = new List<Product>();
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[Products]";
                connection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);


                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            ProductId = (int)reader.GetValue(0),
                            Name = reader.GetValue(1).ToString(),
                            Type = (Models.Enum.Type)reader.GetValue(2),
                            Period = (Models.Enum.SubscriptionPeriod)reader.GetValue(3)
                        };
                        productList.Add(product);
                    }
                }
            }
            return productList;
        }
        public void Remove(Product item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"DELETE FROM [dbo].[Products] WHERE [Id] = {item.ProductId}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RemoveRange(IEnumerable<Product> item)
        {
            foreach (var manager in item)
            {
                using (var connection = new SqlConnection(_dbConnection.ConnectionString))
                {
                    var query = $"DELETE FROM [dbo].[dbo].[Products] WHERE [Id] = {manager.ProductId}";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        public void Update(Product item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"UPDATE [dbo].[Products] SET [Name] = '{item.Name}' ,[Type] = {((int)item.Type)} ,[Period] = {((int)item.Period)} WHERE [Id] = {item.ProductId}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
