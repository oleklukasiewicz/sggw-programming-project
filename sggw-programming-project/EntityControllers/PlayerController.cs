using sggw_programming_project.Entity;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.EntityControllers
{
    internal class PlayerController : BaseEntityController
    {
        public PlayerController(BaseScene scene, SceneLayer layer, Block block):base (scene, layer, block)
        {
          
        }
        public override void ControlEntity()
        {
            Task.Run(() => Start());
        }
        private void Start()
        {
            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey();
                int x = 0, y = 0;
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        x = -1; y = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        x = 1; y = 0;

                        break;
                    case ConsoleKey.RightArrow:
                        x = 0; y = 1;

                        break;
                    case ConsoleKey.LeftArrow:
                        x = 0; y = -1;
                        break;
                    case ConsoleKey.Escape:
                        base.CancelEntityControl();
                        break;
                    default:
                        break;
                }

                _scene.MoveBlockBy(_sceneLayer, _targetBlock.X, _targetBlock.Y, x, y);

            } while (isControlActive);
        }
        
    }
}
