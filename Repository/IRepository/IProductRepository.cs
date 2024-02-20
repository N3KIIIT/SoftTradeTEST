
using SoftTradeTEST.Models;

namespace SoftTradeTEST.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        void Update(Product item); 
    }
}
