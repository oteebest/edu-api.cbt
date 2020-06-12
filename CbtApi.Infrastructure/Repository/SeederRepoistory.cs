using CbtApi.Core.Interface.IRepository;
using CbtApi.Infrastructure.Context;
using CbtApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CbtApi.Infrastructure.Repository
{
    public class SeederRepoistory : ISeederRepoistory
    {
        private readonly AppDbContext _db;
        public SeederRepoistory(AppDbContext db)
        {
            _db = db;
        }

        public async Task Seed()
        {


            if (!_db.DifficultyLevels.Any())
            {
                List<DifficultyLevel> difficulties = new List<DifficultyLevel>
                {
                 new DifficultyLevel{ Name = "Easy" },
                 new DifficultyLevel{ Name = "Medium"},
                 new DifficultyLevel{ Name = "Hard"},
                 new DifficultyLevel{ Name = "Very Hard"},
                };

                await _db.AddRangeAsync(difficulties);
                await _db.SaveChangesAsync();
            }

            if (!_db.Subjects.Any())
            {
                List<Subject> subjects = new List<Subject>
                { 
                 new Subject{ Name = "Mathematics" },
                 new Subject{ Name = "English"},
                 new Subject{ Name = "Numerical Reasoning"},
                 new Subject{ Name = "Verbal Reasoning"},
                };

                await _db.AddRangeAsync(subjects);

                await _db.SaveChangesAsync();
            }

        }
    }
}
