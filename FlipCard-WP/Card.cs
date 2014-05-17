using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    public class Card
    {
        public int idNumber;
        public int upValue;
        public int downValue;
        public int leftValue;
        public int rightValue;

        public int color;

        //int manaType; NOTE USED ATM

        public int rarityType;

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

        public int getColor() {

            return this.color;
        }

        public String description() {
            return "CardId: " + this.idNumber;
        }

        public void clone(Card card)
        {
            this.idNumber = card.idNumber;
            this.upValue = card.upValue;
            this.downValue = card.downValue;
            this.leftValue = card.leftValue;
            this.rightValue = card.rightValue;
            this.color = card.getColor();
            this.rarityType = card.rarityType;
        }

    }
}
