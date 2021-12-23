using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban_2._0
{
    class Player:GameObject
    {
        public Sprite PlayerSprite()
        {
            sprite.spriteID = 1;
            sprite.srcx = 4;
            sprite.srcy = 4;
            sprite.srcWidth = 30;
            sprite.srcHeight = 32;
            return sprite;
        }

    }
}
