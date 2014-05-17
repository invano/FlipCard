
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FlipCard_WP
{
    class CPUBrain
    {
        static int positionsTotal= Const.PLACES_ON_TABLE;

        public static PositionAndCard generateMoveWithModel(Game myModelGame, Player player) {

            int score= Const.MIN_SCORE;
            int positionOnTable = 0;
            int cardInHand = 0;
            int i = 0;

            for(i = 0; i < positionsTotal; i++){
                if(myModelGame.cardsOnTable[i] == null){
                
                    //check various cards in position
                    int y = 0;
                    for(y = 0; y < player.hand.Length; y++){
                        if (player.hand[y] == null) {
                            continue;
                        }
                        int sum = 0;
                        int win = 0;
                        Card actualCardInHandChecked = player.hand[y];
                        
                    
                        //check above
                        int abovePosition = myModelGame.abovePositionWRTLocation(i);
                        if(abovePosition >= 0){

                            if(myModelGame.cardsOnTable[abovePosition] == null){
                                sum += (actualCardInHandChecked.upValue - 2);
                            } else {

                                Card aboveCard = myModelGame.cardsOnTable[abovePosition];
                                if((aboveCard.isRed() && player.isRed()) || (!aboveCard.isRed() && player.isBlue())){
                                    //My card adj
                                    sum -= (actualCardInHandChecked.upValue + 2);
                                } else {
                                    if(aboveCard.downValue >= actualCardInHandChecked.upValue){
                                    //Will Lose!
                                    sum = sum - Const.WILL_LOSE_FACTOR_NEGATIVE*(actualCardInHandChecked.upValue + aboveCard.downValue);
                                    } else {
                                    //Will win
                                    sum = sum - actualCardInHandChecked.upValue + (Const.MULTIPLY_WINNING_FACTOR*aboveCard.downValue) + 2;
                                    win++;
                                    }
                                }
                            }
                        
                        } else
                            sum -= (actualCardInHandChecked.upValue + 2);
                    
                        //check below
                        int belowPosition = myModelGame.belowPositionWRTLocation(i);
                        if(belowPosition >= 0){
                            if(myModelGame.cardsOnTable[belowPosition] == null){
                                sum += (actualCardInHandChecked.downValue - 2);
                            } else {
                                Card belowCard = myModelGame.cardsOnTable[belowPosition];
                                if((belowCard.isRed() && player.isRed()) || (!belowCard.isRed() && player.isBlue())){
                                    sum -= (actualCardInHandChecked.downValue + 2);
                                } else {
                                    if(belowCard.upValue >= actualCardInHandChecked.downValue){
                                        sum = sum - Const.WILL_LOSE_FACTOR_NEGATIVE*actualCardInHandChecked.downValue + belowCard.upValue;
                                    } else {
                                        sum = sum - actualCardInHandChecked.downValue + Const.MULTIPLY_WINNING_FACTOR*belowCard.upValue + 2;
                                        win++;
                                    }
                                }
                            }
                        
                        } else sum -= (actualCardInHandChecked.downValue + 2);
                    
                 
                        //check left
                        int leftPosition = myModelGame.leftPositionWRTLocation(i);
                        if(leftPosition >= 0){
                            if(myModelGame.cardsOnTable[leftPosition] == null){
                                sum+=(actualCardInHandChecked.leftValue - 2);
                            } else {
                                Card leftCard = myModelGame.cardsOnTable[leftPosition];
                                if((leftCard.isRed() && player.isRed()) || (!leftCard.isRed() && player.isBlue())){
                                    sum -= (actualCardInHandChecked.leftValue + 2);
                                } else {
                                    if(leftCard.rightValue >= actualCardInHandChecked.leftValue){
                                        sum = sum - Const.WILL_LOSE_FACTOR_NEGATIVE*actualCardInHandChecked.leftValue + leftCard.rightValue;
                                    } else {
                                        sum = sum - actualCardInHandChecked.leftValue + Const.MULTIPLY_WINNING_FACTOR*leftCard.rightValue + 2;
                                        win++;
                                    }
                                }
                            }
                        } else
                            sum -= (actualCardInHandChecked.leftValue + 2);
                    
                        //check right
                        int rightPosition = myModelGame.rightPositionWRTLocation(i);
                        if(rightPosition >= 0){
                            if(myModelGame.cardsOnTable[rightPosition] == null){
                                sum += (actualCardInHandChecked.rightValue - 2);
                            } else {
                                Card rightCard = myModelGame.cardsOnTable[rightPosition];
                                if((rightCard.isRed() && player.isRed()) || (!rightCard.isRed() && player.isBlue())){
                                    sum -= (actualCardInHandChecked.rightValue + 2);
                                } else {
                                    if(rightCard.leftValue >= actualCardInHandChecked.rightValue){
                                        sum = sum - Const.WILL_LOSE_FACTOR_NEGATIVE*actualCardInHandChecked.rightValue + rightCard.leftValue;
                                    } else {
                                        sum = sum - actualCardInHandChecked.rightValue + Const.MULTIPLY_WINNING_FACTOR*rightCard.leftValue + 2;
                                        win++;
                                    }
                                }
                            }
                        
                        } else
                            sum -= (actualCardInHandChecked.rightValue + 2);
                    
                        sum = sum + Const.COMBO_MULTIPLY_FACTOR*win;
                        //compare with Score
                        if (sum>score){
                            score = sum;
                            cardInHand = y;
                            positionOnTable = i;
                        }
                    }
                }
            }
            return new PositionAndCard(positionOnTable, cardInHand);
        }

    }

    public class PositionAndCard
    {
        int positionInHand;
        int cardInHand;

        public PositionAndCard(int pos, int card)
        {
            this.positionInHand = pos;
            this.cardInHand = card;
        }
        public void setPosition(int pos)
        {
            this.positionInHand = pos;
        }

        public int getPosition()
        {
            return this.positionInHand;
        }

        public void setCard(int card)
        {
            this.cardInHand = card;
        }

        public int getCard()
        {
            return this.cardInHand;
        }
    }
}
