﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJ.Framework.Data.Tests.EntityFramework5
{
    public class Model1Context : DbContext
    {
        public Model1Context(string specialConnectionString)
            : base(specialConnectionString)
        { }
    }
}
