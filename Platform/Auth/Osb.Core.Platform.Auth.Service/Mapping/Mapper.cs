using System;
using System.Reflection;

namespace Osb.Core.Platform.Auth.Service.Mapping
{
    public class Mapper
    {
        public T UpdateMap<T>(object obj1, object obj2)
        {
            T objT = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo propertyInfo in objT.GetType().GetProperties())
            {
                if (obj1.GetType().GetProperty(propertyInfo.Name) == null)
                    continue;

                if ((obj2.GetType().GetProperty(propertyInfo.Name).GetValue(obj2, null)) != null)
                    objT.GetType()
                        .GetProperty(propertyInfo.Name)
                        .SetValue(objT, obj2.GetType().GetProperty(propertyInfo.Name).GetValue(obj2));
                else
                    objT.GetType()
                        .GetProperty(propertyInfo.Name)
                        .SetValue(objT, obj1.GetType().GetProperty(propertyInfo.Name).GetValue(obj1));
            }

            return objT;
        }
    }
}