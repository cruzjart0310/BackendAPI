﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Bussiness.Contracts
{
    public interface IUserPoint
    {
        Task<UserPointResponse<User>> GetPointsAsync(string userId, int surveyId);
    }
}
