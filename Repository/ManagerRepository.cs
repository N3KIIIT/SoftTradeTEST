using Microsoft.Data.SqlClient;
using SoftTradeTEST.DB;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoftTradeTEST.Repository
{
    class ManagerRepository : IManagerRepository
    {
        private readonly IDbConnection _dbConnection;
        public ManagerRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Add(Manager item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"INSERT INTO [dbo].[Managers]([Name]) VALUES('{item.Name}')";
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        public Manager Get(int id)
        {
            Manager manager = new Manager();

            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[Managers] WHERE [id] = {id}";


                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        manager.Id = (int)reader.GetValue(0);
                        manager.Name = reader.GetValue(1).ToString();
                    }

                }
            }

            return manager;
        }
        public IEnumerable<Manager> GetAll()
        {
            var managerList = new List<Manager>();
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"SELECT * FROM [dbo].[Managers]";
                connection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(query, connection);


                sqlDataAdapter.SelectCommand = command;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var manager = new Manager()
                        {
                            Id = (int)reader.GetValue(0),
                            Name = reader.GetValue(1).ToString()
                        };
                        managerList.Add(manager);
                    }

                }
            }
            return managerList;
        }
        public void Remove(Manager item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"DELETE FROM [dbo].[Managers] WHERE [Id] = {item.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void RemoveRange(IEnumerable<Manager> item)
        {
            foreach (var manager in item)
            {
                using (var connection = new SqlConnection(_dbConnection.ConnectionString))
                {
                    var query = $"DELETE FROM [dbo].[Managers] WHERE [Id] = {manager.Id}";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

        }
        public void Update(Manager item)
        {
            using (var connection = new SqlConnection(_dbConnection.ConnectionString))
            {
                var query = $"UPDATE [dbo].[Managers] SET [Name] = '{item.Name}' WHERE [Id] = {item.Id}";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
