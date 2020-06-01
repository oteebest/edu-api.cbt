using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CbtApi.Controllers
{
    [ApiController]
    [Route("api/vi/[controller]")]
    public class TopicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}