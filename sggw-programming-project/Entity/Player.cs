using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Entity
{
    internal class Player : BaseEntity
    {
        public Player():base()
        {
            Health = 10;
            Damage = 2;
            IsItem = false;
            IsImmune = false;
        }
    }
}
