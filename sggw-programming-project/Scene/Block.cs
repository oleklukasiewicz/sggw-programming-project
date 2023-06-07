using sggw_programming_project.Entity;
using System;

namespace sggw_programming_project.Scene
{
    delegate void StepInHandler(object sender, StepInEventArgs e);
    delegate void StepOutHandler(object sender, StepOutEventArgs e);
    delegate void CoordsChangeHandler(object sender, CoordsChangeEventArgs e);
    delegate void BlockStepInHandler();
    internal class Block : IBlock
    {
        Random random = new Random();
        public virtual int Health { get; set; }
        
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

        public IBaseEntity BlockEntity { get => _entity; }
        private IBaseEntity _entity { get; set; }

        public event StepInHandler OnStepIn;
        public event StepOutHandler OnStepOut;
        public event CoordsChangeHandler OnCoordsChange;
        public event BlockStepInHandler BlockStepIn;
        public virtual string Id { get; } = "block";
        public virtual string Icon { get; set; }
        public virtual bool CanBeStepIn { get; set; } = true;

        public virtual int Point { get; set; }

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
        public Block(int x, int y, string icon, IBaseEntity entity)
        {
            _x = x;
            _y = y;
            _entity = entity;
            Icon = icon;
        }
        //onStepIn
        protected virtual void _StepIn()
        {
            StepInEventArgs _args = new StepInEventArgs(_x, _y);
            OnStepIn?.Invoke(this, _args);
        }
        protected virtual void _CoordsChange(int oldX, int oldY)
        {
            CoordsChangeEventArgs _args = new CoordsChangeEventArgs(_x, _y, oldX, oldY);
            OnCoordsChange?.Invoke(this, _args);
        }
        protected virtual void _StepOut()
        {
            StepOutEventArgs _args = new StepOutEventArgs(_x, _y);
            OnStepOut?.Invoke(this, _args);
        }
        protected virtual void _BlockStepIn()
        {

        }
        public void StepIn()
        {
            _StepIn();
        }
        public void StepOut()
        {
            _StepOut();
        }
        public void SetCoords(int x, int y)
        {
            int oldX = _x;
            int oldY = _y;

            _x = x;
            _y = y;
            
            _CoordsChange(oldX, oldY);
            
        }
        public void SetRandomLocation()
        {

            this._x = random.Next(16);
            this._y = random.Next(16);
        }
    }
    class StepInEventArgs : EventArgs
    {
        public int X;
        public int Y;
        public StepInEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class StepOutEventArgs : EventArgs
    {
        public int X;
        public int Y;
        public StepOutEventArgs(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    class CoordsChangeEventArgs : EventArgs
    {
        public int X;
        public int Y;
        public int OldX;
        public int OldY;
        public CoordsChangeEventArgs(int x, int y, int oldX, int oldY)
        {
            X = x;
            Y = y;
            OldX = oldX;
            OldY = oldY;
        }
    }

    class BlockStepInEventHandler : EventArgs
    {

    }
}