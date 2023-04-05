﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.WebApi.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : Attribute
    {
        public Type[] DbContextTypes { get; init; }
        public UnitOfWorkAttribute(params Type[] dbContextTypes)
        {
            DbContextTypes = dbContextTypes;
        }
    }
}
