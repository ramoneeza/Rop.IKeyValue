namespace Rop.Helper
{

    /// <summary>
    /// Simplest IIntKeyValue implementation
    /// </summary>
    public class FooIntKeyValue : IIntKeyValue
    {
        public int Key { get; private set; }
        public void SetKey(int newkey) => Key = newkey;
        public string Value { get; set; } = "";
        public int GetIntKey() => Key;
        public string GetKey() => Key.ToString();
        public string GetValue() => Value;

        public FooIntKeyValue()
        {
        }

        public FooIntKeyValue(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public FooIntKeyValue(IIntKeyValue kv)
        {
            Key = kv.GetIntKey();
            Value = kv.GetValue();
        }

        public void Deconstruct(out int key, out string value)
        {
            key = Key;
            value = Value;
        }

        public void Deconstruct(out string key, out string value)
        {
            key = Key.ToString();
            value = Value;
        }
    }
}