using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Input;

namespace FlipCard_WP
{

    public struct CardInfo
    {
        public string name;

        public Image img;
        public string source;
        public bool isUp;
    }

    public partial class Page1 : PhoneApplicationPage
    {
        private CardInfo[] cards = new CardInfo[8];
        

        public Page1()
        {

            InitializeComponent();

            


            cards[0].img = Card0;
            cards[0].name = "Card0";
            cards[1].img = Card1;
            cards[1].name = "Card1";
            cards[2].img = Card2;
            cards[2].name = "Card2";
            cards[3].img = Card3;
            cards[3].name = "Card3";
            cards[4].img = Card4;
            cards[4].name = "Card4";
            cards[5].img = Card5;
            cards[5].name = "Card5";
            cards[6].img = Card6;
            cards[6].name = "Card6";
            cards[7].img = Card7;
            cards[7].name = "Card7";


            Card0.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card0Red.png") as ImageSource;
            Card1.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card1Red.png") as ImageSource;
            Card2.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card2Red.png") as ImageSource;
            Card3.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card3Red.png") as ImageSource;
            Card4.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card4Red.png") as ImageSource;
            Card5.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card5Red.png") as ImageSource;
            Card6.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card6Red.png") as ImageSource;
            Card7.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card7Red.png") as ImageSource;

        }

        private void Card_Tap(object sender, GestureEventArgs e)
        {
            Image img = (Image)sender;
            TranslateTransform translation;
            translation = new TranslateTransform();


            Card cardigan = new Card();
            cardigan.setColor(2);
            cardigan.idNumber = 3;
            updateHand(2, cardigan);

            for (int i = 0; i < cards.Length; i++)
            {
                if (img.Name.Equals(cards[i].name))
                {
                    if (cards[i].isUp)
                    {
                        img.RenderTransform = translation;
                        translation.Y += 0;
                        cards[i].isUp = false;

                    }
                    else
                    {
                        for (int j = 0; j < cards.Length; j++)
                        {
                            if (cards[j].isUp)
                            {
                                Image img2 = cards[j].img;
                                TranslateTransform translation2 = new TranslateTransform();
                                img2.RenderTransform = translation2;
                                translation2.Y += 0;
                                cards[j].isUp = false;
                            }
                        }
                            img.RenderTransform = translation;
                        translation.Y -= 20;
                        cards[i].isUp = true;
                    }
                }
            }

        }

        private void board_Tap(object sender, GestureEventArgs e)
        {
            int index=0;
            Image img = (Image)sender;

            for (int k = 0; k < cards.Length; k++)
            {               
                if (cards[k].isUp)
                {
                    string s = img.Name;
                   
                    string[] words = s.Split('c');
                    index = Convert.ToInt32(words[1]);

                    //TODO call controller
                }
            }
        }

        public void updateTiles(int index , Card newCard)
        {
            int tmp = newCard.idNumber;
            string targetSource = "/Assets/ImagesCards/Card" + tmp;
            if (newCard.isBlue()) targetSource += "Blue.png";
            else targetSource += "Red.png";

            string target = "c" + index;
            Image img = (Image)this.FindName(target);


            img.Source = new ImageSourceConverter().ConvertFromString(targetSource) as ImageSource;
            

        }

        public void updateHand(int index, Card newCard)
        {
            int tmp = newCard.idNumber;
            string targetSource = "/Assets/ImagesCards/Card" + tmp;
            if (newCard.isBlue()) targetSource += "Blue.png";
            else targetSource += "Red.png";

            string target = "Card" + index;

            Image img = (Image)this.FindName(target);

            img.RenderTransformOrigin = new Point(0.5, 0.5);
            ScaleTransform flipTrans = new ScaleTransform();
            flipTrans.ScaleX = -1;
            flipTrans.ScaleY = -1;
            img.RenderTransform = flipTrans;

            img.Source = new ImageSourceConverter().ConvertFromString(targetSource) as ImageSource;

        }

        public void hideFromHand(int index)
        {
            string target = "Card" + index;
            Image img = (Image)this.FindName(target);
            img.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}