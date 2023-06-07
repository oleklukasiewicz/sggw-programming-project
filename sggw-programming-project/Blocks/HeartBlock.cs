using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class HeartBlock:Block
    {
        public override string Id { get; } = "heart";
        public override string Icon { get; set; } = "\ud83d\udc96";

    }
}
