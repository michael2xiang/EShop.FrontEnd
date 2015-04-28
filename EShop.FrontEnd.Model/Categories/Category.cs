using EShop.FrontEnd.Core.Domain;
using EShop.FrontEnd.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Categories
{
    public class Category : EntityBase<int>, IAggregateRoot, IProductAttribute
    {

        public string Name
        {
            get;
            set;
        }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
