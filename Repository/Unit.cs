using SoftTradeTEST.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository
{
    class Unit : IUnit
    {
        public IProductRepository Product { get; private set; }
        public IClientRepository Client { get; private set; }  
        public IManagerRepository Manager { get; private set; }
        public IClientStatusRepository ClientStatus { get; private set; }

        public Unit()
        {
            Product = new ProductRepository();
            Client = new ClientRepository();
            Manager = new ManagerRepository();
            ClientStatus = new ClientStatusRepository();
        }
    }
}
