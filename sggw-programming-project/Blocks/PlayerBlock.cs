using sggw_programming_project.Scene;
using System;

internal class PlayerBlock : Block
{
   // public override string Icon { get; set; } = "\ud83d\udc36";
    public override string Id { get; } = "player";

    public override  int Health { get; set; } = 100;
    public PlayerBlock() : base()
    {
        this.SetRandomLocation();
       

    }

}
// kod na diamencik: \ud83d\udc8e