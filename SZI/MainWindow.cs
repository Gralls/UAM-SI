using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZI.AstarNamespace;

namespace SZI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGrids();
        }

        
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Project for SZI", "About");
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

           
        }

        public List<Tile> PopulateTileArray()
        {
            List<Tile> tileList = new List<Tile>();
            //TODO: przejście na tablice Button[,] grids
            foreach (Control c in this.Controls)
            {
                if (c is Button && Regex.IsMatch(c.Name, "^grid.+"))
                {

                    Location coords = ButtonToPositionMapper.getPosition((Button)c);
                    //TileImage image. = c.BackgroundImage

                    //tileList.Add(c);
                }
            }
            return tileList;
        }

        private Location ConvertPositionToLocation(System.Drawing.Point position)
        {
            int x = (position.X - locationStartX) / (sizeOfGrid + spaceBeetwenGrids);
            int y = (position.Y - locationStartY) / (sizeOfGrid + spaceBeetwenGrids);
            return new Location(x, y);
        }

        private void gridClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                TilePropertiesWindow tileProperties = new TilePropertiesWindow(button);
                tileProperties.Show();
            }

            if (e.Button == MouseButtons.Left)
            {
                Astar astar = new Astar();
                Location playerPos = MainLogic.Instance.GetActualPlayerPosition();
                if (playerPos == null)
                    return;
                Location target = ConvertPositionToLocation(button.Location);
                List<Tile> locationsVisited = astar.GetPath(
                    TileContainer.GetInstance().FindTile(playerPos), 
                    TileContainer.GetInstance().FindTile(target));

                grids[playerPos.x, playerPos.y].Image = null;
                Tile previousTile = null;
                foreach (Tile location in locationsVisited)
                {
                    int sleepTime = 250;
                    System.Threading.Thread.Sleep(sleepTime);
                    if (previousTile != null)
                    {
                        grids[previousTile.location.x, previousTile.location.y].Image = null;
                        grids[previousTile.location.x, previousTile.location.y].Refresh();
                    }
                    string spritesLocation = System.IO.Path.Combine(Environment.CurrentDirectory, "..\\..\\res\\sprites");
                    int x = location.location.x;
                    int y = location.location.y;
                    MainLogic.Instance.SetActualPlayerPosition(location.location);
                    grids[x, y].Image = Image.FromFile(spritesLocation + "\\machine.png");
                    //grids[x, y].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    grids[x, y].ImageAlign = ContentAlignment.MiddleCenter;
                    System.Threading.Thread.Sleep(sleepTime);
                    //zapisywanie pola z którego traktor wyjeżdża dla wyczyszczenia go
                    if (location != locationsVisited.Last())
                        previousTile = location;
                    else
                        previousTile = null;
                    grids[x, y].Refresh();
                }
                //*/
            }
        }

        /*private void AddToAnimate(Tile location, bool last, int iteration)
        {
            int sleepTime = 500;
            System.Threading.Thread.Sleep(sleepTime*iteration);
            string spritesLocation = System.IO.Path.Combine(Environment.CurrentDirectory, "..\\..\\res\\sprites");
            int x = location.location.x;
            int y = location.location.y;
            MainLogic.Instance.SetActualPlayerPosition(location.location);
            grids[x, y].Image = Image.FromFile(spritesLocation + "\\machine.png");
            grids[x, y].Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            grids[x, y].ImageAlign = ContentAlignment.MiddleCenter;
            grids[x, y].Refresh();
            System.Threading.Thread.Sleep(sleepTime);
            if (!last)
                grids[x, y].Image = null;
        }*/

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
