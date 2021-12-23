namespace Sokoban_2._0
{
    class Player : GameObject
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
