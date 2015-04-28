using EShop.FrontEnd.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Model.Products
{
    public class ProductColor : EntityBase<int>,IProductAttribute
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
