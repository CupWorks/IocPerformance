﻿using System;

namespace IocPerformance.Adapters
{
    public sealed class NoContainerAdapter : IContainerAdapter
    {
        private static readonly Type IInterface1Type = typeof(ITransient);
        private static readonly Type IInterface2Type = typeof(ISingleton);
        private static readonly Type CombinedType = typeof(ICombined);

        private static readonly ITransient singleton = new Transient();

        public void Prepare()
        {
        }

        public T Resolve<T>() where T : class
        {
            Type serviceType = typeof(T);

            if (serviceType == IInterface1Type)
            {
                return (T)singleton;
            }
            else if (serviceType == IInterface2Type)
            {
                ISingleton transient = new Singleton();
                return (T)transient;
            }
            else if (serviceType == CombinedType)
            {
                ICombined combined = new Combined(singleton, new Singleton());
                return (T)combined;
            }

            throw new InvalidOperationException(typeof(T).FullName);
        }

        public void Dispose()
        {
        }
    }
}