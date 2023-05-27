using System;
using System.Collections.Generic;

namespace sggw_programming_project.Scene
{
    internal class BaseScene
    {
        //klasa dla pole (sceny) zawierająca bloki (drzewa / sciany / przeciwników)
        public int Id { get => _id; }
        private int _id { get; set; }

        private int _width;
        private int _height;

        // domyślny blok do wypełnienia sceny
        private Block _defaultBlock;
        private Block[,] _sceneblockstab;
        private List<Block> _blocksToInsert;

        public BaseScene(int id, int width, int height, Block defaultBlock, List<Block> blocksToInsert)
        {
            //zapełnianie sceny domyślnymi blokami
            _id = id;
            _width = width;
            _height = height;
            _defaultBlock = defaultBlock;
          
            _sceneblockstab = new Block[width, height];
            _blocksToInsert = blocksToInsert;

        }

        //metoda do wyświetlania sceny
        public void Render()
        {
            //zapełnianie sceny blokamiw (drzewa itp.)
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                    _sceneblockstab[i, j] = _defaultBlock;
            }

            foreach (var block in _blocksToInsert)
            {
                if (block.X < _width && block.Y < _height)
                    _sceneblockstab[block.X, block.Y] = block;
            }

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    string icon = _sceneblockstab[i, j].Icon;
                    Console.Write(icon);
                }
                Console.WriteLine();
            }

        }

        public void MoveBlock(int x, int y, int targetX, int targetY)
        {
            if (!_sceneblockstab[targetX, targetY].CanBeStepIn)
                return;

            if (targetX < _width && targetY < _height)
                _sceneblockstab[x, y].SetCoords(targetX, targetY);
            // przerenderownie
            this.Render();
        }
        public void MoveBlockBy(int x,int y,int targetX, int targetY)
        {
            MoveBlock(x,y,x + targetX, y + targetY);
        }

    }
}
