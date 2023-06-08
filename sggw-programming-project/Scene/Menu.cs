using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Scene
{
    internal class Menu
    {
        public Block _player;

        public Menu(Block player)
        {
            _player = player;
        }

        public void ChooseAvatar()
        {
            Console.WriteLine("Wybierz swój avatar:");
            Console.WriteLine("Wpisz 1 aby wybrać " + "\ud83d\udc36");
            Console.WriteLine("Wpisz 2 aby wybrać " + "\ud83d\udc80");
            Console.WriteLine("Wpisz 3 aby wybrać " + "\ud83e\udd8b");
            Console.WriteLine("Wpisz 4 aby wybrać " + "\ud83d\udc2d");
            Console.WriteLine("Wpisz 5 aby wybrać " + "\ud83c\udf1e");

            ConsoleKeyInfo pressedKey;

            pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.D1:
                    _player.Icon = "\ud83d\udc36";
                    break;
                case ConsoleKey.D2:
                    _player.Icon = "\ud83d\udc80";
                    break;
                case ConsoleKey.D3:
                    _player.Icon = "\ud83e\udd8b";
                    break;
                case ConsoleKey.D4:
                    _player.Icon = "\ud83d\udc2d";
                    break;
                case ConsoleKey.D5:
                    _player.Icon = "\ud83c\udf1e";
                    break;
                default:
                    break;
            }
         
        }
    }
}
