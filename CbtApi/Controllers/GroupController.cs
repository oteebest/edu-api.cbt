using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CbtApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GroupController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Yes");
        }

        [HttpPost]
        public IActionResult CreateGroup()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGroup()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGroup()
        {
            return Ok();
        }
    }
}