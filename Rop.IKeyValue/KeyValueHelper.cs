using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rop.Helper
{
    /// <summary>
    /// Helper class for KeyValue classes
    /// </summary>
    public static class KeyValueHelper
    {
        /// <summary>
        /// Convert enumerable of IKeys items to dictionary
        /// </summary>
        /// <typeparam name="T">Ikey type</typeparam>
        /// <param name="value">Enumeration of IKey items</param>
        /// <returns>KeyValueDictionary</returns>
        public static KeyValueDic<T> ToKeyValueDic<T>(this IEnumerable<T> value) where T : IKey => new KeyValueDic<T>(value);
        /// <summary>
        /// Convert dictionary of IKeys items to KeyValueDictionary
        /// </summary>
        /// <typeparam name="T">Ikey type</typeparam>
        /// <param name="value">Dictionary of IKey items</param>
        /// <returns>KeyValueDictionary</returns>
        public static KeyValueDic<T> ToKeyValueDic<T>(this IDictionary<string, T> value) where T : IKey => new KeyValueDic<T>(value);
        /// <summary>
        /// Convert a tuple in a FooKeyValue
        /// </summary>
        /// <param name="value">Tuple</param>
        /// <returns>Fookeyvalue</returns>
        public static FooKeyValue ToFooKeyValue(this (string, string) value) => new FooKeyValue(value.Item1, value.Item2);
        public static FooKeyValue ToFooKeyValue(this (int, string) value) => new FooKeyValue(value.Item1.ToString(), value.Item2);
        /// <summary>
        /// Convert a tuple in a IntFooKeyValue
        /// </summary>
        /// <param name="value">Tuple</param>
        /// <returns>FooIntKeyValue</returns>
        public static FooIntKeyValue ToFooIntKeyValue(this (int, string) value) => new FooIntKeyValue(value.Item1, value.Item2);
        /// <summary>
        /// Convert a enumeration of tuples in a enumeration of FooKeyValue
        /// </summary>
        public static IEnumerable<FooKeyValue> ToFooKeyValues(this IEnumerable<(string, string)> values)
        {
            return values.Select(valueTuple => new FooKeyValue(valueTuple.Item1, valueTuple.Item2));
        }
        /// <summary>
        /// Convert a enumeration of tuples in a enumeration of FooIntKeyValue
        /// </summary>
        public static IEnumerable<FooIntKeyValue> ToFooIntKeyValues(this IEnumerable<(int, string)> values)
        {
            return values.Select(valueTuple => new FooIntKeyValue(valueTuple.Item1, valueTuple.Item2));
        }
        /// <summary>
        /// Convert a IKeyValue to a FooKeyValue
        /// </summary>
        public static FooKeyValue ToFooKeyValue(this IKeyValue kv) => new FooKeyValue(kv);
        /// <summary>
        /// Convert a IIntKeyValue to a FooKeyValue
        /// </summary>
        public static FooKeyValue ToFooKeyValue(this IIntKeyValue kv) => new FooKeyValue(kv);
        /// <summary>
        /// Convert a IIntKeyValue to a FooIntKeyValue
        /// </summary>
        public static FooIntKeyValue ToFooIntKeyValue(this IIntKeyValue kv) => new FooIntKeyValue(kv);
        /// <summary>
        /// Convert a IKeyValue to a ImmutableKeyValue
        /// </summary>
        public static ImmutableKeyValue ToImmutable(this IKeyValue kv) => new ImmutableKeyValue()
            {Key = kv.GetKey(), Value = kv.GetValue()};
        /// <summary>
        /// Convert a IIntKeyValue to a ImmutableIntKeyValue
        /// </summary>
        public static ImmutableIntKeyValue ToImmutable(this IIntKeyValue kv) => new ImmutableIntKeyValue()
            { Key = kv.GetIntKey(), Value = kv.GetValue() };

        /// <summary>
        /// Compares for equality two IKey classes to same key (Case insensitive)
        /// </summary>
        public static bool EqualsKey(this IKey a, IKey b) => string.Equals(a.GetKey(), b.GetKey(), StringComparison.OrdinalIgnoreCase);
        /// <summary>
        /// Compares for equality two IIntKey classes to same key
        /// </summary>
        public static bool EqualsKey(this IIntKey a, IIntKey b) => a.GetKey().Equals(b.GetKey());

        public static bool EqualsKey(this IKey a, string b) => string.Equals(a.GetKey(), b, StringComparison.OrdinalIgnoreCase);
        public static bool EqualsKey(this IIntKey a, int b) => a.GetIntKey()==b;
    }
}
