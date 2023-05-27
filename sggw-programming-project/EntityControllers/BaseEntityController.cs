using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.EntityControllers
{
    internal class BaseEntityController
    {
        //klasa dla kontolera moba(entity) - klasa bedzie sterowała ruchem oraz zachowaniem

        private IBaseEntity _targetEntity;
        private IBlock _targetBlock;

        private int _maxX;
        private int _maxY;
        public BaseEntityController(ref IBlock block, int maxX = 0, int maxY = 0)
        {
            _targetBlock = block;
            _targetEntity = block.BlockEntity;
        }
        public IBlock MoveTo(int x, int y)
        {
            //
            return _targetBlock;
        }
    }
}
