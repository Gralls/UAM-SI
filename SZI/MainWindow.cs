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
using SZI.ImageRecognition;
using System.Threading;
using SZI.Genetics;
namespace SZI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGrids();
        }

        public void AddLinesToOrdersLog(string orders)
        {
            rtbOrdersLog.Text = orders + "\n" + rtbOrdersLog.Text;
        }

        public void AddLinesToOrdersLog(List<string> orders)
        {
            if (orders == null)
                return;
            foreach (string str in orders)
                AddLinesToOrdersLog(str);
        }
        public void AddLinesToGeneticsLog(List<string> results)
        {
            if (results == null)
                return;
            foreach (string str in results)
                AddLinesToGeneticsLog(str);
        }
        public void AddLinesToGeneticsLog(string orders)
        {
            rtbGeneticLog.Text = orders + "\n" + rtbGeneticLog.Text;
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

        private Location ConvertPositionToLocation(System.Drawing.Point position)
        {
            int x = (position.X - locationStartX) / (sizeOfGrid + spaceBeetwenGrids);
            int y = (position.Y - locationStartY) / (sizeOfGrid + spaceBeetwenGrids);
            return new Location(x, y);
        }

        private void GridMouseOver(object sender, System.EventArgs e)
        {
            ButtonWithTile button = (ButtonWithTile)sender;
            lblTerrainTypeText.Text = button.tile.terrainType.name;
            if (button.tile.terrainType.type == TerrainFactory.TerrainTypesEnum.road)
            {
                lblPlantStatusText.Text = "nie dotyczy";
                lblFertilizeStatusText.Text = "nie dotyczy";
            }
            else
            {
                lblPlantStatusText.Text = button.tile.plant.StringInfo();
                lblFertilizeStatusText.Text = button.tile.fertilizeStatus.FertilizeStringInfo();
            }
            if (button.tile.recognizedTerrainType != null)
                lblRecognizedTerrainTypeText.Text = button.tile.recognizedTerrainType.name;
        }

        private void gridClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (e.Button == MouseButtons.Right)
            {
                TilePropertiesWindow tileProperties = new TilePropertiesWindow(button);
                tileProperties.Show();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                Location target = ConvertPositionToLocation(button.Location);
                Tile tile = TileContainer.GetInstance().FindTile(target);
                MainLogic.Instance.MovePlayer(TileContainer.GetInstance().FindTile(target));
                List<string> ordersLog = MainLogic.Instance.StartWorkAtTile(tile);
                AddLinesToOrdersLog(ordersLog);
                GridMouseOver(sender, e);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Tile playerPos = MainLogic.Instance.GetActualPlayerTile();
                if (playerPos == null)
                    return;
                Location target = ConvertPositionToLocation(button.Location);
                MainLogic.Instance.MovePlayer(TileContainer.GetInstance().FindTile(target));
            }

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRerollMap_Click(object sender, EventArgs e)
        {
            InitializeGrids();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTerrainTypeText_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> logs = MainLogic.Instance.GenerateBestPopulation();
            AddLinesToGeneticsLog(logs);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private async void TestPython_Click(object sender, EventArgs e)
        {
            Tile[,] tiles = TileContainer.GetInstance().GetTiles();
            Button button = (Button)sender;
            void modButton(String text, bool isEnabled)
            {
                button.Text = text;
                button.Enabled = isEnabled;
            }
            TileRecognition ir = new TileRecognition();
            modButton("Working...", false);
            bool isGood = true;
            await Task.Run(() => 
            {
                isGood = ir.recognizeTiles(tiles);
            });
            if (!isGood)
            {
                modButton("ERROR", false);
            }
            else
            {
                this.lblRecognizedTerrainTypeInfo.Visible = true;
                this.lblRecognizedTerrainTypeText.Visible = true;
                modButton("Recognize tiles", true);
            }
                
            
        }

        private void lblFertilizeStatusText_Click(object sender, EventArgs e)
        {

        }

        private void lblPlantStatusInfo_Click(object sender, EventArgs e)
        {

        }

       

        private void lblRecognizedTerrainTypeInfo_Click(object sender, EventArgs e)
        {

        }

        
        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            String fileName = @MainLogic.Instance.GenerateWeatherImage();
            box.Image = Image.FromFile(fileName);
            this.lblRecognizedWeatherTypeText.Text = "wait...";
            WeatherRecognition wr = new WeatherRecognition();
            String result = "";
            await Task.Run(() =>
            {
                result = wr.recognizeWeather(fileName);
            });
            this.lblRecognizedWeatherTypeInfo.Visible = true;
            this.lblRecognizedWeatherTypeText.Text = result;
            this.lblRecognizedWeatherTypeText.Visible = true;

        }

    }
}
