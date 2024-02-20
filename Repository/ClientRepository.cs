using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.AppDbConetext;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;



namespace SoftTradeTEST.Repository
{
    public class ClientRepository : Repository<Client>,IClientRepository
    {
        private Context _dbContext;

        public ClientRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Client item)
        {
           _dbContext.Update(item);
        }

    }
}
