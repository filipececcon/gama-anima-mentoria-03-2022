using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anima.Banco.Service.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        //irão ficar os nossos endpoints
        [HttpPost]
        public Object Add(object request)
        {
            return new object();
        }


    }
}