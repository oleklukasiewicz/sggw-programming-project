using sggw_programming_project.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private Block _player;
        private Block _enemy;
        private Block[,] _sceneblockstab;
        private List<Block> _entities = new List<Block>();
        private List<Block> _blocksToInsert;

        public BaseScene(int id, int width, int height, int howGrass, int howFruit, int howStone,
            int howTree, int howTrunk)
        {

            _id = id;
            _width = width;
            _height = height;
            _defaultBlock = new Block("\ud83d\udfea");
            _sceneblockstab = new Block[width, height];
            _player = new PlayerBlock();
            _enemy = new EnemyBlock();
            _entities.Add(_player);
            _entities.Add(_enemy);
            _blocksToInsert = GenerateListBlock(howGrass, howFruit, howStone, howTree, howTrunk);


        }

        //metoda do wyświetlania sceny
        public void Render()
        {
            //Zapełnienie sceny domyślnymi blokami

            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                    _sceneblockstab[i, j] = _defaultBlock;
            }

            //Zapełnienie sceny blokami typu drzewa itp.
            foreach (var block in _blocksToInsert)
            {
                if (block.X < _width && block.Y < _height)
                    _sceneblockstab[block.X, block.Y] = block;
            }
       
            //zapełnianie mobami
            for (int i = 0; i < _entities.Count; i++)
            {
                var entity = _entities[i];
                _sceneblockstab[entity.X, entity.Y] = entity;
            }
            Console.Clear();
            //Wydrukowanie sceny na ekranie
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    string icon = _sceneblockstab[i, j].Icon;
                    Console.Write(icon);
                }
                if (i == 0) Console.Write("         Score: 99");
                if (i == 1) Console.Write("         Player Health: 20");
                if (i == 2) Console.Write("         Enemy Health: 0");
                Console.WriteLine();
            }
        }

        public void MoveBlock(int x, int y, int targetX, int targetY)
        {
            if (targetX < _width && targetY < _height && targetX >= 0 && targetY >= 0)
            {
                if (_sceneblockstab[targetX, targetY].CanBeStepIn)
                    _sceneblockstab[x, y].SetCoords(targetX, targetY);
            }
            // przerenderownie
            this.Render();
        }
        public void MoveBlockBy(int x, int y, int targetX, int targetY)
        {
            MoveBlock(x, y, x + targetX, y + targetY);
        }

        public void AddCharacterControls()
        {
            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        this.MoveBlockBy(_player.X, _player.Y, -1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        this.MoveBlockBy(_player.X, _player.Y, 1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        this.MoveBlockBy(_player.X, _player.Y, 0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        this.MoveBlockBy(_player.X, _player.Y, 0, -1);
                        break;
                    default:
                        break;
                }

            } while (pressedKey.Key != ConsoleKey.Escape);

        }
        private List<Block> GenerateListBlock(int howGrass, int howFruit, int howStone,
            int howTree, int howTrunk)
        {
            //tworzenie listy elementów które mają się pojawić na planszy z losowym rozmieszczeniem.
            List<Block> list = new List<Block>();
            list.Add(_player);
            _enemy.SetRandomLocation();
            list.Add(_enemy); //tu trzeba jeszcze poprawic, zeby koordynaty playera i enemy sie nie pokrywały.
            //zrobilabym to w konstruktorze EnemyBlock ale nie wiem jak odwołać się do koordynatów playera.
            for (int i = 0; i < howGrass; i++)
            {
                Block bl = new GrassBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);

            }
            for (int i = 0; i < howFruit; i++)
            {
                Block bl = new FruitBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);

            }
            for (int i = 0; i < howStone; i++)
            {
                Block bl = new StoneBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);
            }
            for (int i = 0; i < howTree; i++)
            {
                Block bl = new TreeBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);

            }
            for (int i = 0; i < howTrunk; i++)
            {
                Block bl = new TrunkBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);
            }
            return list;
        }

        public Block IsRepeatDone(Block block, List<Block> list)
        {

            bool isDone = false;
            bool isRepeat = false;

            while (!isDone)
            {
                block.SetRandomLocation();

                foreach (var item in list)
                {
                    if (item.X == block.X && item.Y == block.Y)
                    {
                        isRepeat = true;
                        break;
                    }
                    else
                    {
                        isRepeat = false;
                    }
                }

                if (isRepeat == false) isDone = true;
            }
            return block;

        }

    }
}
