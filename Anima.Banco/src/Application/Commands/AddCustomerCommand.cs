using System;
using System.Collections.Generic;
using Anima.Banco.Application.Common;
using Anima.Banco.Application.Requests;
using Anima.Banco.Application.Responses;
using Anima.Banco.Domain.Core.Entities;

namespace Anima.Banco.Application.Commands
{
    // os comandos são instruçoes que alteram o estado do servidor
    public class AddCustomerCommand : Command<AddCustomerRequest, AddCustomerResponse>
    {
        public static List<Customer> Customers = new List<Customer>();

        //todo metodo handle tem que caracterizar um transação
        public override AddCustomerResponse Handle(AddCustomerRequest request)
        {
            var customer = new Customer(request.Name, request.Email);
            
            Customers.Add(customer);

            return new AddCustomerResponse
            {
                Id = customer.Id,
                CreatedAt = customer.CreatedAt
            };
        }
    }
}
