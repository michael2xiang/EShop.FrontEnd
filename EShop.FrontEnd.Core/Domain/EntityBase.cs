using System.Collections.Generic;

namespace EShop.FrontEnd.Core.Domain
{
    public abstract class EntityBase<TId>
    {
        private List<BusinessRule> _brokenRules = new List<BusinessRule>();

        public TId Id { get; set; }

        protected abstract void Validate();

        public IEnumerable<BusinessRule> GetBrokenRules()
        {
            _brokenRules.Clear();
            Validate();
            return _brokenRules;
        }

        protected void addBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }

        public override bool Equals(object obj)
        {
            return obj != null && obj is EntityBase<TId>
                && this == (EntityBase<TId>)obj;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }
            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.ToString() == entity2.ToString())
            {
                return true;
            }
            return false;
        }


        public static bool operator !=(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }

    }
}
