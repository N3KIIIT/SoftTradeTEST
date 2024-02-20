using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository.IRepository
{
    public interface IUnit
    {
        IProductRepository Product { get; }
        IClientRepository Client { get; }
        IManagerRepository Manager { get; }
        IClientStatusRepository ClientStatus { get; }

        void Save();
    }
}
