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
                Thread[] animationThreads = new Thread[locationsVisited.Count];
                for (int i = 0; i < locationsVisited.Count -1; i++)
                {
                    animationThreads[i] = new Thread(() => AddToAnimate(locationsVisited[i], locationsVisited.Last()));
                    animationThreads[i].Start();
                }
                /*foreach (Thread thread in animationThreads)
                {
                    thread.Join();
                }*/
            }
        }

        private void AddToAnimate(Tile location, Tile last)
        {
            int sleepTime = 500;
            System.Threading.Thread.Sleep(sleepTime);
            string spritesLocation = System.IO.Path.Combine(Environment.CurrentDirectory, "..\\..\\res\\sprites");
            int x = location.location.x;
            int y = location.location.y;
            MainLogic.Instance.SetActualPlayerPosition(location.location);
            grids[x, y].Image = Image.FromFile(spritesLocation + "\\machine.png");
            grids[x, y].ImageAlign = ContentAlignment.MiddleCenter;
            System.Threading.Thread.Sleep(sleepTime);
            if (location != last)
                grids[x, y].Image = null;
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
