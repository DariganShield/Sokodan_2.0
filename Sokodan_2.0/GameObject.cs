using System.Windows.Forms;

namespace Sokoban_2._0
{
    class GameObject
    {
        public Sprite sprite = new Sprite();
        public Collision collision = new Collision();
        public int x;
        public int y;
        public Keys orient;
    }
}
