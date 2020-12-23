using CbtApi.Core.Models;
using CbtApi.Core.Models.Models;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CbtApi.Core.Util
{
    public static class Mapper
    {

     

        public static DifficultLevelResponseModel Map(this DifficultyLevel entity)
        {
            if (entity == null) return null;

            return new DifficultLevelResponseModel
            {
                Name = entity.Name,
                Id = entity.Id,
            };

        }


        public static Subject Map(this SubjectResponseModel model)
        {
            if (model == null) return null;

            return new Subject
            {
                Name = model.Name,
                Id = model.Id,
            };

        }

        public static SubjectResponseModel Map(this Subject entity)
        {
            if (entity == null) return null;

            return new SubjectResponseModel
            {
                Name = entity.Name,
                Id = entity.Id,
            };

        }

        public static Assessment Map(this AssessmentRequestModel model, string userId)
        {
            if (model == null) return null;

            return new Assessment
            {
                Name = model.Name,
                Instructions = model.Instructions,
                Duration = model.Duration.Value,
                UserId = userId
            };

        }

   

        public static AssessmentResponseModel Map(this Assessment entity)
        {
            if (entity == null) return null;

            return new AssessmentResponseModel
            {
                Name = entity.Name,
                CreatedOn =  entity.CreatedOn,
                Id = entity.Id,
                Instructions = entity.Instructions,
                 Duration = entity.Duration
            };

        }

        #region UserSubscription
        public static UserSubscriptionResponseModel Map(this UserSubscription entity)
        {
            if (entity == null) return null;

            return new UserSubscriptionResponseModel
            {
                SubscriptionId = entity.SubscriptionId,
                CreatedOn =  entity.CreatedOn,
                Id = entity.Id,
                UserId = entity.UserId,
            };

        }

        #endregion

        public static Question Map(this QuestionRequestModel model, string userId,string questionId = "")
        {

            if (model == null) return null;

            Question question = new Question
            {
                ScoreValue = model.ScoreValue.Value,
                Text = model.Text,
                QuestionType = model.QuestionType,
                ShuffleOptions = model.ShuffleOptions.Value,
                SubjectId = model.SubjectId,
                DifficultyLevelId = model.DifficultyLevelId,
                UserId = userId,
                Options = model.Options.Select(u => new Option
                {
                    IsAnswer = u.IsAnswer.Value,
                    Text = u.Text
                }).ToList()

            };

            if(!string.IsNullOrEmpty(questionId))
            {
                question.Id = questionId;
            }
            

            return question;
        }

    

     
        public static QuestionModel Map(this Question entity)
        {

            if (entity == null) return null;

            QuestionModel question = new QuestionModel
            {
                Id = entity.Id,
                Text = entity.Text,
                ScoreValue = entity.ScoreValue,
                QuestionType = entity.QuestionType,
                DifficultyLevelId = entity.DifficultyLevelId,
                DifficultyLevel = entity.DifficultyLevel.Name,
                SubjectId = entity.SubjectId,
                Subject = entity.Subject.Name,
                ShuffleOptions = entity.ShuffleOptions,
                UserId = entity.UserId,
                Options = entity.Options.Select(u => new QuestionOption
                {
                    IsAnswer = u.IsAnswer,
                    Text = u.Text
                }).ToList()

            };

            return question;
        }

    }
}
