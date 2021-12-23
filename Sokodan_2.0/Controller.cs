using System.Windows.Forms;

namespace Sokoban_2._0
{
    class Controller : Colliding

    {
        public void ImputCheck(GameObject gameObject, int[,] map, KeyEventArgs e)
        {
            gameObject.collision.CollisionClear(map, gameObject.x, gameObject.y);
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (map[gameObject.x + 4, gameObject.y] == 0) gameObject.x = gameObject.x + (gameObject.sprite.srcx);
                    else gameObject.orient = Keys.Right;
                    break;
                case Keys.Left:
                    if (map[gameObject.x - 4, gameObject.y] == 0) gameObject.x = gameObject.x - (gameObject.sprite.srcx);
                    else gameObject.orient = Keys.Left;
                    break;
                case Keys.Up:
                    if (map[gameObject.x, gameObject.y - 4] == 0) gameObject.y = gameObject.y - (gameObject.sprite.srcy);
                    else gameObject.orient = Keys.Up;

                    break;
                case Keys.Down:
                    if (map[gameObject.x, gameObject.y + 4] == 0) gameObject.y = gameObject.y + (gameObject.sprite.srcy);
                    else gameObject.orient = Keys.Down;
                    break;
            }

            gameObject.collision.CollisionBoundaries(map, gameObject.sprite, gameObject.x, gameObject.y);
        }
    }
}
