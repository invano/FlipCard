using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class Deck
    {
        int no_cards;
        public List<Card> cardArray;
        Random rgn;

        public Deck()
        {
            cardArray = new List<Card>();
            rgn = new Random();
        }

        public void setDeck(Card[] deck ) {

            cardArray = new List<Card>(deck) ;
        }

        public Card[] getDeck()
        {
            return this.cardArray.ToArray();
        }
                
        public void set_no_cards(int no_cards) {
            this.no_cards = no_cards;
        }

        public int get_no_cards() {
            return this.no_cards;
        }

        public Card getRandomCard() {
            int i = 0;
            if (this.no_cards != 0)
            {
               i = rgn.Next(0, this.no_cards - 1);
               return this.cardArray[i];
            }
      
            return null;

        }
        
        public void addCardToDeck (Card cardToAdd)
        {
            Card newCard = new Card();
            newCard.clone(cardToAdd);
            cardArray.Add(newCard);
        }

        public void addCardstoDeck()
        {
        }
    }

 static class DeckShuffle
{
     public static void Shuffle<T>(this IList<T> list)
     {
         Random rng = new Random();
         int n = list.Count;
         while (n > 1)
         {
             n--;
             int k = rng.Next(n + 1);
             T value = list[k];
             list[k] = list[n];
             list[n] = value;
         }
     }
}
}