using System;
using System.Collections.Generic;

namespace DeveloperSample.Container;

public class Container
{
    Dictionary<Type, Type> _bindings = new();
    public void Bind(Type interfaceType, Type implementationType) {
        _bindings.Add(interfaceType, implementationType);
    }
    public T Get<T>() {
        return (T)Activator.CreateInstance(_bindings[typeof(T)]);
    }
}