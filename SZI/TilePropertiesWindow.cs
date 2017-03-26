using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SZI
{
    public partial class TilePropertiesWindow : Form
    {
        public static String spritesLocation;
        private Button senderGridCell;
        private String currentImagePath = null;
        private bool setPlayerSetOnThisTile = false;
        public TilePropertiesWindow(object sender)
        {
            InitializeComponent();
            senderGridCell = (Button)sender;
            Coordinates position = TileToPositionMapper.getPosition((Button)sender);
            XPosValue.Text = position.GetX().ToString();
            YPosValue.Text = position.GetY().ToString();
            spritesLocation = Path.Combine(Environment.CurrentDirectory, "..\\..\\res\\sprites");
            PopulateListBox(ImageListBox, spritesLocation, "*.jpg");
        }

        private void TileProperties_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (currentImagePath != null)
            { 
                senderGridCell.BackgroundImage = Image.FromFile(currentImagePath);
                senderGridCell.BackgroundImageLayout = ImageLayout.Stretch;
            }
            if (setPlayerSetOnThisTile)
            {
                Coordinates actualPlayerPosition = MainLogic.Instance.GetActualPlayerPosition();
                if (actualPlayerPosition != null)
                {
                    PositionToTileMapper.getTile(actualPlayerPosition).Image = null;
                }
                MainLogic.Instance.SetActualPlayerPosition(TileToPositionMapper.getPosition(this.senderGridCell));
                senderGridCell.Image = Image.FromFile(spritesLocation + "\\machine.png");
                senderGridCell.ImageAlign = ContentAlignment.MiddleCenter;
            }
            this.Close();
        }
        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void Type_Click(object sender, EventArgs e)
        {

        }

        private void ImageListBoxSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (ImageListBox.SelectedItem != null)
            {
                String filename = ImageListBox.SelectedItem.ToString();
                currentImagePath = spritesLocation + "\\" + filename;
                PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBox.Image = Image.FromFile(currentImagePath);
            }
            
        }

        private void PlayerSetterButton_Click(object sender, EventArgs e)
        {
            setPlayerSetOnThisTile = true;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
