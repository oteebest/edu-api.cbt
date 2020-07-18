using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Models;
using CbtApi.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbtApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        IPredefindDataManager _predDataManager;
        public DataController(IPredefindDataManager predDataManager)
        {
            _predDataManager = predDataManager;
        }

        [Authorize]
        [HttpGet()]
        public async Task<IActionResult> GetPredefinedData()
        {
           var response = await _predDataManager.GetPredefinedDataAsync();

            var responseModel = new ResponseModel<PredefinedResponseModel>(response, true, "Data retrieved successfully");

            return Ok(responseModel);
        }
    
    }
}