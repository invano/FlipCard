using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class Game
    {
        private const int cards = 16;

        public Card[] cardsOnTable = new Card[cards]; 

        public int abovePositionWRTLocation(int initWithInt)
        {
            int abovePosition = 0;
            return abovePosition;
        }

        public int belowPositionWRTLocation(int initWithInt)
        {
            int belowPosition = 0;
            return belowPosition;
        }
        public int leftPositionWRTLocation(int initWithInt)
        {
            int leftPosition = 0;
            return leftPosition;
        }
        public int rightPositionWRTLocation(int initWithInt)
        {
            int rightPosition = 0;
            return rightPosition;
        }
    }
}
