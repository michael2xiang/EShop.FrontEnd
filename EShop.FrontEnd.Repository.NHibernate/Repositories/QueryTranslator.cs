﻿using EShop.FrontEnd.Core.Querying;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.FrontEnd.Repository.NHibernate.Repositories
{
    public static class QueryTranslator
    {
        public static ICriteria TranslateIntoNHQuery<T>(this Query query, ICriteria criteria)
        {
            BuildQueryFrom(query, criteria);
            if (query.OrderByClause != null)
            {
                criteria.AddOrder(new Order(query.OrderByClause.PropertyName,
                    !query.OrderByClause.Dese));
            }
            return criteria;
        }

        private static void BuildQueryFrom(Query query, ICriteria criteria)
        {
            IList<ICriterion> criterions = new List<ICriterion>();
            if (query.Criteria != null)
            {
                foreach (Criterion c in query.Criteria)
                {
                    ICriterion criterion;
                    switch (c.criteriaOperator)
                    {
                        case CriteriaOperator.Equal:
                            criterion = Expression.Eq(c.PropertyName, c.Value);
                            break;
                        case CriteriaOperator.LesserThanOrEqual:
                            criterion = Expression.Le(c.PropertyName, c.Value);
                            break;
                        default:
                            throw new ApplicationException("No operator defined");
                    }
                    criterions.Add(criterion);
                }
            }
            if (query.QueryOperator == QueryOperator.And)
            {
                Conjunction andSubQuery = Expression.Conjunction();
                foreach (ICriterion c in criterions)
                {
                    andSubQuery.Add(c);
                }
                criteria.Add(andSubQuery);
            }
            else
            {
                Disjunction orSubQuery = Expression.Disjunction();
                foreach (ICriterion c in criterions)
                {
                    orSubQuery.Add(c);
                }
                criteria.Add(orSubQuery);

            }

            foreach (Query sub in query.SubQueries)
            {
                BuildQueryFrom(sub, criteria);
            }
        }
    }
}
