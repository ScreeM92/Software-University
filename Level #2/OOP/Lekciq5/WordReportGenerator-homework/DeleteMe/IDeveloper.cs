﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReportGenerator.DeleteMe
{
    public interface IDeveloper : IEmployee
    {
        IList<Project> Projects { get; set; }
    }

    public class Project
    {
    }
}
