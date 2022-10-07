namespace Rop.Helper
{
    /// <summary>
    /// Interface for classes with a string key
    /// </summary>
    public interface IKey
    {
        string GetKey();
    }
    /// <summary>
    /// Interface for classes with a main value property
    /// </summary>
    public interface IValue
    {
        string GetValue();
    }
    /// <summary>
    /// Interface for classes with a key and a main value property
    /// </summary>
    public interface IKeyValue : IKey,IValue
    {
    }
    /// <summary>
    /// Interface for classes with a int key
    /// </summary>
    public interface IIntKey : IKey
    {
        int GetIntKey();
    }
    /// <summary>
    /// Interface for classes with a int key and a main value property
    /// </summary>
    public interface IIntKeyValue : IIntKey,IKeyValue
    {
    }
}