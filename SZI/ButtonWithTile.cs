using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    class ButtonWithTile : Button, IObserver
    {
        public Tile tile { get; private set; }
        public ButtonWithTile(Tile tile) : base()
        {
            tile.Attach(this);
            this.tile = tile;
        }
        
        ~ButtonWithTile()
        {
            tile.Detach(this);
        }
        public void UpdateAfterSubjectChanged()
        {
            TileImageLoader imageLoader = TileImageLoader.GetInstance();
            var oldRotation = tile.rotationOfPlayer;
            this.BackgroundImage = imageLoader.GetImageByName(tile.tileBackgroundName);
            this.BackgroundImageLayout = ImageLayout.Stretch;
            if (tile.havePlayer)
            {
                this.Image = imageLoader.GetPlayerImage();
                this.ImageAlign = ContentAlignment.MiddleCenter;
            }
            this.Refresh();
        }
    }
}
