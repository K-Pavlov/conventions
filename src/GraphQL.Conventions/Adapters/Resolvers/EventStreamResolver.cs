﻿using GraphQL.Conventions.Types.Descriptors;
using GraphQL.Resolvers;
using GraphQL.Subscription;
using System;
using System.Threading.Tasks;

namespace GraphQL.Conventions.Adapters.Resolvers
{
    public class EventStreamResolver : FieldResolver, IEventStreamResolver
    {
        public EventStreamResolver(GraphFieldInfo fieldInfo) : base(fieldInfo)
        {
        }

        public IObservable<object> Subscribe(IResolveEventStreamContext context)
        {
            var result = base.Resolve(context);
            if (result is Task<object>)
            {
                result = (result as Task<object>).Result;
            }
            return (IObservable<object>)result;
        }

        public override object Resolve(IResolveFieldContext context)
        {
            return context.Source;
        }
    }
}
