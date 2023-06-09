﻿using sggw_programming_project.Blocks;
using sggw_programming_project.Entity;
using sggw_programming_project.EntityControllers;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project
{
    internal class Program
    {
        static EnemyController enemyController;
        static PlayerController playerController;
        static void Main(string[] args)
        {
            Console.WriteLine("Witaj w naszej grze!");
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            BaseScene scene1 = new BaseScene(10, 10, new Dictionary<string, int>()
            {
                {"grass",15 },
                {"fruit",3 },
                {"stone",8 },
                {"tree",7 },
                {"trunk",7 },
                {"candy",2 },
                {"heart",1 },
                {"gun",2 }
            });
            scene1.OnSceneStop += StopControllers;

            Menu menu = new Menu(scene1.Player);
            menu.ChooseAvatar();
            Console.Clear();

            enemyController = new EnemyController(scene1, scene1.SceneLayers[1], scene1.Enemy);
            playerController = new PlayerController(scene1, scene1.SceneLayers[2], scene1.Player);

            enemyController.ControlEntity();
            playerController.ControlEntity();

            scene1.StartEngine();

            Console.ReadKey();
        }

        static void StopControllers(object sender, EventArgs e)
        {
            enemyController.CancelEntityControl();
            playerController.CancelEntityControl();
        }
    }

}
