using Microsoft.Data.SqlClient;
using SoftTradeTEST.DB;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository
{
    class ClientStatusRepository : IClientStatusRepository
    {
        private readonly IDbConnection _dbConnection;
        public ClientStatusRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
  

        public void Add(ClientStatus item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"INSERT INTO [dbo].[ClientStatuses]([Status])VALUES('{item.Status}')";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        public ClientStatus Get(int id)
        {
            ClientStatus client = new ClientStatus();

            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[ClientStatuses] WHERE [id] = {id}";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        client.Id = (int)reader.GetValue(0);
                        client.Status = reader.GetValue(1).ToString();

                    }

                }
            }

            return client;
        }
        public IEnumerable<ClientStatus> GetAll()
        {
            var clientStatusList = new List<ClientStatus>();
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[ClientStatuses]";
                connection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);


                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var clientStatus = new ClientStatus()
                        {
                            Id = (int)reader.GetValue(0),
                            Status = reader.GetValue(1).ToString(),
                        };
                        clientStatusList.Add(clientStatus);
                    }

                }
            }
            return clientStatusList;
        }
        public void Remove(ClientStatus item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"DELETE FROM [dbo].[ClientStatuses] WHERE [Id] = {item.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RemoveRange(IEnumerable<ClientStatus> item)
        {
            foreach (var manager in item)
            {
                using (var connection = new SqlConnection(_dbConnection.ConnectionString))
                {
                    var query = $"DELETE FROM [dbo].[dbo].[ClientStatuses] WHERE [Id] = {manager.Id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        public void Update(ClientStatus item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"UPDATE [dbo].[ClientStatuses] SET [Status] = {item.Status} WHERE [Id] = {item.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
