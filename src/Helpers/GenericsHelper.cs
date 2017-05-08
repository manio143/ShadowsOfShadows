using System;

namespace ShadowsOfShadows.Helpers
{
    public static class GenericsHelper
    {
        public static bool IsInstanceOfGenericType(this object instance, Type genericType)
        {
            var type = instance.GetType();
            while (type != null)
            {
                if (type.IsGenericType &&
                    type.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
                type = type.BaseType;
            }
            return false;
        }
    }
}