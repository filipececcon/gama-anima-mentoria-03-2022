using System;
using System.Linq;
using Anima.Banco.Application.Common;
using Anima.Banco.Application.Requests;
using Anima.Banco.Application.Responses;
using Anima.Banco.Domain.Core.Entities;
using Anima.Banco.Domain.Shared.Interfaces;
using Anima.Banco.Infrastructure.Data.Persistence.Extensions;

namespace Anima.Banco.Application.Queries
{
    public class GetCustomerQuery : Query<GetCustomerRequest, GetCustomerResponse>
    {
        public GetCustomerQuery(IReadRepository repository) : base(repository)
        {
        }

        public override GetCustomerResponse Handle(GetCustomerRequest request)
        {
            //usamos um predicate builder para montar uma expressao where para base de dados de forma condicional

            var predicate = PredicateBuilder.New<Customer>();

            if (request.Name != null) predicate = predicate.And(x => x.Name.Contains(request.Name)); 

            if (request.Email != null) predicate = predicate.And(x => x.Email.Contains(request.Email));

            var result = _repository
                .AsQueryable<Customer>()
                .Where(predicate)
                .Select(x => new GetCustomerResponseItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt
                });

            return new GetCustomerResponse() { Data = result };
        }
    }
}
