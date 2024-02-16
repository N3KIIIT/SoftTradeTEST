using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository.IRepository
{
    interface IUnit
    {
        IProductRepository Product { get; }
        IClientRepository Client { get; }
        IManagerRepository Manager { get; }
        IClientStatusRepository ClientStatus { get; }
    }
}
