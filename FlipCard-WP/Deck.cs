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
        public Card[] cardArray;


        public void setDeck(Card[] deck ) {

            deck.CopyTo(this.cardArray, this.no_cards);
        }

        public Card[] getDeck() {
            return this.cardArray;
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
                i = new Random().Next(0, this.no_cards + 1);
                return this.cardArray[i];
            }
            return null;

        }
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
        /*public void addCardtoDeck (Card cardToAdd)
         * {       }*/

       /* public void addCardstoDeck()
        {        }*/
    }
}
