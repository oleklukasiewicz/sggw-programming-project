using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Scene
{
    delegate void LayerUpdateHandler (object sender, EventArgs e);

    internal class SceneLayer
    {
        public Block DefaultBlock { get; set; }
        public Block[,] Scene;

        public event LayerUpdateHandler OnLayerUpdate;

        private int _width;
        private int _height;
        public SceneLayer(int width, int height)
        {
            Scene = new Block[width, height];
            _width = width;
            _height = height;
        }
        public SceneLayer(int width, int height, Block defaultBlock)
        {
            Scene = new Block[width, height];
            _width = width;
            _height = height;

            DefaultBlock = defaultBlock;
        }
        public void SetupScene(List<Block> blocks)
        {
            if (DefaultBlock != null)
            {
                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        Block def = DefaultBlock.Clone();
                        def.SetCoords(i, j);
                        Scene[i, j] = def;
                    }
                }
            }

            //Zapełnienie sceny blokami typu drzewa itp.
            foreach (var block in blocks)
            {
                if (block.X < _width && block.Y < _height)
                    Scene[block.X, block.Y] = block;
            }

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if(Scene[i, j]!=null)
                    Scene[i, j].OnEntityRemove += RemoveBlock;
                }
            }
        }

        public Block MoveBlockToCoords(int x, int y, int targetX, int targetY)
        {
            if (Scene[x, y] == null)
                return Scene[targetX, targetY];

            Scene[targetX, targetY] = Scene[x, y];
            Scene[targetX, targetY].SetCoords(targetX, targetY);

            Scene[x, y] = DefaultBlock;

            OnLayerUpdate?.Invoke(this, new EventArgs());

            return Scene[targetX, targetY];
        }

        private void RemoveBlock (object sender, EventArgs e)
        {
            Block senderBlock = sender as Block;

            if (DefaultBlock == null)
                Scene[senderBlock.X, senderBlock.Y] = null;
            else
                Scene[senderBlock.X, senderBlock.Y]= DefaultBlock.Clone();

            OnLayerUpdate?.Invoke(this, new EventArgs());
        }
    }
}
