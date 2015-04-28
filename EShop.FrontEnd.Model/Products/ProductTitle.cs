using EShop.FrontEnd.Core.Domain;
using EShop.FrontEnd.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Products
{
    public class ProductTitle : EntityBase<int>, IAggregateRoot
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ProductColor Color { get; set; }
        public IEnumerable<Product> Products { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
