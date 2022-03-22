﻿namespace Anima.Banco.Application.Common
{
    public abstract class Query<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        public abstract TResponse Handle(TRequest request);
    }
}
