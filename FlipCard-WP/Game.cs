using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class Game
    {
        public Card[] cardsOnTable;
        Player redPlayer = new Player();
        Player bluePlayer = new Player();
        CardsLibrary myCardsLibrary;

        public Game()
        {
            int i = 0;
            this.cardsOnTable = new Card[Const.PLACES_ON_TABLE];
            this.myCardsLibrary = new CardsLibrary("cardsLibrary");
        }

        private bool addCard(int positionInHandOfPlayedCard, int x, Player whoPlayed)
        {
            int arrayPosition = x;
            if(this.cardsOnTable[arrayPosition] == null){
                this.cardsOnTable[arrayPosition] = whoPlayed.hand[positionInHandOfPlayedCard];
                this.cardsOnTable[arrayPosition].setColor(whoPlayed.playerId);
                removeFromHandCard(positionInHandOfPlayedCard, whoPlayed);
                checkActionAtPosition(x, whoPlayed);
                return true;
            }
            return false;
        }

        public int abovePositionWRTLocation(int x) {

            int arrayPosition = x;
            if(arrayPosition < Const.ROW_LENGHT) return -1;
            int abovePosition = arrayPosition - Const.ROW_LENGHT;

            return abovePosition;
        }

        public int belowPositionWRTLocation(int x) {
            
            int arrayPosition = x;
            if(arrayPosition >= (Const.PLACES_ON_TABLE - Const.ROW_LENGHT)) return -1;
            int belowPosition = arrayPosition + Const.ROW_LENGHT;

            return belowPosition;
        }

        public int leftPositionWRTLocation(int x) {
            
            int arrayPosition = x;
            if(arrayPosition==0 || (arrayPosition % Const.ROW_LENGHT) == 0) return -1;
            int leftPosition = arrayPosition-1;

            return leftPosition;
        }
        public int rightPositionWRTLocation(int x) {
           
            int arrayPosition = x;
            if(((arrayPosition + 1) % Const.ROW_LENGHT) == 0) return -1;
            int rightPosition = arrayPosition+1;
            return rightPosition;
        }

        private int checkActionAtPosition(int x, Player whoPlayed) {
            int countFlips=0;
            
            if(checkAbove(x, whoPlayed)) countFlips++;
            if(checkDown(x, whoPlayed)) countFlips++;
            if(checkRight(x, whoPlayed)) countFlips++;
            if(checkLeft(x, whoPlayed)) countFlips++;
            return countFlips;
        }

        private bool checkAbove(int x, Player whoPlayed) {
            int abovePosition = abovePositionWRTLocation(x);
            if(abovePosition >= 0){
                int arrayPosition = x;
            if(this.cardsOnTable[abovePosition] == null) return false;
            else {
                if(this.cardsOnTable[abovePosition].downValue < this.cardsOnTable[arrayPosition].upValue){
                    this.cardsOnTable[abovePosition].setColor(whoPlayed.playerId);
                    return true;
                    }
                }
            }
            return false;
        }

        private bool checkDown(int x, Player whoPlayed)
        {
            int belowPosition = belowPositionWRTLocation(x);
            if (belowPosition >= 0)
            {
                int arrayPosition = x;
                if (this.cardsOnTable[belowPosition] == null) return false;
                else
                {
                    if (this.cardsOnTable[belowPosition].upValue < this.cardsOnTable[arrayPosition].downValue)
                    {
                        this.cardsOnTable[belowPosition].setColor(whoPlayed.playerId);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkLeft(int x, Player whoPlayed)
        {
            int leftPosition = leftPositionWRTLocation(x);
            if (leftPosition >= 0)
            {
                int arrayPosition = x;
                if (this.cardsOnTable[leftPosition] == null) return false;
                else
                {
                    if (this.cardsOnTable[leftPosition].rightValue < this.cardsOnTable[arrayPosition].leftValue)
                    {
                        this.cardsOnTable[leftPosition].setColor(whoPlayed.playerId);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool checkRight(int x, Player whoPlayed)
        {
            int rightPosition = rightPositionWRTLocation(x);
            if (rightPosition >= 0)
            {
                int arrayPosition = x;
                if (this.cardsOnTable[rightPosition] == null) return false;
                else
                {
                    if (this.cardsOnTable[rightPosition].leftValue < this.cardsOnTable[arrayPosition].rightValue)
                    {
                        this.cardsOnTable[rightPosition].setColor(whoPlayed.playerId);
                        return true;
                    }
                }
            }
            return false;
        }

        private void removeFromHandCard( int positionInHandOfPlayedCard, Player whoPlayed)
        {
            whoPlayed.hand[positionInHandOfPlayedCard] = null;
        }

        public int checkWinningId()
        {
            int[] colorsToCheck = getColors();
            int blue = 0;
            int red = 0;
            int i = 0;
            for (i = 0; i < colorsToCheck.Length; i++){
                if(colorsToCheck[i] == Const.RED ){
                    red++;
                } else if (colorsToCheck[i] == Const.BLUE){
                        blue++;
                }
            }
            if(blue>red){
                return Const.BLUE;
            } else if (red>blue){
                return Const.RED;
            } else return Const.TIE;
        }

        private int[] getColors()
        {
            int[] colorsOnTable = new int[Const.PLACES_ON_TABLE];
            for (int i = 0; i < cardsOnTable.Length; i++)
            {
                colorsOnTable[i] = cardsOnTable[i].getColor();
            }

            return colorsOnTable;
        }

    }
}
