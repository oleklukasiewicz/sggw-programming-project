using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Scene
{
    internal class BaseScene
    {
        //klasa dla pole (sceny) zawierająca bloki (drzewa / sciany / przeciwników)
        public int Id { get => _id; }
        private int _id { get; set; }

        // domyślny blok do wypełnienia sceny
        private Block _defaultBlock;

        private int _width;
        private int _height;

        private List<List<Block>> _sceneblocks;

        public BaseScene(int id, int width, int height, Block defaultBlock, List<Block> blocksToInsert)
        {
            //zapełnianie sceny domyślnymi blokami
            _id = id;
            _width = width;
            _height = height;
            _defaultBlock = defaultBlock;

            _sceneblocks = new List<List<Block>>();
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    _sceneblocks[i][j] = _defaultBlock;
                }
            }

            //zapełnianie sceny blokamiw (drzewa itp.)
            foreach (var block in blocksToInsert)
            {
                if (block.X <= _width && block.Y <= _height)
                    _sceneblocks[block.Y][block.X] = block;
            }
        }
    
        //metoda do wyświetlania sceny
        public void Render()
        {

        }
    }
}
