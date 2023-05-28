using sggw_programming_project.Scene;
using System;


namespace sggw_programming_project.Blocks
{
    internal class TrunkBlock: Block
    {
        public TrunkBlock()
        {
            this._icon = "\ud83e\udeb5";
        }
        public void CreateTrunkBlock()
        {
            Random random = new Random();
            this._x = random.Next(16);
            this._y = random.Next(16);
        }
    }
}
