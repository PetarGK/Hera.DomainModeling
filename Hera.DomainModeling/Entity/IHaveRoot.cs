﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Entity
{
    public interface IHaveRoot<out TRoot>
    {
        TRoot Root { get; }
    }
}
