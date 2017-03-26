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
            string buttonName = "grid" + coords.GetX().ToString() + coords.GetY().ToString();
            Form mainForm = Application.OpenForms[0];
            return mainForm.Controls.Find(buttonName, true).FirstOrDefault() as Button;
        }
    }
}
