using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Rop.Helper
{
    /// <summary>
    /// String dictionary CASE aware
    /// </summary>
    /// <typeparam name="T">Value type</typeparam>
    public class DictionaryNoCase<T> : Dictionary<string, T>
    {
        public DictionaryNoCase() : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public DictionaryNoCase(IDictionary<string, T> dictionary) : base(dictionary, StringComparer.OrdinalIgnoreCase)
        {
        }

        public DictionaryNoCase(IEnumerable<KeyValuePair<string, T>> collection) : base(
            StringComparer.OrdinalIgnoreCase)
        {
            foreach (var keyValuePair in collection)
            {
                this[keyValuePair.Key] = keyValuePair.Value;
            }
        }

        public DictionaryNoCase(int capacity) : base(capacity, StringComparer.OrdinalIgnoreCase)
        {
        }
    }
    
    /// <summary>
    /// Dictionary of IKey items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KeyValueDic<T> : DictionaryNoCase<T> where T : IKey
    {
        /// <summary>
        /// Add IKey item
        /// </summary>
        /// <param name="value">Item</param>
        public void Add(T value) => base.Add(value.GetKey(), value);
        /// <summary>
        /// Add or update IKey item
        /// </summary>
        /// <param name="value">IKey item</param>
        public void AddOrUpdate(T value) => base[value.GetKey()] = value;
        /// <summary>
        /// AddOrUpdate range of IKey items
        /// </summary>
        /// <param name="values">Enumerable of IKey items</param>
        public void AddOrUpdateRange(IEnumerable<T> values)
        {
            foreach (var value in values) AddOrUpdate(value);
        }
        /// <summary>
        /// Remove IKey item
        /// </summary>
        /// <param name="value">IKey Item</param>
        /// <returns>true if removed</returns>
        public bool Remove(T value) => base.Remove(value.GetKey());

        public KeyValueDic()
        {
        }

        public KeyValueDic(IDictionary<string, T> dictionary) : base(dictionary)
        {
        }

        public KeyValueDic(IEnumerable<KeyValuePair<string, T>> collection) : base(collection)
        {
        }

        public KeyValueDic(IEnumerable<T> collection) : base(collection.Select(c =>
            new KeyValuePair<string, T>(c.GetKey(), c)))
        {
        }

        public KeyValueDic(int capacity) : base(capacity)
        {
        }
        /// <summary>
        /// Get list of values ordered by key
        /// </summary>
        /// <returns></returns>
        public List<T> OrderedValues() =>
            this.Values.OrderBy(v => v.GetKey(), StringComparer.OrdinalIgnoreCase).ToList();
        /// <summary>
        /// Compares two dictionaries to same keys
        /// </summary>
        /// <param name="other">other dictionary</param>
        /// <returns>true if same keys</returns>
        public bool EqualsKeys(IDictionary<string, T> other)
        {
            var count = other.Count;
            if (count != this.Count) return false;
            return EqualsKeys(other.Keys);
        }
        /// <summary>
        /// Compare keys with other keys
        /// </summary>
        /// <param name="other">other keys</param>
        /// <returns>true if same keys</returns>
        public bool EqualsKeys(IEnumerable<string> other)
        {
            var h1 = new HashSet<string>(Keys,StringComparer.OrdinalIgnoreCase);
            return h1.SetEquals(other);
        }
    }
    
    /// <summary>
    /// Dictionary of IIntKey items
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class IntKeyValueDic<T> : Dictionary<int, T> where T : IIntKey
    {
        /// <summary>
        /// Add IIntKey item
        /// </summary>
        /// <param name="value">Item</param>
        public void Add(T value) => base.Add(value.GetIntKey(), value);
        /// <summary>
        /// Add or update IIntKey item
        /// </summary>
        /// <param name="value">IIntKey item</param>
        public void AddOrUpdate(T value) => base[value.GetIntKey()] = value;
        /// <summary>
        /// AddOrUpdate range of IIntKey items
        /// </summary>
        /// <param name="values">Enumerable of IIntKey items</param>
        public void AddOrUpdateRange(IEnumerable<T> values)
        {
            foreach (var value in values) AddOrUpdate(value);
        }
        /// <summary>
        /// Remove IIntKey item
        /// </summary>
        /// <param name="value">IIntKey Item</param>
        /// <returns>true if removed</returns>
        public bool Remove(T value) => base.Remove(value.GetIntKey());

        public IntKeyValueDic() : base()
        {
        }

        public IntKeyValueDic(IDictionary<int, T> dictionary) : base(dictionary)
        {
        }

        public IntKeyValueDic(IEnumerable<KeyValuePair<int, T>> collection) : base()
        {
            foreach (var keyValuePair in collection) this.AddOrUpdate(keyValuePair.Value);
        }

        public IntKeyValueDic(IEnumerable<T> collection)
        {
            foreach (var keyValuePair in collection) this.AddOrUpdate(keyValuePair);
        }

        public IntKeyValueDic(int capacity) : base(capacity)
        {
        }
        /// <summary>
        /// Get list of values ordered by key
        /// </summary>
        /// <returns></returns>
        public List<T> OrderedValues() => this.Values.OrderBy(v => v.GetIntKey()).ToList();
        /// <summary>
        /// Compares two dictionaries to same keys
        /// </summary>
        /// <param name="other">other dictionary</param>
        /// <returns>true if same keys</returns>
        public bool EqualsKeys(IDictionary<int, T> other)
        {
            var count = other.Count;
            if (count != this.Count) return false;
            return EqualsKeys(other.Keys);
        }
        /// <summary>
        /// Compare keys with other keys
        /// </summary>
        /// <param name="other">other keys</param>
        /// <returns>true if same keys</returns>
        public bool EqualsKeys(IEnumerable<int> other)
        {
            var h1 =new HashSet<int>(Keys);
            return h1.SetEquals(other);
        }
    }


}