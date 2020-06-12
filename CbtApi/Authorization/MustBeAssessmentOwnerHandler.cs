using CbtApi.Core.Interface.IManagers;
using CbtApi.Core.Interface.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbtApi.Authorization
{
    public class MustBeAssessmentOwnerHandler : AuthorizationHandler<MustBeAssessmentOwnerRequirement>
    {
       
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAssessmentManager _assessmentManager;

        public MustBeAssessmentOwnerHandler(IHttpContextAccessor httpContextAccessor,
            IAssessmentManager assessmentManager)
        {
            _assessmentManager = assessmentManager;

            _httpContextAccessor = httpContextAccessor;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MustBeAssessmentOwnerRequirement requirement)
        {

            var assessmentId = _httpContextAccessor.HttpContext.GetRouteValue("id").ToString();

            var userIdClaim = context.User.Claims.FirstOrDefault(u => u.Type.Equals("sub"));

            if (userIdClaim == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var userId = userIdClaim.Value;

            if (!Guid.TryParse(userId, out Guid userIdIdAsGuid))
            {
                context.Fail();
                return Task.CompletedTask;
            }


            if (!_assessmentManager.IsOwnerOfAssesmentAsync(assessmentId, userId).Result)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
