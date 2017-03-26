using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZI
{
    public class Coordinates
    {
        int x;
        int y;
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return this.x;
        }
        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return this.y;
        }
        public void setY(int y)
        {
            this.y = y;
        }

    }
}
