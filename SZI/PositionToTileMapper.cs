using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SZI
{
    public static class PositionToTileMapper
    {
        public static Button GetTile(Coordinates coords)
        {
            MainWindow mainForm = Application.OpenForms["MainWindow"] as MainWindow;
            return mainForm.grids[coords.x, coords.y];
        }
    }
}
