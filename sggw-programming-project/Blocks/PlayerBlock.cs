using sggw_programming_project.Scene;
using System;

internal class PlayerBlock : Block
{
    public override string Icon { get; set; } = "\ud83d\udc36";
    public override string Id { get; } = "player";
    public PlayerBlock() : base()
    {
        this.SetRandomLocation();
    }

}
