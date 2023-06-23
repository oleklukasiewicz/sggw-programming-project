using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    internal class HealingEntity : BaseEntity
    {
        public HealingEntity(int healing=10):base()
        {
            Healing = healing;
            IsItem = true;
        }
    }
}
