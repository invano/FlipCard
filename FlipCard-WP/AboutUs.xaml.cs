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

namespace FlipCard_WP
{
    public partial class Page2 : PhoneApplicationPage
    {
        private TranslateTransform dragTranslation;

        public Page2()
        {
            InitializeComponent();
            TestRectangle.ManipulationDelta += new EventHandler<ManipulationDeltaEventArgs>(Drag_ManipulationDelta);
            dragTranslation = new TranslateTransform();
            TestRectangle.RenderTransform = this.dragTranslation;
        }

        void Drag_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the rectangle.
            dragTranslation.X += e.DeltaManipulation.Translation.X;
            dragTranslation.Y += e.DeltaManipulation.Translation.Y;
        }
    }
}