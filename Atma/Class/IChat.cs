﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atma.Class
{
    internal interface IChat
    {
        List<ServerUser> ServerUsers { get; }
    }
}
