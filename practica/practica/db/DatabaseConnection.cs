﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pracrica.db
{
    public static class DatabaseConnection
    {
        public static string ConnectionString => @"Server=localhost,1433;Database=practice;User Id=SA;Password=SomePassword123!@#;";
    }
}
