using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace AddressPractice.Models
{
    public static class LinqExpressionWhere
    {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> Source,
            bool Condition, Expression<Func<TSource, bool>> Predicate)
        {
            if (Condition)
                return Source.Where(Predicate);
            else
                return Source;
        }
    }
}
