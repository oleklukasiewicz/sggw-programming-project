using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class GrassBlock: Block
    {
        public override string Icon { get; } = "[ikonka]";

        // tak \/ albo tak /\ jak wolisz
        public GrassBlock(int x,int y):base(x,y,"[ikonka]")
        {
            //dodać entity dla trawy 
        }
        public GrassBlock():base() 
        { }
    }
}
