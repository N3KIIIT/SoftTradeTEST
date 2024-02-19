using SoftTradeTEST.DB;
using SoftTradeTEST.Repository.IRepository;


namespace SoftTradeTEST.Repository
{
    class Unit : IUnit
    {
        private readonly IDbConnection _dbConnection;
        public IProductRepository Product { get; private set; }
        public IClientRepository Client { get; private set; }  
        public IManagerRepository Manager { get; private set; }
        public IClientStatusRepository ClientStatus { get; private set; }

        public Unit(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            Product = new ProductRepository(_dbConnection);
            Client = new ClientRepository(_dbConnection);
            Manager = new ManagerRepository(_dbConnection);
            ClientStatus = new ClientStatusRepository(_dbConnection);
        }
    }
}
