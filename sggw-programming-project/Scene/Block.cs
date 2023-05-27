using sggw_programming_project.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Scene
{
    internal class Block : IBlock
    {
        // klasa dla podstawowego pole (drzewo/ sciana / przeciwnik)
        public int X { get => _x; }
        public int Y { get => _y; }

        private int _x;
        private int _y;

        //wyświetlanie i interakcje
        public string Icon { get => _icon; }
        private string _icon;

        //czy da się wejść na pole?
        public bool CanBeStepIn { get; set; }

        public IBaseEntity BlockEntity { get => _entity; }
        private IBaseEntity _entity { get; set; }

        public Block(int x, int y, IBaseEntity entity)
        {
            _x = x;
            _y = y;
            _entity = entity;
        }
        public Block(int x, int y)
        {
            _x = x;
            _y = y;
            _entity = new BaseEntity();
        }
        public Block()
        {
            _x = 0;
            _y = 0;
            _entity = new BaseEntity();
        }
        public Block(int x, int y, string icon)
        {
            _x = x;
            _y = y;
            _icon = icon;
        }

        public void SetCoords(int x,int y)
        {
            _x = x;
            _y=y;
            // invoke event for scene update
        }
    }
}
