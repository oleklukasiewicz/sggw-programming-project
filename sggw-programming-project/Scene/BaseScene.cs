using sggw_programming_project.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace sggw_programming_project.Scene
{
    internal class BaseScene
    {
        //klasa dla pole (sceny) zawierająca bloki (drzewa / sciany / przeciwników)
        public int Id { get => _id; }
        private int _id { get; set; }

        public bool isSceneRunning = true;

        private int _width;
        private int _height;

        private int _score = 0;
        private int howFruitCandy = 0;
        // domyślny blok do wypełnienia sceny

        private Block _player;
        private Block _enemy;

        private List<SceneLayer> _sceneLayers = new List<SceneLayer>();

        // for enetity tracking
        private List<Block> _entities = new List<Block>();


        public BaseScene(int id, int width, int height, int howGrass, int howFruit, int howStone,
            int howTree, int howTrunk, int howCandy, int howHeart)
        {

            _id = id;
            _width = width;
            _height = height;

            _player = new PlayerBlock();
            _enemy = new EnemyBlock();
            howFruitCandy = howCandy + howFruit;
            _entities.Add(_player);
            do
            {
                _enemy.SetRandomLocation();
            } while (_player.X == _enemy.X && _player.Y == _enemy.Y);
            _entities.Add(_enemy);

            _sceneLayers.Add(new SceneLayer(width, height, new Block("\ud83d\udfea")));
            _sceneLayers[0].SetupScene(GenerateListBlock(howGrass, howFruit, howStone, howTree, howTrunk, howCandy, howHeart));

            _sceneLayers.Add(new SceneLayer(width, height));
            _sceneLayers[1].SetupScene(new List<Block>() { _enemy });

            _sceneLayers.Add(new SceneLayer(_width, _height));
            _sceneLayers[2].SetupScene(new List<Block>() { _player });

            _player.OnCoordsChange += UpdateTab;
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
          int howTree, int howTrunk, int howCandy, int howHeart)
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
            for (int i = 0; i < howCandy; i++)
            {
                Block bl = new CandyBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);
            }
            for (int i = 0; i < howHeart; i++)
            {
                Block bl = new HeartBlock();
                bl = IsRepeatDone(bl, list);
                list.Add(bl);
            }
            return list;
        }

        //metoda do wyświetlania sceny
        public void MenuControl()
        {
            Menu menu = new Menu(_player);
            menu.ChooseAvatar();
            Console.Clear();
        }
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
                if (i == 0) Console.Write("         Score: " + _score);
                if (i == 1) Console.Write("         Ilość do zdobycia: " + howFruitCandy);
                if (i == 2) Console.Write("         Player Health: " + _player.Health);
                if (i == 3) Console.Write("         Enemy Health: " + _enemy.Health);
                if (i == 4) Console.Write($"         Player X:{playerX}");
                if (i == 5) Console.Write($"         Player Y:{playerY}");
                Console.WriteLine();
            }
        }

        protected virtual void OnBlockStepIn(object sender)
        {
            Block block = (Block)sender;
            if (block.Id == "fruit")
            {

                _score += block.Point;
                howFruitCandy--;
                _sceneLayers[0].Scene[block.X, block.Y] = new Block(block.X, block.Y, "\ud83d\udfea");

            }

            if (block.Id == "candy")
            {

                _score += block.Point;
                howFruitCandy--;
                _sceneLayers[0].Scene[block.X, block.Y] = new Block(block.X, block.Y, "\ud83d\udfea");

            }

            if (block.Id == "enemy")
            {
                _player.Health -= 30;
            }

            if (block.Id == "heart")
            {
                _player.Health += 50;
                _sceneLayers[0].Scene[block.X, block.Y] = new Block(block.X, block.Y, "\ud83d\udfea");
            }


        }

        public void MoveBlock(SceneLayer targetScene, int x, int y, int targetX, int targetY)
        {
            if (targetX < _width && targetY < _height && targetX >= 0 && targetY >= 0)
            {
                Block target = _GetTopLayerBlock(targetX, targetY);
                Block source = _GetTopLayerBlock(x, y);
                if (target.CanBeStepIn)
                {
                    OnBlockStepIn(target);
                    source.StepOut();
                    target.StepIn();
                    targetScene.MoveBlockToCoords(x, y, targetX, targetY);
                }
            }
            isWin();
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

        public void AddEnemyControls()
        {   //Poruszanie się naszego wroga
            //Porusza się za kazdym razem gdy uzytkownik wciśnie klawisz, nie wiem jak to zrobić
            //aby poruszał się niezależnie :( help
            SceneLayer characterSceneLayer = _sceneLayers[1];
            for (; ; )
            {
                Random random = new Random();

                int number = random.Next(5);
                switch (number)
                {
                    case 0:
                        this.MoveBlockBy(characterSceneLayer, _enemy.X, _enemy.Y, -1, 0);
                        break;
                    case 1:
                        this.MoveBlockBy(characterSceneLayer, _enemy.X, _enemy.Y, 1, 0);

                        break;
                    case 2:
                        this.MoveBlockBy(characterSceneLayer, _enemy.X, _enemy.Y, 0, 1);

                        break;
                    case 3:
                        this.MoveBlockBy(characterSceneLayer, _enemy.X, _enemy.Y, 0, -1);

                        break;
                    default:
                        break;
                }
                if (!isSceneRunning)
                    break;
                Thread.Sleep(500);
            }
        }

        public void isWin()
        {
            //Metoda sprawdzająca czy użytkownik Wygrał czy Przegrał
            if (howFruitCandy > 0 && _player.Health > 0)
            {
                // przerenderownie
                this.Render();
            }
            else if (_player.Health <= 0)
            {
                Console.Clear();
                Console.WriteLine("Straciłeś życie! Przegrałeś!");
                isSceneRunning = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wygrałeś! Udało Ci się zdobyć {0} Punktów!", _score);
                isSceneRunning = false;
            }
        }

        ///UWAGA: TESTOWE METODY I POLA
        ///
        int playerX = 0;
        int playerY = 0;
        int playerHealth = 100;
        private void UpdateTab(object sender, CoordsChangeEventArgs e)
        {
            playerX = e.X;
            playerY = e.Y;
        }
        private void UpdatePlayerHealth()
        {

        }
    }
}
