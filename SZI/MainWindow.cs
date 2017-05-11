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

        public void AddLineToOrdersLog(string line)
        {
            rtbOrdersLog.Text = line + "\n" + rtbOrdersLog.Text;
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
                if (tile.terrainType.type == TerrainFactory.TerrainTypesEnum.road)
                    return;
                ID3.ID3Tree id3 = new ID3.ID3Tree();
                AbstractOrder order;
                order = AbstractOrder.CreateOrder(id3.GetDecisionForTile(tile));
                while (order.orderNumber != -1)
                {
                    order.ExecuteOrder(tile);
                    String orderLog = String.Format("Wykonano rozkaz {0}.", order.logName).ToString();
                    AddLineToOrdersLog(orderLog);
                    order = AbstractOrder.CreateOrder(id3.GetDecisionForTile(tile));
                }
                AddLineToOrdersLog("Zakończono kolejke rozkazów");
                GridMouseOver(sender, e);
                TileContainer.GetInstance().ProceedTurnOnEveryTile();
            }
            else if (e.Button == MouseButtons.Left)
            {
                Astar astar = new Astar();
                Tile playerPos = MainLogic.Instance.GetActualPlayerTile();
                if (playerPos == null)
                    return;
                Location target = ConvertPositionToLocation(button.Location);
                List<Tile> locationsVisited = astar.GetPath(
                    playerPos, 
                    TileContainer.GetInstance().FindTile(target));
                ;
                foreach (Tile location in locationsVisited)
                {
                    int sleepTime = 250;
                    System.Threading.Thread.Sleep(sleepTime);
                    Tile actualTile = TileContainer.GetInstance().FindTile(location.location);
                    actualTile = location;
                    MainLogic.Instance.SetActualPlayerTile(actualTile);
                    actualTile.Notify();
                }
                TileContainer.GetInstance().ClearTilesRotationExceptPlayerLocation();
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
    }
}
