
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository.IRepository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> item);
    }
}
