using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CbtApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AssessmentController : Controller
    {
        private readonly IAssessmentManager _assMan;

        public AssessmentController(IAssessmentManager assMan)
        {
            _assMan = assMan;
        }

        [HttpPost("")]
     //   [Authorize]
        public async Task<IActionResult> CreateAssessment(AssessmentRequestModel model)
        {
           // var userId = User.Claims.First(u => u.Type.Equals("sub")).Value;

             string userId = "818727";

            var response = await _assMan.CreateAssessment(model, userId);
            
            var responseModel = new ResponseModel<AssessmentResponseModel>(response, true, "Assessment created successfully");
           
            return Ok(responseModel);
        }

        [HttpGet("")]
        [Authorize]
        public async Task<IActionResult> GetAssessments()
        {
            var userId = User.Claims.First( u => u.Type.Equals("sub")).Value;

           // string userId = "818727";

            var response = await _assMan.GetUserAssessmentsAsync(userId);

            var responseModel = new ResponseModel<IEnumerable<AssessmentResponseModel>>(response, true);

            return Ok(responseModel);
   
        }

        [HttpGet("{id}")]
        [Authorize("MustBeAssessmentOwner")]
        public IActionResult GetAssessment(string id)
        {
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateAssessment(string id, AssessmentRequestModel model )
        {
            return Ok();
        }

    }
}