using sggw_programming_project.Scene;
using System;

internal class StoneBlock : Block
{

	public StoneBlock()
	{
		this._icon = "\ud83e\udea8";

    }
    public void CreateStoneBlock()
    {
        Random random = new Random();
        this._x = random.Next(16);
        this._y = random.Next(16);
    }

}
