using Microsoft.Data.SqlClient;
using SoftTradeTEST.AppDbConetext;
using SoftTradeTEST.Models;
using SoftTradeTEST.Models.Enum;
using SoftTradeTEST.Repository.IRepository;
namespace SoftTradeTEST.Repository
{
    public class ProductRepository :Repository<Product>, IProductRepository
    {
        private Context _dbContext;
        public ProductRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Update(Product item)
        {
            _dbContext.Update(item);
        }
    }
}
