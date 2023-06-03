using sggw_programming_project.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace sggw_programming_project.Scene
{
    internal class BaseScene
    {
        //klasa dla pole (sceny) zawierająca bloki (drzewa / sciany / przeciwników)
        public int Id { get => _id; }
        private int _id { get; set; }

        private int _width;
        private int _height;

        //punkty

        // domyślny blok do wypełnienia sceny

        private Block _player;
        private Block _enemy;

        private List<SceneLayer> _sceneLayers = new List<SceneLayer>();

        // for enetity tracking
        private List<Block> _entities = new List<Block>();


        public BaseScene(int id, int width, int height, int howGrass, int howFruit, int howStone,
            int howTree, int howTrunk)
        {

            _id = id;
            _width = width;
            _height = height;

            _player = new PlayerBlock();
            _enemy = new EnemyBlock();

            _entities.Add(_player);
            _entities.Add(_enemy);

            _sceneLayers.Add(new SceneLayer(width, height, new Block("\ud83d\udfea")));
            _sceneLayers[0].SetupScene(GenerateListBlock(howGrass, howFruit, howStone, howTree, howTrunk));

            _sceneLayers.Add(new SceneLayer(width, height));
            _sceneLayers[1].SetupScene(new List<Block>() { _enemy });

            _sceneLayers.Add(new SceneLayer(_width, _height));
            _sceneLayers[2].SetupScene(new List<Block>() { _player });
        }
        private Block _GetTopLayerBlock(int x, int y)
        {
            for (int l = _sceneLayers.Count - 1; l >= 0; l--)
            {
                if (_sceneLayers[l].Scene[x, y] != null)
                {
                    return _sceneLayers[l].Scene[x, y];
                }
            }
            return null;
        }
        private Block IsRepeatDone(Block block, List<Block> list)
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
        //TODO: do przerobienia system losowego wsadzania bloków -> na jakiś bardziej optymalny
        private List<Block> GenerateListBlock(int howGrass, int howFruit, int howStone,
          int howTree, int howTrunk)
        {
            //tworzenie listy elementów które mają się pojawić na planszy z losowym rozmieszczeniem.
            List<Block> list = new List<Block>();

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

        //metoda do wyświetlania sceny
        public void Render()
        {
            Console.Clear();
            //Wydrukowanie sceny na ekranie
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Block target = new Block();

                    target = _GetTopLayerBlock(i, j);

                    string icon = target.Icon;
                    Console.Write(icon);
                }
                if (i == 0) Console.Write("         Score: 99");
                if (i == 1) Console.Write("         Player Health: 20");
                if (i == 2) Console.Write("         Enemy Health: 0");
                Console.WriteLine();
            }
        }
        public void MoveBlock(SceneLayer targetScene, int x, int y, int targetX, int targetY)
        {
            if (targetX < _width && targetY < _height && targetX >= 0 && targetY >= 0)
            {
                Block target = _GetTopLayerBlock(targetX, targetY);
                if (target.CanBeStepIn)
                {
                    target.StepIn();

                    targetScene.MoveBlockToCoords(x, y, targetX, targetY);
                }
            }
            // przerenderownie
            this.Render();
        }
        public void MoveBlockBy(SceneLayer targetScene, int x, int y, int targetX, int targetY)
        {
            MoveBlock(targetScene, x, y, x + targetX, y + targetY);
        }
        public void AddCharacterControls()
        {
            //na razie na sztywno ale póżniej to zmienie (prawda?)
            SceneLayer characterSceneLayer = _sceneLayers[2];

            ConsoleKeyInfo pressedKey;
            do
            {
                pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        this.MoveBlockBy(characterSceneLayer, _player.X, _player.Y, -1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        this.MoveBlockBy(characterSceneLayer, _player.X, _player.Y, 1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        this.MoveBlockBy(characterSceneLayer, _player.X, _player.Y, 0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        this.MoveBlockBy(characterSceneLayer, _player.X, _player.Y, 0, -1);
                        break;
                    default:
                        break;
                }

            } while (pressedKey.Key != ConsoleKey.Escape);

        }
    }
}
