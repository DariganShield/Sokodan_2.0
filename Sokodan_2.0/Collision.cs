using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2._0
{
    class Collision
    {
        public void CollisionBoundaries(int[,] map, Sprite sprite, int x, int y)
        {
            map[x, y] = sprite.spriteID;
        }
        public void CollisionClear(int[,] map, int x, int y)
        {
            map[x, y] = 0;
        }

        public List<Point> ElementList(int[,] map, Sprite sprite, int MapWidth, int MapHeight)
        {
            List<Point> elements = new List<Point>();
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    if (map[i,j] == sprite.spriteID) elements.Add(new Point (i,j));
                }
            }

            return elements;
        }
    }
}
