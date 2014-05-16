using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class Card
    {
        public int upValue;
        public int downValue;
        public int leftValue;
        public int rightValue;
        int color;

        public bool isRed()
        {
            return color == Const.RED ? true : false;
        }

        public bool isBlue()
        {
            return color == Const.BLUE ? true : false;
        }

        public void setColor(int color)
        {
            this.color = color;
        }
    }
}
