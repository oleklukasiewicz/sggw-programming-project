using sggw_programming_project.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using sggw_programming_project.Helpers;
using sggw_programming_project.EntityControllers;
using sggw_programming_project.Entity;

namespace sggw_programming_project.Scene
{

    delegate void SceneStopHandler (object sender, EventArgs e);
    internal class BaseScene
    {
        private const int FPS = 30;

        private const int frameTimer = 1000 / FPS;

        private bool isSceneRunning = true;

        private int _width;
        private int _height;

        public event SceneStopHandler OnSceneStop;

        public PlayerBlock Player;
        public EnemyBlock Enemy;

        public List<SceneLayer> SceneLayers = new List<SceneLayer>();

        private Block _defaultBlock = new Block()
        {
            Icon = "\ud83d\udfea",
        };

        private Random rand = new Random();
        public BaseScene(int width, int height, Dictionary<string, int> config)
        {
            _width = width;
            _height = height;

            Player = new PlayerBlock();
            Enemy = new EnemyBlock();

            do
            {
                Enemy.SetCoords(rand.Next(_width),rand.Next(_height));
            } while (Player.X == Enemy.X && Player.Y == Enemy.Y);          

            //block layer
            SceneLayers.Add(new SceneLayer(width, height, (Block)_defaultBlock));
            SceneLayers[0].SetupScene(SceneHelpers.GenerateListBlock(_width, _height, config));

            //player layer
            SceneLayers.Add(new SceneLayer(width, height));
            SceneLayers[1].SetupScene(new List<Block>() { Enemy });

            //enemy layer
            SceneLayers.Add(new SceneLayer(_width, _height));
            SceneLayers[2].SetupScene(new List<Block>() { Player });

            SceneLayers[0].OnLayerUpdate += LayerUpdate;
            SceneLayers[1].OnLayerUpdate += LayerUpdate;
            SceneLayers[2].OnLayerUpdate += LayerUpdate;

            this.Player.BlockEntity.OnDie += PlayerDied;
            this.Enemy.BlockEntity.OnDie += EnemyDied;

            Prepare();
        }
        private Block _GetTopLayerBlock(int x, int y)
        {
            for (int l = SceneLayers.Count - 1; l >= 0; l--)
            {
                if (SceneLayers[l].Scene[x, y] != null)
                {
                    return SceneLayers[l].Scene[x, y];
                }
            }
            return null;
        }
        public void MenuControl()
        {
            Menu menu = new Menu(Player);
            menu.ChooseAvatar();
            Console.Clear();
        }
        private void LayerUpdate(object sender,EventArgs e)
        {
           
        }
        public void Render()
        {
            Console.Clear();
            //Wydrukowanie sceny na ekranie
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Block target = _GetTopLayerBlock(i, j);

                    string icon = target.Icon;
                    Console.Write(icon);
                }
                string ekwipunek = "brak";
                if (Player.BlockEntity.DamageUpdated == true)
                { ekwipunek = "\ud83d\udd2a"; }

                if (i == 0) Console.Write($"         FPS[{FPS}]");
                if (i == 2) Console.Write("         Equipment: " + ekwipunek);
                if (i == 3) Console.Write("         Player Health: " + Player.BlockEntity.Health);
                if (i == 4) Console.Write("         Enemy Health: " + Enemy.BlockEntity.Health);
                if (i == 5) Console.Write($"         Player X:{Player.X}");
                if (i == 6) Console.Write($"         Player Y:{Player.Y}");
                Console.WriteLine();
            }
        }

        private void OnBlockStepIn(object sender,StepInEventArgs args)
        {
           Block senderBlock = sender as Block;

            if (senderBlock != null)
            {
                if(senderBlock.BlockEntity != null)
                {
                    BaseEntity blockEntity = senderBlock.BlockEntity;
                    BaseEntity stepperEntity = args.stepper.BlockEntity;
                    if (blockEntity != null)
                    {
                        //uzdrawianie
                        if(blockEntity.Healing!=0)
                        {
                            stepperEntity.Heal(blockEntity.Healing);
                        }
                        if(blockEntity.Damage!=0)
                        {
                            blockEntity.TakeDamage(stepperEntity.Damage);
                        }
                        if(blockEntity.UpdateDamage!=0)
                        {
                            stepperEntity.UpgradeDamage(blockEntity.UpdateDamage);
                        }
                    }
                }
            }

        }

        public void MoveBlock(SceneLayer targetScene, int x, int y, int targetX, int targetY)
        {
            if (x == targetX && y == targetY)
                return;

            if (targetX < _width && targetY < _height && targetX >= 0 && targetY >= 0)
            {
                Block target = _GetTopLayerBlock(targetX, targetY);
                Block source = _GetTopLayerBlock(x, y);
                if (target.CanBeStepIn)
                {
                    source.StepOut(source);
                    target.StepIn(source);
                    targetScene.MoveBlockToCoords(x, y, targetX, targetY);
                }
            }
        }
        public void MoveBlockBy(SceneLayer targetScene, int x, int y, int targetX, int targetY)
        {
            MoveBlock(targetScene, x, y, x + targetX, y + targetY);
        }
        private void Prepare()
        {
            for(int i = 0;i<SceneLayers.Count;i++) {
                SceneLayer layer = SceneLayers[i];
                if (layer != null)
                {
                    Block[,] scene = layer.Scene;
                    if (scene != null)
                    {
                        for(int j=0;j<_width;j++)
                        {
                            for(int k = 0; k < _height;k++)
                            {
                                if(scene[j,k] != null )
                                scene[j, k].OnStepIn += OnBlockStepIn;
                            }
                        }
                    }
                }
            
            }
        }
        private void StopScene()
        {
            isSceneRunning = false;
            OnSceneStop?.Invoke(this,new EventArgs());
        }

        public void PlayerDied(object sender, EventArgs e)
        {
            StopScene();
            Console.Clear();
            Console.WriteLine("Straciłeś życie! Przegrałeś!");
        }

        public void EnemyDied(object sender, EventArgs e)
        {
            StopScene();
            Console.Clear();
            Console.WriteLine("Wygrałeś! Udało Ci się!");
        }

        public void StartEngine()
        {
            do
            {
                if (isSceneRunning)
                    this.Render();
                Thread.Sleep(frameTimer);
            } while (isSceneRunning);
        }
    }
}
