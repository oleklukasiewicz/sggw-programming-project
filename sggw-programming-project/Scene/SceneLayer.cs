using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Scene
{
    internal class SceneLayer
    {
        public Block DefaultBlock { get; set; }
        public Block[,] Scene;

        private int _width;
        private int _height;    
        public SceneLayer(int width, int height)
        {
            Scene = new Block[width, height];
            _width = width;
            _height = height;
        }
        public SceneLayer(int width, int height, Block dfaultBlock)
        {
            Scene = new Block[width, height];
            _width = width;
            _height = height;

            DefaultBlock = dfaultBlock;
        }
        public void SetupScene(List<Block> blocks)
        {
            if (DefaultBlock != null)
            {
                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                        Scene[i, j] = DefaultBlock;
                }
            }

            //Zapełnienie sceny blokami typu drzewa itp.
            foreach (var block in blocks)
            {
                if (block.X < _width && block.Y < _height)
                    Scene[block.X, block.Y] = block;
            }
        }

        public Block MoveBlockToCoords(int x, int y, int targetX, int targetY)
        {
            Scene[targetX, targetY] = Scene[x, y];
            Scene[targetX,targetY].SetCoords(targetX, targetY);

            Scene[x, y] = DefaultBlock;

            return Scene[targetX, targetY];
        }
    }
}
