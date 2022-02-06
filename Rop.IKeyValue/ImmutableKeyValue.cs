namespace Rop.Helper
{
    /// <summary>
    /// Simplest IKeyValue record implementation
    /// </summary>
    public record ImmutableKeyValue : IKeyValue
    {
        public string Key { get; init; } = "";
        public string Value { get; init; } = "";
        public string GetKey() => Key;
        public string GetValue() => Value;

        public void Deconstruct(out string key, out string value)
        {
            key = Key;
            value = Value;
        }

        public bool IsNull => string.IsNullOrEmpty(Key);
    }
    /// <summary>
    /// Simples IIntKeyValue record implementation
    /// </summary>
    public record ImmutableIntKeyValue : IIntKeyValue
    {
        public int Key { get; init; } = -1;
        public string Value { get; init; } = "";
        public int GetIntKey() => Key;
        public string GetKey() => Key.ToString();
        public string GetValue() => Value;

        public void Deconstruct(out string key, out string value)
        {
            key = GetKey();
            value = Value;
        }

        public void Deconstruct(out int key, out string value)
        {
            key = Key;
            value = Value;
        }

        public bool IsNull => Key < 0;
    }
}