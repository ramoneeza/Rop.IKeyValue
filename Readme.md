# Rop.IKeyValue

Features
--------

Rop.IKeyValue is a group of interfaces and helpers to work with classes with a key property

`Interfaces` 
------

Interfaces to decorate classes

```csharp
    /// Interface for classes with a string key
    public interface IKey
    {
        string GetKey();
    }
    /// Interface for classes with a main value property
    public interface IValue
    {
        string GetValue();
    }
    /// Interface for classes with a key and a main value property
    public interface IKeyValue : IKey,IValue;
    /// Interface for classes with a int key
    public interface IIntKey : IKey
    {
        int GetIntKey();
    }
    /// Interface for classes with a int key and a main value property
    public interface IIntKeyValue : IIntKey,IValue;
```

`Dictionaries`
------

Dictionary for IKey interfaces

```csharp
/// String dictionary CASE aware
public class DictionaryNoCase<T>;
/// Dictionary of IKey items
public class KeyValueDic<T>;
/// Dictionary of IIntKey items
public class IntKeyValueDic<T>;
 ```

`Foo` clases
-------

Minimal implementation of IKey interfaces

```csharp
/// Simplest IIntKeyValue implementation
public class FooIntKeyValue : IIntKeyValue;
/// Simples IKeyValue implementation
public class FooKeyValue : IKeyValue;
/// Simplest IKeyValue record implementation
public record ImmutableKeyValue : IKeyValue;
/// Simples IIntKeyValue record implementation
public record ImmutableIntKeyValue : IIntKeyValue;
```

`KeyValue` helpers
-------

Helper class relative to IKey interfaces

```csharp
/// Convert enumerable of IKeys items to dictionary
public static KeyValueDic<T> ToKeyValueDic<T>(this IEnumerable<T> value);
/// Convert dictionary of IKeys items to KeyValueDictionary
public static KeyValueDic<T> ToKeyValueDic<T>(this IDictionary<string, T> value);
/// Convert a tuple in a FooKeyValue
public static FooKeyValue ToFooKeyValue(this (string, string) value);
public static FooKeyValue ToFooKeyValue(this (int, string) value);
/// Convert a tuple in a IntFooKeyValue
public static FooIntKeyValue ToFooIntKeyValue(this (int, string) value);
/// Convert an enumeration of tuples in a enumeration of FooKeyValue
public static IEnumerable<FooKeyValue> ToFooKeyValues(this IEnumerable<(string, string)> values);
/// Convert a enumeration of tuples in a enumeration of FooIntKeyValue
public static IEnumerable<FooIntKeyValue> ToFooIntKeyValues(this IEnumerable<(int, string)> values);
/// Convert a IKeyValue to a FooKeyValue;
public static FooKeyValue ToFooKeyValue(this IKeyValue kv);
/// Convert a IIntKeyValue to a FooKeyValue
public static FooKeyValue ToFooKeyValue(this IIntKeyValue kv);
/// Convert a IIntKeyValue to a FooIntKeyValue
public static FooIntKeyValue ToFooIntKeyValue(this IIntKeyValue kv);
/// Convert a IKeyValue to a ImmutableKeyValue
public static ImmutableKeyValue ToImmutable(this IKeyValue kv);
/// Convert a IIntKeyValue to a ImmutableIntKeyValue
public static ImmutableIntKeyValue ToImmutable(this IIntKeyValue kv);
/// Compares for equality two IKey classes to same key (Case insensitive)
public static bool EqualsKey(this IKey a, IKey b);
/// Compares for equality two IIntKey classes to same key
public static bool EqualsKey(this IIntKey a, IIntKey b);
```


 ------
 (C)2022 Ramón Ordiales Plaza
