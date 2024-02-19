using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.DB
{
    internal class DbConnection : IDbConnection
    {
        public string ConnectionString { get;private set; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SoftTrade_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}
