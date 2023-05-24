using sggw_programming_project.Blocks;
using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseScene scene1 = new BaseScene(12, 16, 16, new GrassBlock(), new List<Block>()
            {
                new Block(1,2,"stone"),
                new Block(1,3,"tree")
            });
            scene1.Render();
            /*
             TO DO:
                zrobić "silnik" renderowania dla sceny
            np. (tak jak dla powyżeszgo)

            mamy scene 16X16 gdzie 

            na polu (1,2) jest kamień
            na polu (1,3) drzewo

             */
        }
    }
}
