using sggw_programming_project.Entity;
using System;

namespace sggw_programming_project.Scene
{
    internal class Block : IBlock
    {
        //TODO: dodać event OnStepIn -> jakas akcja gdy sie najdzie na pole

        // klasa dla podstawowego pole (drzewo/ sciana / przeciwnik)

        public virtual string Id { get; } = "block";

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
        public virtual string Icon { get; set; }

        //czy da się wejść na pole?
        public virtual bool CanBeStepIn { get; set; } = true;

        public IBaseEntity BlockEntity { get => _entity; }
        private IBaseEntity _entity { get; set; }

        Random random = new Random();

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
          Icon = icon;
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
            Icon = icon;
        }
        public Block(int x,int y, string icon, IBaseEntity entity)
        {
            _x = x;
            _y = y;
            _entity = entity;
            Icon = icon;
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
        
            this._x = random.Next(16);
            this._y = random.Next(16);
        }
      
    }

}
