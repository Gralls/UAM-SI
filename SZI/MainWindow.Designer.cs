using System.Windows.Forms;

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
            this.lblRecognizedTerrainTypeInfo = new System.Windows.Forms.Label();
            this.lblRecognizedTerrainTypeText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblRecognizedWeatherTypeInfo = new System.Windows.Forms.Label();
            this.lblRecognizedWeatherTypeText = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.btnRerollMap.Location = new System.Drawing.Point(504, 81);
            this.btnRerollMap.Name = "btnRerollMap";
            this.btnRerollMap.Size = new System.Drawing.Size(91, 23);
            this.btnRerollMap.TabIndex = 2;
            this.btnRerollMap.Text = "Reroll";
            this.btnRerollMap.UseVisualStyleBackColor = true;
            this.btnRerollMap.Visible = false;
            this.btnRerollMap.Click += new System.EventHandler(this.btnRerollMap_Click);
            // 
            // lblTerrainTypeInfo
            // 
            this.lblTerrainTypeInfo.AutoSize = true;
            this.lblTerrainTypeInfo.Location = new System.Drawing.Point(610, 69);
            this.lblTerrainTypeInfo.Name = "lblTerrainTypeInfo";
            this.lblTerrainTypeInfo.Size = new System.Drawing.Size(61, 13);
            this.lblTerrainTypeInfo.TabIndex = 5;
            this.lblTerrainTypeInfo.Text = "Typ terenu:";
            // 
            // lblTerrainTypeText
            // 
            this.lblTerrainTypeText.AutoSize = true;
            this.lblTerrainTypeText.Location = new System.Drawing.Point(678, 69);
            this.lblTerrainTypeText.Name = "lblTerrainTypeText";
            this.lblTerrainTypeText.Size = new System.Drawing.Size(10, 13);
            this.lblTerrainTypeText.TabIndex = 7;
            this.lblTerrainTypeText.Text = " ";
            // 
            // lblPlantStatusInfo
            // 
            this.lblPlantStatusInfo.AutoSize = true;
            this.lblPlantStatusInfo.Location = new System.Drawing.Point(610, 86);
            this.lblPlantStatusInfo.Name = "lblPlantStatusInfo";
            this.lblPlantStatusInfo.Size = new System.Drawing.Size(44, 13);
            this.lblPlantStatusInfo.TabIndex = 8;
            this.lblPlantStatusInfo.Text = "Rośliny:";
            this.lblPlantStatusInfo.Click += new System.EventHandler(this.lblPlantStatusInfo_Click);
            // 
            // lblPlantStatusText
            // 
            this.lblPlantStatusText.AutoSize = true;
            this.lblPlantStatusText.Location = new System.Drawing.Point(678, 86);
            this.lblPlantStatusText.Name = "lblPlantStatusText";
            this.lblPlantStatusText.Size = new System.Drawing.Size(10, 13);
            this.lblPlantStatusText.TabIndex = 9;
            this.lblPlantStatusText.Text = " ";
            // 
            // lblFertilizeStatusInfo
            // 
            this.lblFertilizeStatusInfo.AutoSize = true;
            this.lblFertilizeStatusInfo.Location = new System.Drawing.Point(610, 103);
            this.lblFertilizeStatusInfo.Name = "lblFertilizeStatusInfo";
            this.lblFertilizeStatusInfo.Size = new System.Drawing.Size(61, 13);
            this.lblFertilizeStatusInfo.TabIndex = 10;
            this.lblFertilizeStatusInfo.Text = "Nawożona:";
            // 
            // lblFertilizeStatusText
            // 
            this.lblFertilizeStatusText.AutoSize = true;
            this.lblFertilizeStatusText.Location = new System.Drawing.Point(678, 103);
            this.lblFertilizeStatusText.Name = "lblFertilizeStatusText";
            this.lblFertilizeStatusText.Size = new System.Drawing.Size(10, 13);
            this.lblFertilizeStatusText.TabIndex = 11;
            this.lblFertilizeStatusText.Text = " ";
            this.lblFertilizeStatusText.Click += new System.EventHandler(this.lblFertilizeStatusText_Click);
            // 
            // rtbOrdersLog
            // 
            this.rtbOrdersLog.Location = new System.Drawing.Point(506, 154);
            this.rtbOrdersLog.Name = "rtbOrdersLog";
            this.rtbOrdersLog.ReadOnly = true;
            this.rtbOrdersLog.Size = new System.Drawing.Size(263, 222);
            this.rtbOrdersLog.TabIndex = 12;
            this.rtbOrdersLog.Text = "";
            // 
            // lblOrdersLog
            // 
            this.lblOrdersLog.AutoSize = true;
            this.lblOrdersLog.Location = new System.Drawing.Point(503, 138);
            this.lblOrdersLog.Name = "lblOrdersLog";
            this.lblOrdersLog.Size = new System.Drawing.Size(76, 13);
            this.lblOrdersLog.TabIndex = 13;
            this.lblOrdersLog.Text = "Log rozkazów:";
            // 
            // lblRecognizedTerrainTypeInfo
            // 
            this.lblRecognizedTerrainTypeInfo.AutoSize = true;
            this.lblRecognizedTerrainTypeInfo.Location = new System.Drawing.Point(610, 128);
            this.lblRecognizedTerrainTypeInfo.Name = "lblRecognizedTerrainTypeInfo";
            this.lblRecognizedTerrainTypeInfo.Size = new System.Drawing.Size(119, 13);
            this.lblRecognizedTerrainTypeInfo.TabIndex = 15;
            this.lblRecognizedTerrainTypeInfo.Text = "Rozpoznany typ terenu:";
            this.lblRecognizedTerrainTypeInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblRecognizedTerrainTypeInfo.Visible = false;
            this.lblRecognizedTerrainTypeInfo.Click += new System.EventHandler(this.lblRecognizedTerrainTypeInfo_Click);
            // 
            // lblRecognizedTerrainTypeText
            // 
            this.lblRecognizedTerrainTypeText.AutoSize = true;
            this.lblRecognizedTerrainTypeText.Location = new System.Drawing.Point(758, 128);
            this.lblRecognizedTerrainTypeText.Name = "lblRecognizedTerrainTypeText";
            this.lblRecognizedTerrainTypeText.Size = new System.Drawing.Size(0, 13);
            this.lblRecognizedTerrainTypeText.TabIndex = 16;
            this.lblRecognizedTerrainTypeText.Visible = false;
            this.lblRecognizedTerrainTypeText.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Location = new System.Drawing.Point(447, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(111, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblRecognizedWeatherTypeInfo
            // 
            this.lblRecognizedWeatherTypeInfo.AutoSize = true;
            this.lblRecognizedWeatherTypeInfo.Location = new System.Drawing.Point(565, 25);
            this.lblRecognizedWeatherTypeInfo.Name = "lblRecognizedWeatherTypeInfo";
            this.lblRecognizedWeatherTypeInfo.Size = new System.Drawing.Size(67, 13);
            this.lblRecognizedWeatherTypeInfo.TabIndex = 19;
            this.lblRecognizedWeatherTypeInfo.Text = "Recognized:";
            this.lblRecognizedWeatherTypeInfo.Visible = false;
            this.lblRecognizedWeatherTypeInfo.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblRecognizedWeatherTypeText
            // 
            this.lblRecognizedWeatherTypeText.AutoSize = true;
            this.lblRecognizedWeatherTypeText.Location = new System.Drawing.Point(638, 25);
            this.lblRecognizedWeatherTypeText.Name = "lblRecognizedWeatherTypeText";
            this.lblRecognizedWeatherTypeText.Size = new System.Drawing.Size(96, 13);
            this.lblRecognizedWeatherTypeText.TabIndex = 20;
            this.lblRecognizedWeatherTypeText.Text = "Not recognized yet";
            this.lblRecognizedWeatherTypeText.Visible = false;
            this.lblRecognizedWeatherTypeText.Click += new System.EventHandler(this.label2_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(781, 451);
            this.Controls.Add(this.lblRecognizedWeatherTypeText);
            this.Controls.Add(this.lblRecognizedWeatherTypeInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblRecognizedTerrainTypeText);
            this.Controls.Add(this.lblRecognizedTerrainTypeInfo);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SZI";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private Label lblRecognizedTerrainTypeInfo;
        private Label lblRecognizedTerrainTypeText;
        private PictureBox pictureBox1;
        private Label lblRecognizedWeatherTypeInfo;
        private Label lblRecognizedWeatherTypeText;
    }
}

