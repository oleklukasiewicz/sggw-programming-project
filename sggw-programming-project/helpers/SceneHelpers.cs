using sggw_programming_project.Blocks;
using sggw_programming_project.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sggw_programming_project.Helpers
{
    static class SceneHelpers
    {
        private static bool AreCoordsAccupied(List<Block> blocks, int x, int y)
        {
            foreach (var b in blocks)
            {
                if (b.X == x && b.Y == y)              
                        return true;
            }
            return false;
        }
        private static Block SetRandomCoordsForBlock(List<Block> list, int width, int height, Block block)
        {
            if (list.Count >= (width * height))
                return null;

            Random random = new Random();
            int limit = (width * height);
            do
            {
                block.SetCoords(random.Next(width), random.Next(height));
                limit--;
            }
            while (AreCoordsAccupied(list, block.X, block.Y) && limit > 0);

            if (limit == 0)
                return null;

            return block;
        }
        public static List<Block> GenerateListBlock(int width, int height, Dictionary<string, int> blocks)
        {
            //tworzenie listy elementów które mają się pojawić na planszy z losowym rozmieszczeniem.
            List<Block> list = new List<Block>();

            if (blocks.ContainsKey("grass"))
                for (int i = 0; i < blocks["grass"]; i++)
                {
                    Block bl = new GrassBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }
            if (blocks.ContainsKey("fruit"))
                for (int i = 0; i < blocks["fruit"]; i++)
                {
                    Block bl = new FruitBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }
            if (blocks.ContainsKey("stone"))
                for (int i = 0; i < blocks["stone"]; i++)
                {
                    Block bl = new StoneBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }
            if (blocks.ContainsKey("tree"))
                for (int i = 0; i < blocks["tree"]; i++)
                {
                    Block bl = new TreeBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }

            if (blocks["trunk"] != null)
                for (int i = 0; i < blocks["trunk"]; i++)
                {
                    Block bl = new TrunkBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }

            if (blocks.ContainsKey("candy"))
                for (int i = 0; i < blocks["candy"]; i++)
                {
                    Block bl = new CandyBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }
            if (blocks["heart"] != null)
                for (int i = 0; i < blocks["heart"]; i++)
                {
                    Block bl = new HeartBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }

            if (blocks["gun"] != null)
                for (int i = 0; i < blocks["gun"]; i++)
                {
                    Block bl = new GunBlock();

                    Block block = SetRandomCoordsForBlock(list, width, height, bl);

                    if (block != null)
                        list.Add(bl);

                }

            //list.ForEach(bl => { Console.WriteLine(bl.X + " " + bl.Y +" "+bl.Id); });
            return list;
        }


    }
}
