using EShop.FrontEnd.Core.Domain;
using System;

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
