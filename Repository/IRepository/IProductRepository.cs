﻿
using SoftTradeTEST.Models;

namespace SoftTradeTEST.Repository.IRepository
{
    interface IProductRepository: IRepository<Product>
    {
        void Update(Product item); 
    }
}
