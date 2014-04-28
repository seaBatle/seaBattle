using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace seaBattle.Common
{
    public class ShipRectangle
    {
        public Rectangle rectangle;

        public bool IsChecked;

        public ShipRectangle()
        {
            rectangle = new Rectangle();

            IsChecked = false;
        }
    }
}
