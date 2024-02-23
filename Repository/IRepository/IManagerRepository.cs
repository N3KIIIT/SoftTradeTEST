using SoftTradeTEST.MVVM.Models;


namespace SoftTradeTEST.Repository.IRepository
{
    interface IManagerRepository : IRepository<Manager>
    {
        void Update(Manager item);
    }
}
