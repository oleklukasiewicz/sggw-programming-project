using sggw_programming_project.Scene;
using System;

namespace sggw_programming_project.Blocks
{
    internal class GrassBlock: Block
    {
        public override string Icon { get; } = "[ikonka]";

        // tak \/ albo tak /\ jak wolisz
        public GrassBlock(int x,int y):base(x,y,"[ikonka]")
        {
         //chciałabym tu przypisać domyślną ikonke, ale jak sie odwołać do tej zmiennej?
        }
        public GrassBlock():base() 
        { }
        public GrassBlock(int x, int y, string icon) : base(x, y, icon)
        {

        }
       
    }
}
