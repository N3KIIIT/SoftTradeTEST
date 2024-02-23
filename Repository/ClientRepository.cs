using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.DB;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.Repository.IRepository;



namespace SoftTradeTEST.Repository
{
    class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _dbConnection;
        public ClientRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Client item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"INSERT INTO [dbo].[Clients]([Name],[StatusId],[ManagerId],[ProductId])VALUES('{item.Name}',{item.Status},{item.Manager},{item.Products})";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        public Client Get(int id)
        {
            Client client = new Client();

            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[Clients] WHERE [id] = {id}";


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client.Id = (int)reader.GetValue(0);
                        client.Name = reader.GetValue(1).ToString();
                        client.Status = reader.GetValue(2).ToString();
                        client.Manager = reader.GetValue(3).ToString();
                        client.Products = reader.GetValue(4).ToString();

                    }

                }
            }

            return client;
        }
        public IEnumerable<Client> GetAll()
        {
            var clientList = new List<Client>();
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[Clients]";
                connection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);


                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var client = new Client();

                        client.Id = (int)reader.GetValue(0);
                        client.Name = reader.GetValue(1).ToString();
                        client.Status = reader.GetValue(2).ToString();
                        client.Manager = reader.GetValue(3).ToString();
                        client.Products = reader.GetValue(4).ToString();

                        clientList.Add(client);
                    }

                }
            }
            return clientList;
        }
        public void Remove(Client item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"DELETE FROM [dbo].[Clients] WHERE [Id] = {item.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RemoveRange(IEnumerable<Client> item)
        {
            foreach (var manager in item)
            {
                using (var connection = new SqlConnection(_dbConnection.ConnectionString))
                {
                    var query = $"DELETE FROM [dbo].[dbo].[Clients] WHERE [Id] = {manager.Id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        public void Update(Client item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"UPDATE [dbo].[Clients] SET [Name] = '{item.Name}' ,[StatusId] = {item.Status} ,[ManagerId] = {item.Manager},[ProductId] = {item.Products} WHERE [Id] = {item.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
