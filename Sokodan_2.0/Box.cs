using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban_2._0
{
    class Box:GameObject
    {
        public Sprite BoxSprite()
        {
            sprite.spriteID = 2;
            sprite.srcx = 4;
            sprite.srcy = 4;
            sprite.srcWidth = 35;
            sprite.srcHeight = 35;
            return sprite;
        }
    }
}
