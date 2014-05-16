﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class Player
    {
        private const int cards = 8;
        int playerId;

        public Card[] hand = new Card[cards];

        public bool isRed()
        {
            return playerId == Const.RED ? true : false;
        }

        public bool isBlue()
        {
            return playerId == Const.BLUE ? true : false;
        }

        public void setColor(int color)
        {
            this.playerId = color;
        }
    }
}