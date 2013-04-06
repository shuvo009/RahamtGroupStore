using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RahamtGroupStore.ViewModel.Methods
{
    public static class ExtensionMethods
    {
        public static void ClearAllProperty<T> (this T property)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            propertyInfos.Where(x => typeof(string).IsAssignableFrom(x.PropertyType) && x.GetSetMethod() != null).ToList().ForEach(pro=> pro.SetValue(property,string.Empty,null));
            propertyInfos.Where(x => typeof(int).IsAssignableFrom(x.PropertyType) 
                                     || typeof(decimal).IsAssignableFrom(x.PropertyType))
                                     .ToList().ForEach(pro => pro.SetValue(property, 0, null));
            propertyInfos.Where(x => typeof(DateTime).IsAssignableFrom(x.PropertyType)).ToList().ForEach(pro => pro.SetValue(property, DateTime.Today, null));
        }

        public static void SetIdOfNewClass<T>(this T property)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            propertyInfos.First(x => typeof(Int64).IsAssignableFrom(x.PropertyType) && x.GetSetMethod() != null).SetValue(property, -1, null);
            propertyInfos.Where(x => typeof(DateTime).IsAssignableFrom(x.PropertyType)).ToList().ForEach(pro => pro.SetValue(property, DateTime.Today, null));
        }

        public static bool IsNew<T>(this T property)
        {
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            var idValue =  propertyInfos.First(x => typeof(Int64).IsAssignableFrom(x.PropertyType) && x.GetSetMethod() != null).GetValue(property,null);
            return (Int64)idValue == -1;
        }
    }
}