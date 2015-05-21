using System.Collections.Generic;
using AutoMapper;
using EShop.FrontEnd.Model.Products;
using EShop.FrontEnd.Services.ViewModels;

namespace EShop.FrontEnd.Services.Mapping
{
    public static class IProductAttributeMapper
    {
        public static RefinementGroup ConvertToRefinementGroup(this IEnumerable<IProductAttribute> productAttributes,
            RefinementGroupings refinementGroupType)
        {
            RefinementGroup refinementGroup = new RefinementGroup()
            {
                Name = refinementGroupType.ToString(),
                GroupId = (int)refinementGroupType
            };

            refinementGroup.Refinements =
                Mapper.Map<IEnumerable<IProductAttribute>, IEnumerable<Refinement>>(productAttributes);
            return refinementGroup;
        }
    }
}
