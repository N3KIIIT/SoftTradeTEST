using Microsoft.EntityFrameworkCore;
using SoftTradeTEST.Models;

namespace SoftTradeTEST.AppDbConetext
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RadarIT_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
