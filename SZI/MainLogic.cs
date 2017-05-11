using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    class MainLogic
    {
        private static MainLogic instance;
        Tile actualPlayerPosition = null;
        public static MainLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainLogic();
                }
                return instance;
            }
        }

        public void SetActualPlayerTile(Tile tile)
        {
            if (actualPlayerPosition != null)
            {
                actualPlayerPosition.havePlayer = false;
                actualPlayerPosition.rotationOfPlayer = Tile.RotationEnum.none;
                actualPlayerPosition.Notify();
            }
            else
                tile.rotationOfPlayer = Tile.RotationEnum.west;
            this.actualPlayerPosition = tile;
            actualPlayerPosition.havePlayer = true;
            actualPlayerPosition.Notify();
        }

        public Tile GetActualPlayerTile()
        {
            return this.actualPlayerPosition;
        }
    }
}
