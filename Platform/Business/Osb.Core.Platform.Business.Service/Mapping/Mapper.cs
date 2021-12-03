using System;
using System.Reflection;

namespace Osb.Core.Platform.Business.Service.Mapping
{
    public class Mapper
    {
        public T Map<T>(object obj)
        {
            T objT = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo propertyInfo in obj.GetType().GetProperties())
            {
                if (objT.GetType().GetProperty(propertyInfo.Name) == null)
                    continue;

                objT.GetType()
                    .GetProperty(propertyInfo.Name)
                    .SetValue(objT, propertyInfo.GetValue(obj));
            }

            return objT;
        }
    }
}