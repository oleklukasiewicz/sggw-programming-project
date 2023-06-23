using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sggw_programming_project.EntityControllers
{
    internal class EnemyController : BaseEntityController
    {
        public EnemyController(BaseScene scene, SceneLayer layer, Block block) : base(scene, layer, block)
        {
        }
        public override void ControlEntity()
        {
            Task.Run(() => this.Start());
        }
        private void Start()
        {
            Random random = new Random();
            for (; ; )
            {


                int number = random.Next(4);
                int x = 0, y = 0;
                switch (number)
                {
                    case 0:
                        x = -1; y = 0;
                        break;
                    case 1:
                        x = 1; y = 0;

                        break;
                    case 2:
                        x = 0; y = 1;

                        break;
                    case 3:
                        x = 0; y = -1;
                        break;
                    default:
                        break;
                }

                _scene.MoveBlockBy(_sceneLayer, _targetBlock.X, _targetBlock.Y, x, y);

                Thread.Sleep(500);

                if (!isControlActive)
                    return;
            }
        }
    }
}
