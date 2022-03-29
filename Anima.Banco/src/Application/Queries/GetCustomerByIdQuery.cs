using System;
using System.Linq;
using Anima.Banco.Application.Commands;
using Anima.Banco.Application.Common;
using Anima.Banco.Application.Requests;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Interfaces;

namespace Anima.Banco.Application.Queries
{
    public class GetCustomerByIdQuery : Query<GetCustomerByIdRequest, GetCustomerByIdResponse>
    {
        public GetCustomerByIdQuery(IReadRepository repository) : base(repository)
        {
        }

        public override GetCustomerByIdResponse Handle(GetCustomerByIdRequest request)
        {
            var customer = _repository.AsQueryable<Customer>().SingleOrDefault(x => x.Id == request.Id);

            if (customer == null) return null;

            return new GetCustomerByIdResponse
            {
                Id = customer.Id,
                CreatedAt = customer.CreatedAt,
                Email = customer.Email,
                IsActive = customer.IsActive,
                Name = customer.Name,
                UpdatedAt = customer.UpdatedAt
            };
        }
    }
}
