using sggw_programming_project.Blocks;
using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            BaseScene scene1 = new BaseScene(1,16,16, 10, 5,10,15,10);
            scene1.Render();
            //scene1.MoveBlock(0, 0, 4, 5);
            scene1.AddCharacterControls();
            Console.ReadKey();
        }
        /* To DO:
         * - sterowanie bloczkiem Enemy, aby sam podążał za graczem
         * - dodanie mechaniki gry:
         * * a) zbieranie punktów/owoców i odkładanie się punktów
         * * b) zabijanie przeciwnika i eliminowanie go z planszy
         * * c) uniemożliwienie playerowi przejścia gdy na mapce są przeszkody
         * * (obecnie player znika z planszy gdy wchodzi na miejsce innego bloku
         * * d) bloczki-owoce co kilka sekund losowo zmieniają swoje położenie
         * */
    }

}
