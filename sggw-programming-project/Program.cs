using sggw_programming_project.Blocks;
using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Block _default = new Block(4, 4, "\ud83d\udfea");
            BaseScene scene1 = new BaseScene(1, 16, 16, _default, new List<Block>()
            {
                new Block(0,0,"\ud83d\udc36"), //gracz
                new Block(1,1,"\ud83c\udf33"), //drzewo
                new Block(5,5, "\ud83e\udea8"), //kamień
                new Block(8,4,"\ud83c\udf52"), //owoc - nagroda
                new Block(10,15,"\ud83c\udf31"), //roślinka - trawa?
                new Block(9,5,"\ud83e\udeb5") //pień

            });
            scene1.Render();
            Console.ReadKey();
            Console.Clear();
            scene1.MoveBlock(0, 0, 4, 5);
            Console.ReadKey();
        }
    }
}
