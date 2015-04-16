using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Core.Querying
{
    public class Query
    {
        private IList<Query> _subQueries = new List<Query>();
        private IList<Criterion> _criteria = new List<Criterion>();

        public IEnumerable<Criterion> Criteria { get { return _criteria; } }

        public IEnumerable<Query> SubQueries { get { return _subQueries; } }

        public void AddSubQuery(Query query)
        {
            _subQueries.Add(query);
        }

        public void Add(Criterion criterion)
        {
            _criteria.Add(criterion);
        }

        public QueryOperator QueryOperator { get; set; }
        public OrderByClause OrderByClause { get; set; }


    }
}
