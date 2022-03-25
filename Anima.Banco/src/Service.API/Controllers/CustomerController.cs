using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anima.Banco.Application.Commands;
using Anima.Banco.Application.Queries;
using Anima.Banco.Application.Requests;
using Anima.Banco.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anima.Banco.Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public IWriteRepository _repository;

        public CustomerController(IWriteRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public IActionResult Add(AddCustomerRequest request)
        {
            var cmd = new AddCustomerCommand(_repository);

            var response = cmd.Handle(request);

            return Created("", response);
        }

        [HttpGet("{id}")]        
        public IActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetCustomerByIdQuery();

            var request = new GetCustomerByIdRequest() { Id = id };

            var response = query.Handle(request);

            return Ok(response);
        }
    }
}