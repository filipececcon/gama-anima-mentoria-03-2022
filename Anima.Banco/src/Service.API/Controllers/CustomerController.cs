using System;
using Anima.Banco.Application.Commands;
using Anima.Banco.Application.Queries;
using Anima.Banco.Application.Requests;
using Anima.Banco.Domain.Core.Exceptions;
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

        // trantando erros de requisiçao com exception
        //[HttpGet("{id}")]
        //public IActionResult GetById([FromRoute] Guid id)
        //{
        //    try { 

        //        var query = new GetCustomerByIdQuery(_rrepository);

        //        var request = new GetCustomerByIdRequest() { Id = id };

        //        var response = query.Handle(request);

        //        return Ok(response);

        //    }
        //    catch (CustomerException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //}

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var query = new GetCustomerByIdQuery(_rrepository);

            var request = new GetCustomerByIdRequest() { Id = id };

            var response = query.Handle(request);

            return response.IsSuccess ? Ok(response) : NotFound(new { errors = response.Errors });
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateCustomerRequest request, [FromRoute] Guid id)
        {
            request.SetId(id);

            var cmd = new UpdateCustomerCommand(_wrepository);

            var response = cmd.Handle(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveById([FromRoute] Guid id)
        {
            var cmd = new RemoveCustomerCommand(_wrepository);

            var request = new RemoveCustomerRequest() { Id = id };

            var response = cmd.Handle(request);

            return Ok();
        }
    }
}