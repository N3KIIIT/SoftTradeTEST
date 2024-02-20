
using SoftTradeTEST.AppDbConetext;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;

namespace SoftTradeTEST.Repository
{
    public class ClientStatusRepository : Repository<ClientStatus>,IClientStatusRepository
    {
        private Context _dbContext;
        public ClientStatusRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(ClientStatus item)
        {
           _dbContext.Update(item);
        }
    }
}
