using sggw_programming_project.Scene;
using System;

internal class TreeBlock:Block
{

    public TreeBlock()
	{
        this._icon = "\ud83c\udf33";

    }
    public void CreateTreeBlock()
    {
        Random random = new Random();
        this._x = random.Next(16);
        this._y = random.Next(16);
    }
}
