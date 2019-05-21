using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Background.Common
{
    public static class TypeExtensions
    {
        public static string GetFriendlyName(this Type type)
        {
            if (type == typeof(int))
                return "int";
            else if (type == typeof(short))
                return "short";
            else if (type == typeof(byte))
                return "byte";
            else if (type == typeof(bool))
                return "bool";
            else if (type == typeof(long))
                return "long";
            else if (type == typeof(float))
                return "float";
            else if (type == typeof(double))
                return "double";
            else if (type == typeof(decimal))
                return "decimal";
            else if (type == typeof(string))
                return "string";
            else if (type.IsGenericType)
                return type.Name.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(x => GetFriendlyName(x)).ToArray()) + ">";
            else
                return type.Name;
        }
    }
    /// <summary>
    /// 分页查询
    /// </summary>
    public static class LinqExtension
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
