
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> filter);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);
    }
}
