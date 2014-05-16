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
    public partial class Page1 : PhoneApplicationPage
    {
        private TranslateTransform dragTranslation;
        private TranslateTransform originalTranslation;
    

        public Page1()
        {
      
            InitializeComponent();
            Card1.Source = new ImageSourceConverter().ConvertFromString("/Assets/ImagesCards/Card1Blue.png") as ImageSource;

            
            //Card1.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Drag_ManipulationDelta);
            //Card1.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(Drag_ManipulationCompleted);
            //Card1.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Drag_ManipulationStarted);

            //dragTranslation = new TranslateTransform();
            //originalTranslation = new TranslateTransform();

           


            
        }

        private void MouseMoving(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(Image))
            {
                Image realSender = (Image)sender;
                Canvas.SetZIndex(realSender, 32);
            }
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
       
    }
}