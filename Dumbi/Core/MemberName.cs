namespace Dumbi.Core
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Assists in retriving information about object members
    /// </summary>
    public class MemberName
    {
        /// <summary>
        /// Given an expression, returns the name of the member
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyLambda"></param>
        /// <returns></returns>
        public static string Get<T>(Expression<Func<T>> propertyLambda)
        {
            var me = propertyLambda.Body as MemberExpression;

            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }
            else
            {
                return me.Member.Name;
            }
        }
    }
}
