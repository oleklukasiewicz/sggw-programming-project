using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    internal class Enemy : BaseEntity
    {
        public Enemy():base()
        {
            Health = 10;
            Damage = 4;
            IsItem = false;
            IsImmune = false;
        }
    }
}
