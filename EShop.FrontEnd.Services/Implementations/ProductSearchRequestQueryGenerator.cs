﻿using EShop.FrontEnd.Core.Querying;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Services.Messaging.ProductCatalogSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Services.Implementations
{
    public class ProductSearchRequestQueryGenerator
    {
        public static Query CreateQueryFor(GetProductsByCategoryRequest getProductsByCategoryRequest)
        {
            Query productQuery = new Query();
            Query colorQuery = new Query();
            Query brandQuery = new Query();
            Query sizeQuery = new Query();
            colorQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getProductsByCategoryRequest.ColorIds)
            {
                colorQuery.Add(Criterion.Create<Product>(p => p.Color.Id, id, CriteriaOperator.Equal));
            }
            if (colorQuery.Criteria.Count() > 0)
            {
                productQuery.AddSubQuery(colorQuery);
            }
            brandQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getProductsByCategoryRequest.BrandIds)
            {
                brandQuery.Add(Criterion.Create<Product>(p => p.Brand.Id, id, CriteriaOperator.Equal));
            }
            if (brandQuery.Criteria.Count() > 0)
            {
                productQuery.AddSubQuery(brandQuery);
            }
            sizeQuery.QueryOperator = QueryOperator.Or;
            foreach (int id in getProductsByCategoryRequest.SizeIds)
            {
                sizeQuery.Add(Criterion.Create<Product>(p => p.Size.Id, id, CriteriaOperator.Equal));
            }
            if (sizeQuery.Criteria.Count() > 0)
            {
                productQuery.AddSubQuery(sizeQuery);
            }
            productQuery.Add(Criterion.Create<Product>(p => p.Category.Id, getProductsByCategoryRequest.CategoryId, CriteriaOperator.Equal));
            return productQuery;
        }
    }
}
