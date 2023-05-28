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
        public FruitBlock()
        {
            this._icon = "\ud83c\udf52";
        }

        public void CreateFruitBlock()
        {
            Random random = new Random();
            this._x = random.Next(16);
            this._y = random.Next(16);
        }
    }
}
