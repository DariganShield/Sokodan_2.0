using System.Windows.Forms;

namespace Sokoban_2._0
{
    class Colliding
    {
        public int dirX;
        public int dirY;
        public bool IsCollide(GameObject gameObject1, GameObject gameObject2, int[,] map, int MapWidth, int MapHeight)
        {
            var ElementList = gameObject2.collision.ElementList(map, gameObject2.sprite, MapWidth, MapHeight);
            bool isColliding = false;
            gameObject1.collision.CollisionClear(map, gameObject1.x, gameObject1.y);
            foreach (var element in ElementList)
            {
                switch (gameObject1.orient)
                {
                    case Keys.Right:
                        if (map[element.X + gameObject2.sprite.srcx, element.Y] <= 1 &&
                            gameObject1.x + gameObject1.sprite.srcx == element.X &&
                            gameObject1.y == element.Y)
                        {
                            if (dirX < 0) dirX *= -1;
                            isColliding = true;
                            gameObject1.orient = 0;
                            gameObject2.x = element.X;
                            gameObject2.y = element.Y;
                        }
                        else gameObject2.orient = gameObject1.orient;
                        break;
                    case Keys.Left:
                        if (map[element.X - gameObject2.sprite.srcx, element.Y] <= 1 &&
                            gameObject1.x - gameObject1.sprite.srcx == element.X &&
                            gameObject1.y == element.Y)
                        {
                            if (dirX > 0) dirX *= -1;
                            isColliding = true;
                            gameObject1.orient = 0;
                            gameObject2.x = element.X;
                            gameObject2.y = element.Y;
                        }
                        else gameObject2.orient = gameObject1.orient;
                        break;
                    case Keys.Down:
                        if (map[element.X, element.Y + gameObject1.sprite.srcy] <= 1 &&
                            gameObject1.x == element.X && gameObject1.y + gameObject1.sprite.srcy == element.Y)
                        {
                            if (dirY < 0) dirY *= -1;
                            isColliding = true;
                            gameObject1.orient = 0;
                            gameObject2.x = element.X;
                            gameObject2.y = element.Y;
                        }
                        else gameObject2.orient = gameObject1.orient;
                        break;
                    case Keys.Up:
                        if (map[element.X, element.Y - gameObject1.sprite.srcy] <= 1 &&
                            gameObject1.x == element.X && gameObject1.y - gameObject1.sprite.srcy == element.Y)
                        {
                            if (dirY > 0) dirY *= -1;
                            isColliding = true;
                            gameObject1.orient = 0;
                            gameObject2.x = element.X;
                            gameObject2.y = element.Y;
                        }
                        else gameObject2.orient = gameObject1.orient;
                        break;
                }
            }

            return isColliding;
        }

        public bool IsPlace(GameObject gameObject1, GameObject gameObject2, int[,] map, int MapWidth, int MapHeight)
        {
            var ElementList1 = gameObject1.collision.ElementList(map, gameObject1.sprite, MapWidth, MapHeight);
            bool isPlace = false;
            foreach (var element in ElementList1)
            {
                switch (gameObject1.orient)
                {
                    case Keys.Right:
                        if (map[element.X + gameObject1.sprite.srcx, element.Y] == gameObject2.sprite.spriteID)
                        {
                            if (dirX < 0) dirX *= -1;
                            isPlace = true;
                            gameObject1.orient = 0;
                            gameObject1.x = element.X;
                            gameObject1.y = element.Y;
                        }


                        break;
                    case Keys.Left:
                        if (map[element.X - gameObject1.sprite.srcx, element.Y] == gameObject2.sprite.spriteID)
                        {
                            if (dirX > 0) dirX *= -1;
                            isPlace = true;
                            gameObject1.orient = 0;
                            gameObject1.x = element.X;
                            gameObject1.y = element.Y;
                        }


                        break;
                    case Keys.Down:
                        if (map[element.X, element.Y + gameObject1.sprite.srcy] == gameObject2.sprite.spriteID)
                        {
                            if (dirY < 0) dirY *= -1;
                            isPlace = true;
                            gameObject1.orient = 0;
                            gameObject1.x = element.X;
                            gameObject1.y = element.Y;
                        }


                        break;
                    case Keys.Up:
                        if (map[element.X, element.Y - gameObject1.sprite.srcy] == gameObject2.sprite.spriteID)
                        {
                            if (dirY > 0) dirY *= -1;
                            isPlace = true;
                            gameObject1.orient = 0;
                            gameObject1.x = element.X;
                            gameObject1.y = element.Y;
                        }


                        break;

                }
            }

            return isPlace;
        }
    }
}
