using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Background.Common
{
    public  static class LinqExtension
    {
        public static IQueryable<T> SortByProperty<T>(this IQueryable<T> source, string propertyName, bool asc)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            propertyName = propertyName.Trim();

            if (String.IsNullOrEmpty(propertyName))
            {
                return source;
            }
            MemberExpression property = null;
            var parameter = Expression.Parameter(source.ElementType, String.Empty);
            if (propertyName.IndexOf(".", StringComparison.Ordinal) > 0)
            {
                property = Expression.Property(parameter, propertyName.Split('.')[0]);
                property = Expression.Property(property, propertyName.Split('.')[1]);
            }
            else
            {
                property = Expression.Property(parameter, propertyName);
            }

            var lambda = Expression.Lambda(property, parameter);


            Expression methodCallExpression = Expression.Call(typeof(Queryable), asc ? "OrderBy" : "OrderByDescending",
                new[] { source.ElementType, property.Type },
                source.Expression, Expression.Quote(lambda));

            return source.Provider.CreateQuery<T>(methodCallExpression);
        }
    }
}
