using sggw_programming_project.Scene;
using System;


namespace sggw_programming_project.Blocks
{
    internal class TrunkBlock : Block
    {
        public override string Id { get; } = "trunk";
        public override bool CanBeStepIn {get; set;} = false;
        public override string Icon { get; set; } = "\ud83e\udeb5";
        public TrunkBlock():base()
        {
            
        }
    }
}
