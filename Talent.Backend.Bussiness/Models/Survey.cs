﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Bussiness.Models
{
    public class Survey
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public DateTime DeletedAt { get; set; }
    }
}
