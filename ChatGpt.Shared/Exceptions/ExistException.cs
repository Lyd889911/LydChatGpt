﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt.Shared.Exceptions
{
    public class ExistException:Exception
    {
        public ExistException(string message):base(message)
        {

        }
    }
}
