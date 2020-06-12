using CbtApi.Core.Interface.IManagers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbtApi.Authorization
{
    public class MustBeQuestionOwnerHandler : AuthorizationHandler<MustBeQuestionOwnerRequirement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IQuestionManager _questionManager;

        public MustBeQuestionOwnerHandler(IHttpContextAccessor httpContextAccessor,
            IQuestionManager questionManager)
        {
            _questionManager = questionManager;

            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MustBeQuestionOwnerRequirement requirement)
        {
            var questionId = _httpContextAccessor.HttpContext.GetRouteValue("id").ToString();

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


            if (!_questionManager.IsOwnerOfQuestionAsync(questionId, userId).Result)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
