using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CbtApi.Authorization
{
    public class MustBeAssessmentOwnerRequirement : IAuthorizationRequirement
    {
        public MustBeAssessmentOwnerRequirement()
        {

        }
    }
}
