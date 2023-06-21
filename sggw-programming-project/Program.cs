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
            Console.WriteLine("Witaj w naszej grze!");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            BaseScene scene1 = new BaseScene(1,16,16, 10, 3,10,15,10, 2, 1);
            scene1.MenuControl();
            scene1.Render();
            Task.Run(() => scene1.AddEnemyControls());
            scene1.AddCharacterControls();
            Console.ReadKey();
        }
    }

}
