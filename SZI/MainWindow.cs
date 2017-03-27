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

namespace SZI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

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
            foreach (Control c in this.Controls)
            {
                if (c is Button && Regex.IsMatch(c.Name, "^grid.+"))
                {

                    Coordinates coords = ButtonToPositionMapper.getPosition((Button)c);
                    //TileImage image. = c.BackgroundImage

                    //tileList.Add(c);
                }
            }
            return tileList;
        }

        private void gridClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            TilePropertiesWindow tileProperties = new TilePropertiesWindow(button);
            tileProperties.Show();
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
