using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
