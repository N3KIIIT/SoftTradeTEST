using SoftTradeTEST.Models;


namespace SoftTradeTEST.Repository.IRepository
{
    public interface IManagerRepository : IRepository<Manager>
    {
        void Update(Manager item);
        Manager GetWithId(int id);
    }
}
