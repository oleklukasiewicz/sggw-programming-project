using sggw_programming_project.Scene;
using System;
using System.Runtime.InteropServices;

namespace sggw_programming_project.Blocks
{
    internal class GrassBlock: Block
    {
        public override string Id { get; } = "grass";
        public override string Icon { get; set; } = "\ud83c\udf3f";

    }
}
