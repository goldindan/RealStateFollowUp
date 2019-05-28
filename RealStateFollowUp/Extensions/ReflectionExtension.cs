using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealStateFollowUp.Extensions
{
    public static class ReflectionExtension
    {
        public static String GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item).ToString();
        }
    }
}
