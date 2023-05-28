using sggw_programming_project.Entity;
using System;

namespace sggw_programming_project.Scene
{
    internal class Block : IBlock
    {
        // klasa dla podstawowego pole (drzewo/ sciana / przeciwnik)
        protected int _x;
        public int X
        {
            get
            {
               return _x;
            }
        }

        protected int _y;
        public int Y
        {
            get
            {
                return _y;
            }
        }

        //wyświetlanie i interakcje
        public string Icon { get => _icon; }
        protected string _icon;

        //czy da się wejść na pole?
        public bool CanBeStepIn { get; set; } = true;

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
        public Block(string icon)
        {
          _icon = icon;
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
        public Block(int x,int y, string icon, IBaseEntity entity)
        {
            _x = x;
            _y = y;
            _entity = entity;
            _icon = icon;
        }
        public void SetCoords(int x,int y)
        {
            _x = x;
            _y = y;
            // invoke event for scene update
        }
        
        public void MoveUp()
        {
            if(_x > 0 && _x <= 15) 
            _x -= 1;

        }

        public void MoveDown()
        {
            if(_x >= 0 && _x < 15)
            _x += 1;
        }

        public void MoveRight()
        {
            if(_y >=0 && _y < 15)
            _y += 1;
        }

        public void MoveLeft()
        {
            if(_y > 0 && _y <=15)
            _y -=1;
        }

        public void SetRandomLocation()
        {
            Random random = new Random();
            this._x = random.Next(16);
            this._y = random.Next(16);
        }

    }

}
