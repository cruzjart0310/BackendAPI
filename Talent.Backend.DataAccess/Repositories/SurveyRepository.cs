﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Repositories
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly EFContext _context;

        public SurveyRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Survey> CreateAsync(Survey survey)
        {
            survey.CreatedAt = DateTime.Now;
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Surveys.SingleAsync(s => s.Id == id);

            item.DeletedAt = DateTime.Now;
            _context.Surveys.Update(item);
            _context.Entry(item).Property(x => x.Name).IsModified = false;
            _context.Entry(item).Property(x => x.CreatedAt).IsModified = false;
            _context.Entry(item).Property(x => x.UpdatedAt).IsModified = false;
            await _context.SaveChangesAsync();

            //var item = await _context.Survey.SingleAsync(s => s.Id == id);
            //_context.Survey.Remove(item);
            //_context.Entry(item).Property(x => x.CreatedAt).IsModified = false;
            //_context.Entry(item).Property(x => x.UpdatedAt).IsModified = false;
            //await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id) =>
            await _context.Surveys
                .Where(s => s.DeletedAt == null)
                .AnyAsync(x => x.Id == id);

        public async Task<IEnumerable<Survey>> GetAllAsync(Pagination pagination)
        {
            #region Earge loading
            //var q = await _context.Set<Survey>()
            //    .Where(s => s.DeletedAt == null)
            //    .Include(x => x.Questions)
            //        .ThenInclude(x => x.Type)
            //    .Include(x => x.Questions)
            //        .ThenInclude(x => x.Answers)
            //    .OrderBy(x => x.Id)
            //    .AsNoTracking()
            //    .AsQueryable()
            //    .Skip((pagination.Page - 1) * pagination.PageZise)
            //    .Take(pagination.PageZise)
            //    .ToListAsync();
            #endregion

            var query = await _context.Set<Survey>()
                .Where(s => s.DeletedAt == null)
                .OrderBy(x => x.Id)
                .Select(s => new Survey
                {
                    Id = s.Id,
                    Name = s.Name,
                    Questions = s.Questions.Select(q => new Question
                    {
                        Id = q.Id,
                        Title = q.Title,
                        Type = new QuestionType
                        {
                            Id = q.Type.Id,
                            Title = q.Title,
                        },
                        Answers = q.Answers.Select(a => new Answer
                        {
                            Id = a.Id,
                            Title = a.Title,
                            IsCorrect = a.IsCorrect,
                            CreatedAt = a.CreatedAt,
                        }),
                        CreatedAt = q.CreatedAt,
                    }),
                    CreatedAt = s.CreatedAt,
                })

                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();

            return query;
        }

        public async Task<Survey> GetAsync(int id)
        {
            var item = await _context.Surveys
                .Where(s => s.DeletedAt == null)
                .Include(q => q.Questions)
                    .ThenInclude(t => t.Type)
                 .Include(qa => qa.Questions)
                    .ThenInclude(a => a.Answers)
                .AsNoTracking()
                //.FirstAsync(x => x.Id == Convert.ToInt32(id)); //GetException
                .SingleOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<int> GetTotalRecorsdAsync() =>
            await _context.Surveys
                .Where(s => s.DeletedAt == null)
                .CountAsync();

        public async Task UpdateAsync(Survey survey)
        {
            survey.UpdatedAt = DateTime.Now;
            _context.Surveys.Update(survey);
            _context.Entry(survey).Property(x => x.CreatedAt).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}
