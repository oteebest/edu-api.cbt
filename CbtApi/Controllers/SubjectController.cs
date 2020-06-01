﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CbtApi.Controllers
{
    [ApiController]
    [Route("api/vi/[controller]")]
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}