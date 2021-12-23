using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sokoban_2._0
{
    public partial class Form1 : Form
    {
        public const int MapWidth = 41;
        public const int MapHeight = 41;
        int currentValue;
        public int[,] map = new int[MapWidth, MapHeight];
        private FieldGenerate generator = new FieldGenerate();
        private Player player = new Player();
        private Box box = new Box();
        private Wall wall = new Wall();
        private Colliding colliding = new Colliding();
        private Controller controller = new Controller();
        private BoxPlace boxPlace = new BoxPlace();
        public Image SokobanSet;
        public Form1()
        {
            InitializeComponent();
            gameTimer.Tick += new EventHandler(Update);
            this.KeyUp += new KeyEventHandler(ImputCheck);
            Init();
        }
        private void ImputCheck(object sender, KeyEventArgs e)
        {
            controller.ImputCheck(player, map, e);
            currentValue++;
        }

        private void Update(object sender, EventArgs e)
        {
            if ((player.orient == Keys.Right || player.orient == Keys.Left))
            {
                if (colliding.IsCollide(player, box, map, MapWidth, MapHeight))
                {
                    box.x += colliding.dirX;
                    player.x += colliding.dirX;
                }
                player.collision.CollisionBoundaries(map, player.PlayerSprite(), player.x, player.y);
                box.collision.CollisionBoundaries(map, box.BoxSprite(), box.x, box.y);
                if (colliding.IsPlace(box, boxPlace, map, MapWidth, MapHeight))
                {
                    box.collision.CollisionClear(map, box.x, box.y);
                    box.x += colliding.dirX;
                }
                box.collision.CollisionBoundaries(map, box.BoxSprite(), box.x, box.y);
                if (colliding.IsPlace(player, boxPlace, map, MapWidth, MapHeight))
                {
                    player.collision.CollisionClear(map, player.x, player.y);
                    player.x += colliding.dirX;
                }
                player.collision.CollisionBoundaries(map, player.PlayerSprite(), player.x, player.y);

            }

            if ((player.orient == Keys.Up || player.orient == Keys.Down))
            {
                if (colliding.IsCollide(player, box, map, MapWidth, MapHeight))
                {
                    box.y += colliding.dirY;
                    player.y += colliding.dirY;
                }
                player.collision.CollisionBoundaries(map, player.PlayerSprite(), player.x, player.y);
                box.collision.CollisionBoundaries(map, box.BoxSprite(), box.x, box.y);
                if (colliding.IsPlace(box, boxPlace, map, MapWidth, MapHeight))
                {
                    box.collision.CollisionClear(map, box.x, box.y);
                    box.y += colliding.dirY;
                }
                box.collision.CollisionBoundaries(map, box.BoxSprite(), box.x, box.y);
                if (colliding.IsPlace(player, boxPlace, map, MapWidth, MapHeight))
                {
                    player.collision.CollisionClear(map, player.x, player.y);
                    player.y += colliding.dirY;
                }
                player.collision.CollisionBoundaries(map, player.PlayerSprite(), player.x, player.y);
            }
            player.collision.CollisionBoundaries(map, player.PlayerSprite(), player.x, player.y);
            box.collision.CollisionBoundaries(map, box.BoxSprite(), box.x, box.y);
            generator.BoxPlaceGenerate(boxPlace, MapWidth, MapHeight, map);
            Invalidate();
            GameOver();
        }

        public void DrawAreaBoundary(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(0, 0, MapWidth * 10, MapHeight * 11));
        }
        public void Init()
        {
            this.Width = (MapWidth + 2) * 10;
            this.Height = (MapHeight + 10) * 10;
            SokobanSet = new Bitmap("C:\\Users\\User\\source\\repos\\Sokodan_2.0\\Sokodan_2.0\\Image\\Sokoban.png");
            gameTimer.Interval = 100;
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    map[i, j] = 0;
                }
            }

            player.x = 20;
            player.y = 20;
            player.collision.CollisionBoundaries(map, player.PlayerSprite(), player.x, player.y);
            colliding.dirX = 4;
            colliding.dirY = -4;
            WallGenerator();
            generator.BoxPlaceGenerate(boxPlace, MapWidth, MapHeight, map);
            BoxGenerator();
            gameTimer.Start();
        }

        public void WallGenerator()
        {
            for (int i = 0; i < MapWidth - colliding.dirX; i += colliding.dirX)
            {
                for (int j = 0; j < MapHeight; j += -(colliding.dirY))
                {
                    if (i >= colliding.dirX && i <= MapWidth - 2 * (colliding.dirX))
                    {
                        wall.x = i;
                        wall.y = 0;
                        player.collision.CollisionBoundaries(map, wall.WallSprite(), wall.x, wall.y);
                        wall.x = i;
                        wall.y = MapHeight - 1;
                        player.collision.CollisionBoundaries(map, wall.WallSprite(), wall.x, wall.y);
                    }
                    else
                    {
                        wall.x = i;
                        wall.y = j;
                        player.collision.CollisionBoundaries(map, wall.WallSprite(), wall.x, wall.y);
                    }
                }
            }
        }
        public void BoxGenerator()
        {
            Random rnd1 = new Random();
            int count = 0;
            while (count < 6)
            {
                box.x = rnd1.Next(colliding.dirX * 2, MapWidth - 1 - colliding.dirX * 2);
                box.y = rnd1.Next(Math.Abs(colliding.dirY) * 2, MapHeight - 1 - Math.Abs(colliding.dirY) * 2);
                if (map[box.x, box.y] == 0 && box.x % 4 == 0 && box.y % 4 == 0)
                {
                    count++;
                    box.collision.CollisionBoundaries(map, box.BoxSprite(), box.x, box.y);
                }
            }
        }
        public void DrawMap(Graphics g)
        {
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    if (map[i, j] == player.sprite.spriteID)
                    {
                        g.DrawImage(SokobanSet, new Rectangle(new Point(i * 10, j * 10),
                            new Size(player.PlayerSprite().srcx * 10, player.PlayerSprite().srcy * 10))
                            , 0, 0, player.PlayerSprite().srcWidth, player.PlayerSprite().srcHeight, GraphicsUnit.Pixel);
                    }

                    if (map[i, j] == box.sprite.spriteID)
                    {
                        g.DrawImage(SokobanSet, new Rectangle(new Point(i * 10, j * 10),
                            new Size(box.BoxSprite().srcx * 10, box.BoxSprite().srcy * 10))
                            , 32, 0, box.BoxSprite().srcWidth, box.BoxSprite().srcHeight, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == wall.sprite.spriteID)
                    {
                        g.DrawImage(SokobanSet, new Rectangle(new Point(i * 10, j * 10),
                                new Size(wall.WallSprite().srcx * 10, wall.WallSprite().srcy * 10))
                            , 72, 0, wall.WallSprite().srcWidth, wall.WallSprite().srcHeight, GraphicsUnit.Pixel);
                    }
                    if (map[i, j] == boxPlace.sprite.spriteID)
                    {
                        g.DrawImage(SokobanSet, new Rectangle(new Point(i * 10, j * 10),
                                new Size(boxPlace.BoxPlaceSprite().srcx * 10, boxPlace.BoxPlaceSprite().srcy * 10))
                            , 112, 0, boxPlace.BoxPlaceSprite().srcWidth, boxPlace.BoxPlaceSprite().srcHeight, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        private void OnPaint(object sender, PaintEventArgs e)
        {
            DrawAreaBoundary(e.Graphics);
            DrawMap(e.Graphics);
        }

        private void GameOver()
        {
            if (boxPlace.collision.ElementList(map, boxPlace.BoxPlaceSprite(), MapWidth, MapHeight).Count == 0)
            {
                DialogResult dialog = MessageBox.Show(
                    "Вы победили",
                    "Конец игры",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                gameTimer.Stop();
                if (dialog == DialogResult.Yes) this.Close();
            }

        }
    }
}
