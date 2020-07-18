using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    [Authorize]
    [Route("api/v1/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionManager _questionManager;

        public QuestionController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateQuestion(QuestionRequestModel model)
        {

            var userId = User.Claims.First(u => u.Type.Equals("sub")).Value;

            var newQuestion = await _questionManager.CreateQuestionAsync(model,userId);

            var response =  new ResponseModel<QuestionResponseModel>(newQuestion, true, "Question created successfully");

            return Ok(response);
        }

        [HttpPut("{id}")]
        [Authorize("MustBeQuestionOwner")]
        public async Task<IActionResult> UpdateQuestion(string id,QuestionRequestModel model)
        {

            var userId = User.Claims.First(u => u.Type.Equals("sub")).Value;

            var newQuestion = await _questionManager.UpdateQuestionAsync(id,model, userId);

            var response = new ResponseModel<QuestionResponseModel>(newQuestion, true, "Question created successfully");

            return Ok(response);
        }


        [HttpGet("")]
        public async Task<IActionResult> GetQuestions(string subjectId,string difficultyLevelId,int pageNumber = 1,int pageSize = 20 )
        {
           
            var userId = User.Claims.First(u => u.Type.Equals("sub")).Value;

            var newQuestion = await _questionManager.GetUserQuestionsAsync(userId,subjectId,difficultyLevelId, pageNumber,pageSize);

            var response = new ResponseModel<PagedModel<QuestionResponseModel>>(newQuestion, true, "Information retrived successfully");

            return Ok(response);
        }
    }
}