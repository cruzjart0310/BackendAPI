﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;
using Talent.Backend.Service.Mappers;

namespace Talent.Backend.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionBussiness _questionBussiness;

        public QuestionService(IQuestionBussiness questionBussiness)
        {
            _questionBussiness = questionBussiness;
        }

        public async Task<QuestionDto> CreateAsync(QuestionDto questionDto)
        {
            var questionMap = QuestionMapper.Map(questionDto);
            var questions = await _questionBussiness.CreateAsync(questionMap);
            return QuestionMapper.Map(questions);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var Questions = await _questionBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return Questions.Select(QuestionMapper.Map);
        }

        public Task<QuestionDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecorsdAsync()
        {
            return await _questionBussiness.GetTotalRecorsdAsync();
        }

        public async Task SaveDataFromFile(IFormFile file)
        {
            await _questionBussiness.SaveDataFromFile(file);
        }

        public Task UpdateAsync(QuestionDto questionDto)
        {
            throw new NotImplementedException();
        }
    }
}
