using System;
using Anima.Banco.Application.Commands;
using Anima.Banco.Application.Queries;
using Anima.Banco.Application.Requests;
using Anima.Banco.Domain.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Anima.Banco.Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        public IWriteRepository _wrepository;
        public IReadRepository _rrepository;


        public CustomerController(IWriteRepository wrepository, IReadRepository rrepository)
        {
            _wrepository = wrepository;
            _rrepository = rrepository;
        }


        [HttpPost]
        public IActionResult Add([FromBody] AddCustomerRequest request)
        {
            var cmd = new AddCustomerCommand(_wrepository);

            var response = cmd.Handle(request);

            return Created("", response);
        }

        [HttpGet("{id}")]        
        public IActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetCustomerByIdQuery(_rrepository);

            var request = new GetCustomerByIdRequest() { Id = id };

            var response = query.Handle(request);

            return Ok(response);
        }
    }
}