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
    public partial class TileProperties : Form
    {
        public static String spritesLocation;
        private Button senderGridCell;
        private String currentImagePath = null;
        private bool playerSetOnThisTile = false;
        public TileProperties(object sender)
        {
            InitializeComponent();
            senderGridCell = (Button)sender;
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
            if (playerSetOnThisTile)
            {
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
            playerSetOnThisTile = true;
        }
    }
}
