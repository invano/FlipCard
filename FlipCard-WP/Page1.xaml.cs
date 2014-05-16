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
        private TranslateTransform dragTranslation;
        private TranslateTransform originalTranslation;
        private CardInfo[] cards = new CardInfo[8];

        public Page1()
        {

            InitializeComponent();
            cards[0].img = Card0;
            cards[0].name = "Card0";
            cards[1].img = Card1;
            cards[1].name = "Card1";

            Card0.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card1Blue.png") as ImageSource;
            Card1.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card1Red.png") as ImageSource;


            //Card1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Drag_ManipulationDelta);
            //Card1.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(Drag_ManipulationCompleted);
            //Card1.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Drag_ManipulationStarted);

            //dragTranslation = new TranslateTransform();
            //originalTranslation = new TranslateTransform();





        }

        private void MouseMoving(object sender, MouseEventArgs e)
        {
            //if (sender.GetType() == typeof(Image))
            //{
            //    Image realSender = (Image)sender;
            //    Canvas.SetZIndex(realSender, 32);
            //}
        }


        private void Drag_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            dragTranslation = new TranslateTransform();
            originalTranslation = new TranslateTransform();

            Image card1 = (Image)sender;
            card1.RenderTransform = this.dragTranslation;
        }

        private void Drag_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            // Reset rectangle.
            Image card1 = (Image)sender;
            card1.RenderTransform = this.originalTranslation;


            MessageBox.Show("Dude " + (originalTranslation.X + dragTranslation.X));

            dragTranslation.X = originalTranslation.X;
            dragTranslation.Y = originalTranslation.Y;
        }

        void Drag_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the rectangle.
            dragTranslation.X += e.DeltaManipulation.Translation.X;
            dragTranslation.Y += e.DeltaManipulation.Translation.Y;
        }

        private void Card_Tap(object sender, GestureEventArgs e)
        {
            Image img = (Image)sender;
            TranslateTransform translation = new TranslateTransform();
            for (int i = 0; i < 7; i++)
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
                        for (int j = 0; j < 7; j++)
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

    }
}