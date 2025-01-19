using System;

[AttributeUsage(AttributeTargets.Class)]
public class AutoRegisterAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Method)]
public class ApiEndpointAttribute : Attribute
{
    public string Route { get; }

    public ApiEndpointAttribute(string route)
    {
        Route = route;
    }
}
