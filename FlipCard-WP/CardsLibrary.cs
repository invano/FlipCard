using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace FlipCard_WP
{
    class CardsLibrary
    {

        public Card[] CommonCardsInLibrary;
        public Card[] SilverCardsInLibrary;
        public Card[] GoldCardsInLibrary;
        Random rgn = new Random();


        public CardsLibrary()
        {
            List<Card> tmpCommonList = new List<Card>();
            List<Card> tmpSilverList = new List<Card>();
            List<Card> tmpGoldList = new List<Card>();

            XDocument cardsLibraryXml = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("FlipCard_WP.CardsLibrary.xml"));

            foreach(XElement element in cardsLibraryXml.Descendants("card")) {
                
                Card card = new Card();
                card.idNumber = (int) element.Element("idNumber");
                card.upValue = (int) element.Element("up");
                card.downValue = (int) element.Element("down");
                card.leftValue = (int) element.Element("left");
                card.rightValue = (int) element.Element("right");
               
                switch (element.Element("rarity").Value) {
                    
                    case "Gold":
                        card.rarityType = Const.GOLD;
                        tmpGoldList.Add(card);
                        break;

                    case "Silver":
                        card.rarityType = Const.SILVER;
                        tmpSilverList.Add(card);
                        break;

                    case "Common":
                        card.rarityType = Const.COMMON;
                        tmpCommonList.Add(card);
                        break;
                }
                
            }

            CommonCardsInLibrary = tmpCommonList.ToArray();
            SilverCardsInLibrary = tmpSilverList.ToArray();
            GoldCardsInLibrary = tmpGoldList.ToArray();

        }

        public Deck generateRandomDeckWithSize( int size)
        {
            int intsize = size;
    
            if (intsize < 18) {
                return null;
            }
    
            Deck myRandomDeck = new Deck();
    
            int i = 0;
            
            int goldNumber = (intsize / Const.GOLD_RARITY_PROBABILITY_DIVIDER);
            for (i = 0; i < goldNumber; i++) {
                int casualGoldPosition = rgn.Next(0, this.GoldCardsInLibrary.Count());
               // int casualGoldPosition = rgn.Next() % this.GoldCardsInLibrary.Count();
                myRandomDeck.addCardToDeck(this.GoldCardsInLibrary[casualGoldPosition]);
            }

            int silverNumber = (intsize / Const.SILVER_RARITY_PROBABILITY_DIVIDER);
            for (i = 0; i < silverNumber; i++) {
                int casualSilverPosition = rgn.Next(0, this.SilverCardsInLibrary.Count());
               // int casualSilverPosition = rgn.Next() % this.SilverCardsInLibrary.Count();
                myRandomDeck.addCardToDeck(this.SilverCardsInLibrary[casualSilverPosition]);

            }
    
            int commonNumber = intsize - goldNumber - silverNumber;
            for (i=0; i<commonNumber; i++) {
                int casualCommonPosition = rgn.Next(0, this.CommonCardsInLibrary.Count());
                //int casualCommonPosition = rgn.Next() % this.CommonCardsInLibrary.Count();
                myRandomDeck.addCardToDeck(this.CommonCardsInLibrary[casualCommonPosition]);
            }
            return myRandomDeck;
        }
    }
}
