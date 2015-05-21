using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using EShop.FrontEnd.Core.Querying;

namespace EShop.FrontEnd.Model.Products
{
    public interface IProductRepository : IReadOnlyRepository<ProductTitle, int>
    {
    }
}
