﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Cerseil.Injection
{
    public class DependencyContainer
    {
        private readonly IDictionary<Type, Type> types = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, object> typeInstances = new Dictionary<Type, object>();

        public DependencyContainer()
        {
        }

        public void Register<TContract, TImplementation>()
        {
            types[typeof(TContract)] = typeof(TImplementation);
        }

        public void Register<TContract, TImplementation>(TImplementation instance)
        {
            typeInstances[typeof(TContract)] = instance;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type contract)
        {
            if (typeInstances.ContainsKey(contract))
            {
                return typeInstances[contract];
            }
            else
            {
                Type implementation = types[contract];
                ConstructorInfo constructor = implementation.GetConstructors()[0];
                ParameterInfo[] constructorParameters = constructor.GetParameters();

                if (constructorParameters.Length == 0)
                {
                    return Activator.CreateInstance(implementation);
                }

                List<object> parameters = new List<object>(constructorParameters.Length);

                foreach (ParameterInfo parameterInfo in constructorParameters)
                {
                    parameters.Add(Resolve(parameterInfo.ParameterType));
                }

                return constructor.Invoke(parameters.ToArray());
            }
        }
    }
}
