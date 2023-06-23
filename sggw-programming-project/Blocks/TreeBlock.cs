using sggw_programming_project.Scene;
using System;

internal class TreeBlock:Block
{
    public override string Id { get; } = "tree";
    public override bool CanBeStepIn { get; set; } = false;
    public override string Icon { get; set; } = "\ud83c\udf33";
}
