using System;
using Anima.Banco.Domain.Shared.Interfaces;

namespace Anima.Banco.Application.Common
{
    public abstract class Command<TRequest, TResponse>
        where TRequest : Request
        where TResponse : Response
    {
        protected IWriteRepository _repository;

        public Command(IWriteRepository repository)
        {
            _repository = repository;
        }


        public abstract TResponse Handle(TRequest request);        
    }
}
