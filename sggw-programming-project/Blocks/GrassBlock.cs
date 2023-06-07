using sggw_programming_project.Scene;
using System;
using System.Runtime.InteropServices;

namespace sggw_programming_project.Blocks
{
    internal class GrassBlock: Block
    {
       /* private string _icon;
        public override string Icon
        {
            get; 
        } */
        public GrassBlock(int x,int y):base(x,y)
        { 
        }
        public GrassBlock():base() 
        {
            Icon = "\ud83c\udf3f";
        }
        public GrassBlock(int x, int y, string icon) : base(x, y, icon)
        {

        }
       
    }
}
