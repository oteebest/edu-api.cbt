using CbtApi.Core.Models;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbtApi.Core.Util
{
    public static class CoreMapper
    {
        public static PagedModel<QuestionResponseModel> Map(this PagedModel<QuestionModel> model)
        {
            if (model == null) return null;

            return new PagedModel<QuestionResponseModel>(model.Items, model.TotalSize, model.PageNumber, model.PageSize);
        }
    }
}
