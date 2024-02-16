using SoftTradeTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradeTEST.Repository.IRepository
{
    interface IClientStatusRepository : IRepository<ClientStatus>
    {
        void Update(ClientStatus item);
    }
}
