using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.Domain
{
    public abstract class ValueObjectBase
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();
        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (BusinessRule rule in _brokenRules)
                {
                    sb.AppendLine(rule.Rule);
                }
                throw new ValueObjectIsInvaliException(sb.ToString());
            }
        }

        protected void AddBrokenRule(BusinessRule rule)
        {
            _brokenRules.Add(rule);
        }
    }
}
