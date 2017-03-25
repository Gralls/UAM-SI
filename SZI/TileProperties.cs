using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SZI
{
    public partial class TileProperties : Form
    {
        public static String spritesLocation = @"C:\Users\Michał\Desktop\sprite";
        private Button senderGridCell;
        private String currentImagePath;
        public TileProperties(object sender)
        {
            InitializeComponent();
            senderGridCell = (Button)sender;
            //look what happens when you will not have double backslashes
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
            senderGridCell.BackgroundImage = Image.FromFile(currentImagePath);
            senderGridCell.BackgroundImageLayout = ImageLayout.Stretch;
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
            String filename = ImageListBox.SelectedItem.ToString();
            currentImagePath = spritesLocation + "\\" + filename;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Image = Image.FromFile(currentImagePath);
            
        }
    }
}
