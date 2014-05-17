using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class CardsLibrary
    {

        public Card[] CommonCardsInLibrary;
        public Card[] SilverCardsInLibrary;
        public Card[] GoldCardsInLibrary;


        public CardsLibrary(String libraryName)
        {
            Card card0 = new Card();
            card0.idNumber =0;
            card0.upValue = 1;
            card0.downValue = 1;
            card0.leftValue = 1;
            card0.rightValue = 4;
            card0.rarityType = Const.COMMON;

            Card card1 = new Card();
            card1.idNumber = 1;
            card1.upValue = 1;
            card1.downValue = 1;
            card1.leftValue = 4;
            card1.rightValue = 1;
            card1.rarityType = Const.COMMON;

            Card card2 = new Card();
            card2.idNumber = 2;
            card2.upValue = 4;
            card2.downValue = 1;
            card2.leftValue = 1;
            card2.rightValue = 1;
            card2.rarityType = Const.COMMON;

            Card card3 = new Card();
            card3.idNumber = 3;
            card3.upValue = 1;
            card3.downValue = 4;
            card3.leftValue = 1;
            card3.rightValue = 1;
            card3.rarityType = Const.COMMON;

            Card card4 = new Card();
            card4.idNumber = 4;
            card4.upValue = 1;
            card4.downValue = 3;
            card4.leftValue = 2;
            card4.rightValue = 1;
            card4.rarityType = Const.COMMON;

            Card card5 = new Card();
            card5.idNumber = 5;
            card5.upValue = 1;
            card5.downValue = 2;
            card5.leftValue = 3;
            card5.rightValue = 1;
            card5.rarityType = Const.COMMON;

            Card card6 = new Card();
            card6.idNumber = 6;
            card6.upValue = 3;
            card6.downValue = 1;
            card6.leftValue = 2;
            card6.rightValue = 1;
            card6.rarityType = Const.COMMON;

            Card card7 = new Card();
            card7.idNumber = 7;
            card7.upValue = 2;
            card7.downValue = 1;
            card7.leftValue = 1;
            card7.rightValue = 3;
            card7.rarityType = Const.COMMON;

            Card card8 = new Card();
            card8.idNumber = 8;
            card8.upValue = 1;
            card8.downValue = 1;
            card8.leftValue = 2;
            card8.rightValue = 3;
            card8.rarityType = Const.COMMON;

            Card card9 = new Card();
            card9.idNumber = 9;
            card9.upValue = 3;
            card9.downValue = 2;
            card9.leftValue = 1;
            card9.rightValue = 1;
            card9.rarityType = Const.COMMON;

            Card card10 = new Card();
            card10.idNumber = 10;
            card10.upValue = 1;
            card10.downValue = 1;
            card10.leftValue = 3;
            card10.rightValue = 2;
            card10.rarityType = Const.COMMON;

            Card card11 = new Card();
            card11.idNumber = 11;
            card11.upValue = 2;
            card11.downValue = 3;
            card11.leftValue = 1;
            card11.rightValue = 1;
            card11.rarityType = Const.COMMON;

            Card card12 = new Card();
            card12.idNumber = 12;
            card12.upValue = 3;
            card12.downValue = 3;
            card12.leftValue = 2;
            card12.rightValue = 1;
            card12.rarityType = Const.SILVER;

            Card card13 = new Card();
            card13.idNumber = 13;
            card13.upValue = 2;
            card13.downValue = 1;
            card13.leftValue = 3;
            card13.rightValue = 3;
            card13.rarityType = Const.SILVER;

            Card card14 = new Card();
            card14.idNumber = 14;
            card14.upValue = 3;
            card14.downValue = 3;
            card14.leftValue = 1;
            card14.rightValue = 2;
            card14.rarityType = Const.SILVER;

            Card card15 = new Card();
            card15.idNumber = 15;
            card15.upValue = 1;
            card15.downValue = 2;
            card15.leftValue = 3;
            card15.rightValue = 3;
            card15.rarityType = Const.SILVER;

            Card card16 = new Card();
            card16.idNumber = 16;
            card16.upValue = 4;
            card16.downValue = 1;
            card16.leftValue = 3;
            card16.rightValue = 1;
            card16.rarityType = Const.SILVER;

            Card card17 = new Card();
            card17.idNumber = 17;
            card17.upValue = 3;
            card17.downValue = 1;
            card17.leftValue = 1;
            card17.rightValue = 4;
            card17.rarityType = Const.SILVER;

            Card card18 = new Card();
            card18.idNumber = 18;
            card18.upValue = 1;
            card18.downValue = 4;
            card18.leftValue = 1;
            card18.rightValue = 3;
            card18.rarityType = Const.SILVER;

            Card card19 = new Card();
            card19.idNumber = 19;
            card19.upValue = 1;
            card19.downValue = 3;
            card19.leftValue = 4;
            card19.rightValue = 1;
            card19.rarityType = Const.SILVER;

            Card card20 = new Card();
            card20.idNumber = 20;
            card20.upValue = 4;
            card20.downValue = 2;
            card20.leftValue = 1;
            card20.rightValue = 1;
            card20.rarityType = Const.SILVER;

            Card card21 = new Card();
            card21.idNumber = 21;
            card21.upValue = 1;
            card21.downValue = 2;
            card21.leftValue = 2;
            card21.rightValue = 4;
            card21.rarityType = Const.SILVER;

            Card card22 = new Card();
            card22.idNumber = 22;
            card22.upValue = 2;
            card22.downValue = 4;
            card22.leftValue = 2;
            card22.rightValue = 1;
            card22.rarityType = Const.SILVER;

            Card card23 = new Card();
            card23.idNumber = 23;
            card23.upValue = 2;
            card23.downValue = 1;
            card23.leftValue = 4;
            card23.rightValue = 2;
            card23.rarityType = Const.SILVER;

            Card card24 = new Card();
            card24.idNumber = 24;
            card24.upValue = 6;
            card24.downValue = 1;
            card24.leftValue = 2;
            card24.rightValue = 1;
            card24.rarityType = Const.Gold;

            Card card25 = new Card();
            card25.idNumber = 25;
            card25.upValue = 2;
            card25.downValue = 1;
            card25.leftValue = 1;
            card25.rightValue = 6;
            card25.rarityType = Const.Gold;

            Card card26 = new Card();
            card26.idNumber = 26;
            card26.upValue = 2;
            card26.downValue = 6;
            card26.leftValue = 1;
            card26.rightValue = 2;
            card26.rarityType = Const.Gold;

            Card card27 = new Card();
            card27.idNumber = 27;
            card27.upValue = 1;
            card27.downValue = 2;
            card27.leftValue = 6;
            card27.rightValue = 1;
            card27.rarityType = Const.Gold;

            Card card28 = new Card();
            card28.idNumber = 28;
            card28.upValue = 5;
            card28.downValue = 1;
            card28.leftValue = 3;
            card28.rightValue = 2;
            card28.rarityType = Const.Gold;

            Card card29 = new Card();
            card29.idNumber = 29;
            card29.upValue = 3;
            card29.downValue = 2;
            card29.leftValue = 1;
            card29.rightValue = 5;
            card29.rarityType = Const.Gold;

            Card card30 = new Card();
            card30.idNumber = 30;
            card30.upValue = 1;
            card30.downValue = 5;
            card20.leftValue = 2;
            card30.rightValue = 3;
            card30.rarityType = Const.Gold;

            Card card31 = new Card();
            card31.idNumber = 31;
            card31.upValue = 2;
            card31.downValue = 3;
            card31.leftValue = 5;
            card31.rightValue = 1;
            card31.rarityType = Const.Gold;

            Card card32 = new Card();
            card32.idNumber = 32;
            card32.upValue = 4;
            card32.downValue = 4;
            card32.leftValue = 4;
            card32.rightValue = 1;
            card32.rarityType = Const.Gold;

            Card card33 = new Card();
            card33.idNumber = 33;
            card33.upValue = 4;
            card33.downValue = 1;
            card33.leftValue = 4;
            card33.rightValue = 4;
            card33.rarityType = Const.Gold;

            Card card34 = new Card();
            card34.idNumber = 34;
            card34.upValue = 4;
            card34.downValue = 4;
            card34.leftValue = 1;
            card34.rightValue = 4;
            card34.rarityType = Const.Gold;

            Card card35 = new Card();
            card35.idNumber = 35;
            card35.upValue = 1;
            card35.downValue = 4;
            card35.leftValue = 4;
            card35.rightValue = 4;
            card35.rarityType = Const.Gold;

            List<Card> tmpCommonList = new List<Card>(Const.APPROXIMATE_CARDSNUMBER);
            List<Card> tmpSilverList = new List<Card>(Const.APPROXIMATE_CARDSNUMBER);
            List<Card> tmpGoldList = new List<Card>(Const.APPROXIMATE_CARDSNUMBER);

            tmpCommonList.Add(card0);
            tmpCommonList.Add(card1);
            tmpCommonList.Add(card2);
            tmpCommonList.Add(card3);
            tmpCommonList.Add(card4);
            tmpCommonList.Add(card5);
            tmpCommonList.Add(card6);
            tmpCommonList.Add(card7);
            tmpCommonList.Add(card8);
            tmpCommonList.Add(card9);
            tmpCommonList.Add(card10);
            tmpCommonList.Add(card11);
            tmpSilverList.Add(card12);
            tmpSilverList.Add(card13);
            tmpSilverList.Add(card14);
            tmpSilverList.Add(card15);
            tmpSilverList.Add(card16);
            tmpSilverList.Add(card17);
            tmpSilverList.Add(card18);
            tmpSilverList.Add(card19);
            tmpSilverList.Add(card20);
            tmpSilverList.Add(card21);
            tmpSilverList.Add(card22);
            tmpSilverList.Add(card23);
            tmpGoldList.Add(card24);
            tmpGoldList.Add(card25);
            tmpGoldList.Add(card26);
            tmpGoldList.Add(card27);
            tmpGoldList.Add(card28);
            tmpGoldList.Add(card29);
            tmpGoldList.Add(card30);
            tmpGoldList.Add(card31);
            tmpGoldList.Add(card32);
            tmpGoldList.Add(card33);
            tmpGoldList.Add(card34);
            tmpGoldList.Add(card35);

            CommonCardsInLibrary = tmpCommonList.ToArray();
            SilverCardsInLibrary = tmpSilverList.ToArray();
            GoldCardsInLibrary = tmpGoldList.ToArray();

        }

        public Deck generateRandomDeckWithSize( int size)
        {
            int intsize = size;
    
            if (intsize < 18) {
                return -1;
            }
    
            Deck myRandomDeck = new Deck();
    
            int i = 0;
            Random rgn = new Random();
            int goldNumber = Math.Round(intsize / Const.GOLD_RARITY_PROBABILITY_DIVIDER);
            for (i = 0; i < goldNumber; i++) {
                int casualGoldPosition = rgn.Next() % this.GoldCardsInLibrary.Count;
                myRandomDeck.addCardToDeck(this.GoldCardsInLibrary[casualGoldPosition]);
            }
    
            int silverNumber = Math.Round(intsize / Const.SILVER_RARITY_PROBABILITY_DIVIDER);
            for (i = 0; i < silverNumber; i++) {
                int casualSilverPosition = rgn.Next() % this.SilverCardsInLibrary.Count;
                myRandomDeck.addCardToDeck(this.SilverCardsInLibrary[casualSilverPosition]);

            }
    
            int commonNumber = intsize - goldNumber - silverNumber;
            for (i=0; i<commonNumber; i++) {
                int casualCommonPosition = rgn.Next() % this.CommonCardsInLibrary.Count;
                myRandomDeck.addCardToDeck(this.CommonCardsInLibrary[casualCommonPosition]);
            }
            return myRandomDeck;
        }
    }
}
