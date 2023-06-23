using sggw_programming_project.Entity;
using System;

namespace sggw_programming_project.Scene
{
    delegate void StepInHandler(object sender, StepInEventArgs e);
    delegate void StepOutHandler(object sender, StepOutEventArgs e);
    delegate void CoordsChangeHandler(object sender, CoordsChangeEventArgs e);
    delegate void EntityRemoveHandler(object sender, EventArgs e);
    internal class Block
    {
        
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

        public virtual BaseEntity BlockEntity { get => _entity; }
        private BaseEntity _entity { get; set; }

        public event StepInHandler OnStepIn;
        public event StepOutHandler OnStepOut;
        public event CoordsChangeHandler OnCoordsChange;
        public event EntityRemoveHandler OnEntityRemove;
        public virtual string Id { get; } = "block";
        public virtual string Icon { get; set; }
        public virtual bool CanBeStepIn { get; set; } = true;

        public Block(int x, int y, BaseEntity entity)
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
        public Block(int x, int y, string icon, BaseEntity entity)
        {
            _x = x;
            _y = y;
            _entity = entity;
            Icon = icon;
        }
        //onStepIn
        protected virtual void _StepIn(Block stepper)
        {
            if (_entity != null)
            {
                if (this.BlockEntity.IsItem)
                {
                    OnEntityRemove?.Invoke(this, new EventArgs());
                }
            }
            StepInEventArgs _args = new StepInEventArgs(_x, _y,stepper);
            OnStepIn?.Invoke(this, _args);
        }
        protected virtual void _CoordsChange(int oldX, int oldY)
        {
            CoordsChangeEventArgs _args = new CoordsChangeEventArgs(_x, _y, oldX, oldY);
            OnCoordsChange?.Invoke(this, _args);
        }
        protected virtual void _StepOut(Block stepper)
        {
            StepOutEventArgs _args = new StepOutEventArgs(_x, _y,stepper);
            OnStepOut?.Invoke(this, _args);
        }
        public void StepIn(Block stepper)
        {
            _StepIn(stepper);
        }
        public void StepOut(Block stepper)
        {
            _StepOut(stepper);
        }
        public void SetCoords(int x, int y)
        {
            int oldX = _x;
            int oldY = _y;

            _x = x;
            _y = y;

            _CoordsChange(oldX, oldY);
        }

        public override string ToString()
        {
            return this.Id + " "+this.X+" "+this.Y;
        }
        public Block Clone()
        {
            Block clone = new Block(_x, _y, Icon, _entity);

            return clone;
        }
    }
    class StepInEventArgs : EventArgs
    {
        public int X;
        public int Y;
        public Block stepper;
        public StepInEventArgs(int x, int y, Block stepper)
        {
            X = x;
            Y = y;
            this.stepper = stepper;
        }
    }
    class StepOutEventArgs : EventArgs
    {
        public int X;
        public int Y;
        public Block stepper;
        public StepOutEventArgs(int x, int y, Block stepper)
        {
            X = x;
            Y = y;
            this.stepper = stepper;
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