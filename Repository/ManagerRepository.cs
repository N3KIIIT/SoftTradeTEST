using Microsoft.Data.SqlClient;
using SoftTradeTEST.AppDbConetext;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;

namespace SoftTradeTEST.Repository
{
    public class ManagerRepository :Repository<Manager>, IManagerRepository
    {

        private Context _dbContext;
        public ManagerRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Manager GetWithId(int id)
        {
           return (Manager)(from Manager in _dbContext.Manager
                  where Manager.Id == id
                  select Manager);
        }

        public void Update(Manager item)
        {
            _dbContext.Update(item);
        }
    }
}
