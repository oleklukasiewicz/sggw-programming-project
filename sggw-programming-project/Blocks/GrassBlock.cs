using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Blocks
{
    internal class GrassBlock: Block
    {
       
        public GrassBlock(int x,int y):base(x,y)
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
