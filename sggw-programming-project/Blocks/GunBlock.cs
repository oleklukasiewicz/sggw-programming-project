using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class GunBlock: Block
    {
        public override string Id { get; } = "gun";
        public override string Icon { get; set; } = "\ud83d\udd2a";
        public override BaseEntity BlockEntity => new UpdateDamageEntity(3);
    }
}
