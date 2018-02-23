using System;
using System.Collections.Generic;

namespace Cerseil.ObjectMapping
{
    public interface IObjectMapper
    {
        Type SourceType { get; }

        Type DestinationType { get; }

        object Map(object sourceObject);

        object Map(object sourceObject, object destinationObject);
    }

    public interface IObjectMapper<TSource, TDestination> : IObjectMapper
        where TSource : class 
        where TDestination : new()
    {
        TDestination Map(TSource source);

        TDestination Map(TSource source, TDestination destination);

        IEnumerable<TDestination> Map(IEnumerable<TSource> sources);

        IObjectMapper<TSource, TDestination> Explicit(Action<TSource, TDestination> explicitAction);
    }
}
