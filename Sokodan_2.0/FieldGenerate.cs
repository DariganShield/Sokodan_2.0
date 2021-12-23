using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban_2._0
{
    class FieldGenerate
    {
        public void BoxPlaceGenerate(GameObject gameObject,int MapWidth, int MapHeight, int[,] map)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    gameObject.x = MapWidth - (2 + i) * gameObject.sprite.srcx - 1;
                    gameObject.y = MapHeight - (1 + j) * gameObject.sprite.srcy - 1;
                    if (map[gameObject.x, gameObject.y] == 0)
                        gameObject.collision.CollisionBoundaries(map, gameObject.sprite, gameObject.x, gameObject.y);
                }
            }
        }
    }
}
