using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Products
{
    public class IProductRepository : IReadOnlyRepository<ProductTitle, int>
    {
    }
}
