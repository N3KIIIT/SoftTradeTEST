using SoftTradeTEST.AppDbConetext;
using SoftTradeTEST.Repository.IRepository;


namespace SoftTradeTEST.Repository
{
    public class Unit : IUnit
    {
        private Context _dbContext;
        public IProductRepository Product { get; private set; }
        public IClientRepository Client { get; private set; }  
        public IManagerRepository Manager { get; private set; }
        public IClientStatusRepository ClientStatus { get; private set; }

        public Unit(Context dbContext)
        {
            _dbContext = dbContext;

            Product = new ProductRepository(_dbContext);
            Client = new ClientRepository(_dbContext);
            Manager = new ManagerRepository(_dbContext);
            ClientStatus = new ClientStatusRepository(_dbContext);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
