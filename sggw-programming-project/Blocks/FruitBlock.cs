using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class FruitBlock : Block
    {
        public override string Id { get; } = "fruit";
        public override string Icon { get; set; } = "\ud83c\udf52";

        public FruitBlock()
        {
         
        }
    }
}
