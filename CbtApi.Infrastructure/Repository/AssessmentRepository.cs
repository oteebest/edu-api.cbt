using CbtApi.Core.Interface.IRepository;
using CbtApi.Core.Models.RequestModels;
using CbtApi.Core.Models.ResponseModels;
using CbtApi.Core.Util;
using CbtApi.Infrastructure.Context;
using CbtApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Infrastructure.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly AppDbContext _db;

        public AssessmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> AssesmentBelongsToUserAsync(string assesmentId, string userId)
        {
            return await _db.Assessments.AnyAsync(u => u.Id.Equals(assesmentId)
            && u.UserId == userId);

        }

        public async Task<AssessmentResponseModel> CreateAssessmentAsync(AssessmentRequestModel model,string userId)
        {

            var entity = model.Map(userId);

            _db.Assessments.Add(entity);

            await _db.SaveChangesAsync();

            return entity.Map();

        }

        public async Task<AssessmentResponseModel> UpdateAssessmentAsync(string id, AssessmentRequestModel model)
        {
            var assessment = _db.Assessments.FirstOrDefault(u => u.Id.Equals(id));

            if (assessment == null) throw new ProcessException("Assessment not found");

            assessment.Duration = model.Duration.Value;
            assessment.Instructions = model.Instructions;
            assessment.Name = model.Name;
           
            _db.Update(assessment);

            await _db.SaveChangesAsync();

            return assessment.Map();

        }

        public async Task DeleteAssessmentAsync(string id)
        {
            var assessment = await _db.Assessments.FindAsync(id);
            _db.Remove(assessment);

            await _db.SaveChangesAsync();

        }

        public async Task<AssessmentResponseModel> GetAssesmentAsync(string assesmentId)
        {
          
            var assessment = await _db.Assessments.FirstOrDefaultAsync(u => u.Id == assesmentId);

            return assessment.Map();
        }

        public async Task<IEnumerable<AssessmentResponseModel>> GetUserAsessmentsAsync(string userId)
        {

            var assessmentCol = await _db.Assessments.Where(u => u.UserId == userId)
                                   .ToListAsync();

            return assessmentCol.Select( u => u.Map());

        }
    }
}
