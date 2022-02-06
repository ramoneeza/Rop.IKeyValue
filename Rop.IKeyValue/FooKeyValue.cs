using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rop.Helper
{
    /// <summary>
    /// Simples IKeyValue implementation
    /// </summary>
    public class FooKeyValue : IKeyValue
    {
        public string Key { get; private set; } = "";
        public void SetKey(string newkey) => Key = newkey;
        public string Value { get; set; } = "";
        public string GetKey() => Key;
        public string GetValue() => Value;
        public FooKeyValue() { }

        public FooKeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public FooKeyValue(int key, string value)
        {
            Key = key.ToString();
            Value = value;
        }
        public FooKeyValue((string key, string value) kv)
        {
            var (key, value) = kv;
            Key = key;
            Value = value;
        }
        public FooKeyValue((int key, string value)kv)
        {
            var (key, value) = kv;
            Key = key.ToString();
            Value = value;
        }

        public FooKeyValue(IKeyValue kv)
        {
            Key = kv.GetKey();
            Value = kv.GetValue();
        }
        public FooKeyValue(IIntKeyValue kv)
        {
            Key = kv.GetKey();
            Value = kv.GetValue();
        }

        public void Deconstruct(out string key, out string value)
        {
            key = Key;
            value = Value;
        }
    }
}
