﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Axway.Database.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public string GradeValue { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}