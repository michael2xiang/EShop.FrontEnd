using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Products
{
    public interface IProductAttribute
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
