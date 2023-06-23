using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class CandyBlock:Block
    {
        public override string Id { get; } = "candy";
        public override string Icon { get; set; } = "\ud83c\udf6c";

        public override BaseEntity BlockEntity { get; } = new HealingEntity(1);
    }
}
