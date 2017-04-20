using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            }

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
