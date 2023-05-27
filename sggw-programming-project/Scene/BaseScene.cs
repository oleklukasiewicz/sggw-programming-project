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

        public BaseScene(int id, int width, int height, Block defaultBlock, List<Block> blocksToInsert)
        {
            //zapełnianie sceny domyślnymi blokami
            _id = id;
            _width = width;
            _height = height;
            _defaultBlock = defaultBlock;

            _sceneblockstab = new Block[width,height];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                    _sceneblockstab[i,j] = _defaultBlock;
            }

            //zapełnianie sceny blokamiw (drzewa itp.)
            foreach (var block in blocksToInsert)
            {
                if (block.X <= _width && block.Y <= _height)
                    _sceneblockstab[block.X,block.Y] = block;
            }
        }
    
        //metoda do wyświetlania sceny
        public void Render()
        {
            for(int i = 0; i < _height; i++)
            {
                for(int j = 0; j < _width; j++)
                {
                    string icon = _sceneblockstab[i,j].Icon;
                    Console.Write(icon);
                }
                Console.WriteLine();
            }

        }

    }
}
