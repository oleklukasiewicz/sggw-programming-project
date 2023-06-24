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
        protected BaseScene _scene;
        protected SceneLayer _sceneLayer;
        protected Block _targetBlock;
        protected bool isControlActive = true;
        public BaseEntityController(BaseScene scene, SceneLayer layer, Block block)
        {
            _scene = scene;
            _sceneLayer = layer;
            _targetBlock = block;
        }
        public virtual void ControlEntity()
        {
            Console.WriteLine("Control");
        }
        public virtual void CancelEntityControl()
        {
            isControlActive = false;
        }
    }
}
