using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Background.Common
{
    public static class PrivateAccess
    {
        public static T PrivateInstantiate<T>() where T : class
        {
            ConstructorInfo[] constructors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
            var ctor = constructors.FirstOrDefault(x => !x.GetParameters().Any());

            if (ctor == null)
            {
                throw new ArgumentException(string.Format("No private empty constructor found for {0}.", typeof(T).FullName));
            }

            return ctor.Invoke(new object[] { }) as T;
        }

        public static R GetDynamicPrivate<R>(dynamic model, string propertyName)
        {
            return GetPrivate(model, propertyName, default(R));
        }

        public static R GetPrivate<T, R>(T model, string propertyName, R dummy = default(R))
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance);

            object val = property.GetValue(model);
            if (val == null)
            {
                return default(R);
            }
            else
            {
                return (R)val;
            }
        }

        public static void SetPrivate<T>(T model, string propertyName, object value)
        {
            var type = typeof(T);
            var property = type.GetProperty(propertyName);

            try
            {
                property.SetValue(model, value, null);
            }
            catch (Exception e)
            {
                var methodImplicitConvert = property.PropertyType.GetMethod("op_Implicit", new Type[] { typeof(string) });
                if (methodImplicitConvert != null)
                {
                    var convertedValue = methodImplicitConvert.Invoke(null, new object[] { value });
                    property.SetValue(model, convertedValue, null);
                }
                else
                {
                    throw e;
                }
            }
        }

        public static void SetPrivate<T, TProperty>(T model, Expression<Func<T, TProperty>> expressionProperty, object value)
        {
            Type type = typeof(T);

            MemberExpression member = expressionProperty.Body as MemberExpression;
            if (member == null)
            {
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    expressionProperty.ToString()));
            }

            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    expressionProperty.ToString()));
            }

            SetPrivate(model, propInfo.Name, value);
        }
    }
}
