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
    [Authorize]
    public class AssessmentController : Controller
    {
        private readonly IAssessmentManager _assMan;

        public AssessmentController(IAssessmentManager assMan)
        {
            _assMan = assMan;
        }

        [HttpPost("")]      
        public async Task<IActionResult> CreateAssessment(AssessmentRequestModel model)
        {
             var userId = User.Claims.First(u => u.Type.Equals("sub")).Value;

             var response = await _assMan.CreateAssessment(model, userId);
            
            var responseModel = new ResponseModel<AssessmentResponseModel>(response, true, "Assessment created successfully");
           
            return Ok(responseModel);
        }

        [HttpDelete("{id}")]
        [Authorize("MustBeAssessmentOwner")]
        public async Task<IActionResult> DeleteAssessment(string id)
        {
     
            await _assMan.DeleteAssesmentAsync(id);

            var responseModel = new ResponseModel<AssessmentResponseModel>(null,true, "Assessment deleted successfully");

            return Ok(responseModel);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAssessments()
        {
            var userId = User.Claims.First( u => u.Type.Equals("sub")).Value;

            var response = await _assMan.GetUserAssessmentsAsync(userId);

            var responseModel = new ResponseModel<IEnumerable<AssessmentResponseModel>>(response, true);

            return Ok(responseModel);
   
        }

        [HttpGet("{id}")]
        [Authorize("MustBeAssessmentOwner")]
        public async Task<IActionResult> GetAssessment(string id)
        {
            var asessment =  await _assMan.GetAssessmentsAsync(id);

            return Ok(asessment);
        }

        [HttpPut("{id}")]
        [Authorize("MustBeAssessmentOwner")]
        public async Task<IActionResult> UpdateAssessment(string id, AssessmentRequestModel model )
        {
            
            var response = await _assMan.UpdateAssessmentAsync(id,model);

            var responseModel = new ResponseModel<AssessmentResponseModel>(response, true, "Assessment created successfully");

            return Ok(responseModel);
        }

    }
}