using System;
using System.Collections.Generic;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.UnitTest.Stubs
{
    public static class SurveyStub
    {
        public static Survey survey_1 = new Survey()
        {
            Id = 1,
            Name = "Survey 1",
            CreatedAt = DateTime.Now,
        };

        public static Survey survey_2 = new Survey()
        {
            Id = 2,
            Name = "Survey 2",
            CreatedAt = DateTime.Now,
        };

        public static Pagination pagination = new Pagination
        {
            Page = 1,
            PageZise = 10
        };

        public static IEnumerable<Survey> surveyList = new List<Survey>(new Survey[]
        {
            survey_1,
            survey_2
        });
    }
}
