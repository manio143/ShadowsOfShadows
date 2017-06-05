using System.Linq;
using System.Collections.Generic;

namespace ShadowsOfShadows.Helpers
{
    public class SerializeableKeyValue<T1, T2>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }
    }

    public static class SerializeableKeyValueHelper
    {
        public static List<SerializeableKeyValue<K, U>> ToSerializableKvp<K, U>(this Dictionary<K, U> dict)
        {
            return dict.Select(kvp => new SerializeableKeyValue<K, U> { Key = kvp.Key, Value = kvp.Value }).ToList();
        }
    }
}
