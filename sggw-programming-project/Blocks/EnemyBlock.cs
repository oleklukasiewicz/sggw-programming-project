using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class EnemyBlock : Block
    {
        public override string Id { get; } = "enemy";
        public override string Icon { get; set; } = "\ud83d\ude21";
        public override BaseEntity BlockEntity { get; } = new Enemy();
    }
}
