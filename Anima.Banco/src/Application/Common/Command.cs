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

        protected abstract TResponse Changes(TRequest request);

        public virtual TResponse Handle(TRequest request)
        {
            var response = Changes(request);

            if(response.IsSuccess) _repository.Commit();

            return response;
        }        
    }
}
