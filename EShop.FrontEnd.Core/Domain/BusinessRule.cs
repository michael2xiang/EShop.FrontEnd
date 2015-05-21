
namespace EShop.FrontEnd.Core.Domain
{
    public  class BusinessRule
    {
        public string Property { get; set; }
        public string Rule { get; set; }

        public BusinessRule(string property,string rule) {
            Property = property;
            Rule = rule;
        }
    }
}
