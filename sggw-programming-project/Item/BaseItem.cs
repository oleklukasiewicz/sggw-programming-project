﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Item
{
    internal class BaseItem
    {
        public virtual string Id { get; }
        public virtual string Icon { get; set; }
        public virtual int Damage { get; set; }
    }
}
