using sggw_programming_project.Scene;
using System;

internal class StoneBlock : Block
{
    public override string Id { get; } = "stone";
    public override bool CanBeStepIn { get; set; } = false;
    public override string Icon { get; set; } = "\ud83e\udea8";
    public StoneBlock()
	{
		

    }
}
