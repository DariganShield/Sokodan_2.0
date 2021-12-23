namespace Sokoban_2._0
{
    class Wall : GameObject
    {
        public Sprite WallSprite()
        {
            sprite.spriteID = 3;
            sprite.srcx = 4;
            sprite.srcy = 4;
            sprite.srcWidth = 35;
            sprite.srcHeight = 35;
            return sprite;
        }
    }
}
