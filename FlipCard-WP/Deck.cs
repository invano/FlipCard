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
        public void shuffle() {




        }

    }
}
