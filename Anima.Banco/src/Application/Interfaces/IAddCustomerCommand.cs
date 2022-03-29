using System;
using Anima.Banco.Application.Requests;
using Anima.Banco.Application.Responses;

namespace Anima.Banco.Application.Interfaces
{
    public interface IAddCustomerCommand<TRequest, TResponse>
        where TRequest : AddCustomerRequest
        where TResponse : AddCustomerResponse
    {
        TResponse Handle(TRequest request);
    }
}
