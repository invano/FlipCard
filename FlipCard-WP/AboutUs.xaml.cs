using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FlipCard_WP
{
    public partial class Page2 : PhoneApplicationPage
    {
        private TranslateTransform dragTranslation;
        private TranslateTransform originalTranslation;

        public Page2()
        {
            InitializeComponent();
            TestRectangle.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Drag_ManipulationDelta);
            TestRectangle.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(Drag_ManipulationCompleted);
            TestRectangle.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Drag_ManipulationStarted);

            dragTranslation = new TranslateTransform();
            originalTranslation = new TranslateTransform();

            TestRectangle2.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Drag_ManipulationDelta);
            TestRectangle2.ManipulationCompleted += new EventHandler<ManipulationCompletedEventArgs>(Drag_ManipulationCompleted);
            TestRectangle2.ManipulationStarted += new EventHandler<ManipulationStartedEventArgs>(Drag_ManipulationStarted);

            
        }

        private void Drag_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            dragTranslation = new TranslateTransform();
            originalTranslation = new TranslateTransform();
            Rectangle rect = (Rectangle)sender;
            rect.RenderTransform = this.dragTranslation;
        }

        private void Drag_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            // Reset rectangle.
            Rectangle rect = (Rectangle)sender;
            rect.RenderTransform = this.originalTranslation;

            //dragTranslation.X = originalTranslation.X;
            //dragTranslation.Y = originalTranslation.Y;
        }

        void Drag_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the rectangle.
            dragTranslation.X += e.DeltaManipulation.Translation.X;
            dragTranslation.Y += e.DeltaManipulation.Translation.Y;
        }
    }
}