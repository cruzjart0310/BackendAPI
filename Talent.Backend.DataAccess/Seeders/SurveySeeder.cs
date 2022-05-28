using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF.Seeders
{
    public  class SurveySeeder
    {
        public void Seed()
        {
            var survey = new Survey
            {
                Id = 1,
                Name = ""

            };
        }
    }
}
