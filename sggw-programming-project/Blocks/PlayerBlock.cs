using sggw_programming_project.Scene;
using System;

internal class PlayerBlock : Block
{
    public PlayerBlock()
    {
        Random random = new Random();
        this._icon = "\ud83d\udc36";
        this._x = random.Next(16);
        this._y = random.Next(16);
    }

}
