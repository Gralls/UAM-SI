﻿using System.Windows.Forms;

namespace SZI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnRerollMap = new System.Windows.Forms.Button();
            this.lblTerrainTypeInfo = new System.Windows.Forms.Label();
            this.lblTerrainTypeText = new System.Windows.Forms.Label();
            this.lblPlantStatusInfo = new System.Windows.Forms.Label();
            this.lblPlantStatusText = new System.Windows.Forms.Label();
            this.lblFertilizeStatusInfo = new System.Windows.Forms.Label();
            this.lblFertilizeStatusText = new System.Windows.Forms.Label();
            this.rtbOrdersLog = new System.Windows.Forms.RichTextBox();
            this.lblOrdersLog = new System.Windows.Forms.Label();
            this.geneticAlgorithm = new System.Windows.Forms.Button();
            this.rtbGeneticLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1579, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnRerollMap
            // 
            this.btnRerollMap.Location = new System.Drawing.Point(925, 33);
            this.btnRerollMap.Margin = new System.Windows.Forms.Padding(4);
            this.btnRerollMap.Name = "btnRerollMap";
            this.btnRerollMap.Size = new System.Drawing.Size(100, 28);
            this.btnRerollMap.TabIndex = 2;
            this.btnRerollMap.Text = "Reroll";
            this.btnRerollMap.UseVisualStyleBackColor = true;
            this.btnRerollMap.Visible = false;
            this.btnRerollMap.Click += new System.EventHandler(this.btnRerollMap_Click);
            // 
            // lblTerrainTypeInfo
            // 
            this.lblTerrainTypeInfo.AutoSize = true;
            this.lblTerrainTypeInfo.Location = new System.Drawing.Point(844, 100);
            this.lblTerrainTypeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerrainTypeInfo.Name = "lblTerrainTypeInfo";
            this.lblTerrainTypeInfo.Size = new System.Drawing.Size(81, 17);
            this.lblTerrainTypeInfo.TabIndex = 5;
            this.lblTerrainTypeInfo.Text = "Typ terenu:";
            // 
            // lblTerrainTypeText
            // 
            this.lblTerrainTypeText.AutoSize = true;
            this.lblTerrainTypeText.Location = new System.Drawing.Point(935, 100);
            this.lblTerrainTypeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTerrainTypeText.Name = "lblTerrainTypeText";
            this.lblTerrainTypeText.Size = new System.Drawing.Size(12, 17);
            this.lblTerrainTypeText.TabIndex = 7;
            this.lblTerrainTypeText.Text = " ";
            this.lblTerrainTypeText.Click += new System.EventHandler(this.lblTerrainTypeText_Click);
            // 
            // lblPlantStatusInfo
            // 
            this.lblPlantStatusInfo.AutoSize = true;
            this.lblPlantStatusInfo.Location = new System.Drawing.Point(848, 121);
            this.lblPlantStatusInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlantStatusInfo.Name = "lblPlantStatusInfo";
            this.lblPlantStatusInfo.Size = new System.Drawing.Size(58, 17);
            this.lblPlantStatusInfo.TabIndex = 8;
            this.lblPlantStatusInfo.Text = "Rośliny:";
            // 
            // lblPlantStatusText
            // 
            this.lblPlantStatusText.AutoSize = true;
            this.lblPlantStatusText.Location = new System.Drawing.Point(935, 121);
            this.lblPlantStatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlantStatusText.Name = "lblPlantStatusText";
            this.lblPlantStatusText.Size = new System.Drawing.Size(12, 17);
            this.lblPlantStatusText.TabIndex = 9;
            this.lblPlantStatusText.Text = " ";
            // 
            // lblFertilizeStatusInfo
            // 
            this.lblFertilizeStatusInfo.AutoSize = true;
            this.lblFertilizeStatusInfo.Location = new System.Drawing.Point(848, 142);
            this.lblFertilizeStatusInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFertilizeStatusInfo.Name = "lblFertilizeStatusInfo";
            this.lblFertilizeStatusInfo.Size = new System.Drawing.Size(78, 17);
            this.lblFertilizeStatusInfo.TabIndex = 10;
            this.lblFertilizeStatusInfo.Text = "Nawożona:";
            // 
            // lblFertilizeStatusText
            // 
            this.lblFertilizeStatusText.AutoSize = true;
            this.lblFertilizeStatusText.Location = new System.Drawing.Point(935, 142);
            this.lblFertilizeStatusText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFertilizeStatusText.Name = "lblFertilizeStatusText";
            this.lblFertilizeStatusText.Size = new System.Drawing.Size(12, 17);
            this.lblFertilizeStatusText.TabIndex = 11;
            this.lblFertilizeStatusText.Text = " ";
            // 
            // rtbOrdersLog
            // 
            this.rtbOrdersLog.Location = new System.Drawing.Point(675, 190);
            this.rtbOrdersLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbOrdersLog.Name = "rtbOrdersLog";
            this.rtbOrdersLog.ReadOnly = true;
            this.rtbOrdersLog.Size = new System.Drawing.Size(349, 272);
            this.rtbOrdersLog.TabIndex = 12;
            this.rtbOrdersLog.Text = "";
            // 
            // lblOrdersLog
            // 
            this.lblOrdersLog.AutoSize = true;
            this.lblOrdersLog.Location = new System.Drawing.Point(671, 170);
            this.lblOrdersLog.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOrdersLog.Name = "lblOrdersLog";
            this.lblOrdersLog.Size = new System.Drawing.Size(99, 17);
            this.lblOrdersLog.TabIndex = 13;
            this.lblOrdersLog.Text = "Log rozkazów:";
            // 
            // geneticAlgorithm
            // 
            this.geneticAlgorithm.Location = new System.Drawing.Point(1100, 158);
            this.geneticAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.geneticAlgorithm.Name = "geneticAlgorithm";
            this.geneticAlgorithm.Size = new System.Drawing.Size(196, 28);
            this.geneticAlgorithm.TabIndex = 16;
            this.geneticAlgorithm.Text = "Znajdź najlepsze rozłożenie";
            this.geneticAlgorithm.UseVisualStyleBackColor = true;
            this.geneticAlgorithm.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbGeneticLog
            // 
            this.rtbGeneticLog.Location = new System.Drawing.Point(1033, 190);
            this.rtbGeneticLog.Margin = new System.Windows.Forms.Padding(4);
            this.rtbGeneticLog.Name = "rtbGeneticLog";
            this.rtbGeneticLog.ReadOnly = true;
            this.rtbGeneticLog.Size = new System.Drawing.Size(465, 272);
            this.rtbGeneticLog.TabIndex = 19;
            this.rtbGeneticLog.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1579, 555);
            this.Controls.Add(this.rtbGeneticLog);
            this.Controls.Add(this.geneticAlgorithm);
            this.Controls.Add(this.lblOrdersLog);
            this.Controls.Add(this.rtbOrdersLog);
            this.Controls.Add(this.lblFertilizeStatusText);
            this.Controls.Add(this.lblFertilizeStatusInfo);
            this.Controls.Add(this.lblPlantStatusText);
            this.Controls.Add(this.lblPlantStatusInfo);
            this.Controls.Add(this.lblTerrainTypeText);
            this.Controls.Add(this.lblTerrainTypeInfo);
            this.Controls.Add(this.btnRerollMap);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SZI";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public Button[,] grids { get; private set; }
        private static int sizeInX = 6 ;
        private static int sizeInY = 6;
        private static int locationStartX = 12;
        private static int locationStartY = 25;
        private static int spaceBeetwenGrids = 3;
        private static int sizeOfGrid = 64;


        private void InitializeGrids()
        {
            grids = new ButtonWithTile[sizeInX, sizeInY];
            Tile[,] tiles = TileGenerator.GetInstance().CreateTiles(new RandomTileGeneratorStrategy(), sizeInX, sizeInY);
            for (int y = 0; y < sizeInY; y++)
            {
                for (int x = 0; x < sizeInX; x++)
                {
                    ButtonWithTile grid = new ButtonWithTile(tiles[x, y]);
                    tiles[x, y].Notify();
                    grid.Cursor = Cursors.Default;
                    grid.FlatStyle = FlatStyle.Flat;
                    grid.Location = new System.Drawing.Point(locationStartX + x * sizeOfGrid + x * spaceBeetwenGrids, locationStartY + y * sizeOfGrid + y * spaceBeetwenGrids);
                    grid.Name = "grid" + x + y;
                    grid.Size = new System.Drawing.Size(sizeOfGrid, sizeOfGrid);
                    grid.TabIndex = 2;
                    grid.UseVisualStyleBackColor = true;
                    grid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridClick);
                    grid.MouseEnter += new System.EventHandler(this.GridMouseOver);
                    this.Controls.Add(grid);
                    grids[x, y] = grid;
                }
            }
            TileContainer.GetInstance().SetTiles(tiles);
        }

        private Button btnRerollMap;
        private Label lblTerrainTypeInfo;
        private Label lblTerrainTypeText;
        private Label lblPlantStatusInfo;
        private Label lblPlantStatusText;
        private Label lblFertilizeStatusInfo;
        private Label lblFertilizeStatusText;
        private RichTextBox rtbOrdersLog;
        private Label lblOrdersLog;
        private Button geneticAlgorithm;
        private RichTextBox rtbGeneticLog;
    }
}

