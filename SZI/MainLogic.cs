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
        Coordinates actualPlayerPosition = null;
        private List<Tile> tileList;
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

        public void SetActualPlayerPosition(Coordinates coords)
        {
            this.actualPlayerPosition = coords;
        }

        public Coordinates GetActualPlayerPosition()
        {
            return this.actualPlayerPosition;
        }

        private void PopulateTileGrid()
        {
           
        }

        private void GetAllControls(MainLogic mainLogic, List<Control> list)
        {
            throw new NotImplementedException();
        }
    }
}
