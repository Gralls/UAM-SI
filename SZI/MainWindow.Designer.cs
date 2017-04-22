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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(781, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnRerollMap
            // 
            this.btnRerollMap.Location = new System.Drawing.Point(694, 27);
            this.btnRerollMap.Name = "btnRerollMap";
            this.btnRerollMap.Size = new System.Drawing.Size(75, 23);
            this.btnRerollMap.TabIndex = 2;
            this.btnRerollMap.Text = "Reroll";
            this.btnRerollMap.UseVisualStyleBackColor = true;
            this.btnRerollMap.Click += new System.EventHandler(this.btnRerollMap_Click);
            // 
            // lblTerrainTypeInfo
            // 
            this.lblTerrainTypeInfo.AutoSize = true;
            this.lblTerrainTypeInfo.Location = new System.Drawing.Point(633, 81);
            this.lblTerrainTypeInfo.Name = "lblTerrainTypeInfo";
            this.lblTerrainTypeInfo.Size = new System.Drawing.Size(61, 13);
            this.lblTerrainTypeInfo.TabIndex = 5;
            this.lblTerrainTypeInfo.Text = "Typ terenu:";
            // 
            // lblTerrainTypeText
            // 
            this.lblTerrainTypeText.AutoSize = true;
            this.lblTerrainTypeText.Location = new System.Drawing.Point(701, 81);
            this.lblTerrainTypeText.Name = "lblTerrainTypeText";
            this.lblTerrainTypeText.Size = new System.Drawing.Size(73, 13);
            this.lblTerrainTypeText.TabIndex = 7;
            this.lblTerrainTypeText.Text = "";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(781, 451);
            this.Controls.Add(this.lblTerrainTypeText);
            this.Controls.Add(this.lblTerrainTypeInfo);
            this.Controls.Add(this.btnRerollMap);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

