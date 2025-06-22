using System;
using System.Data.SqlTypes;

namespace projectJuin;

public static class Services
{
    private static Dictionary<Type, object> services = new Dictionary<Type, object>();

    public static void Register<Tservice>(Tservice service)
    {
        if (services.ContainsKey(typeof(Tservice)))
            throw new InvalidOperationException($"Service of type {typeof(Tservice)} is already registered");
        if (service == null)
            throw new ArgumentNullException("service");
        services[typeof(Tservice)] = service;
    }

    public static T Get<T>()
    {
        if (!services.ContainsKey(typeof(T)))
            throw new InvalidOperationException($"Service of type {typeof(T)} not registered");
        return (T) services[typeof(T)];    
    }   
}
