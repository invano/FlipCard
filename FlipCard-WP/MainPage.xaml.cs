using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FlipCard_WP.Resources;

namespace FlipCard_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            Storyboard_ButtonsDown.Begin();
            Menu_In.Begin();
            SBBG.Begin();
        }


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
            
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void Prova2_Tap(object sender, RoutedEventArgs e)
        {
            PlayPressedAnimation.Begin();
            //NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

        private void Regole_Tap(object sender, RoutedEventArgs e)
        {
            RulesPressedAnimation.Begin();
           // NavigationService.Navigate(new Uri("/Regole.xaml", UriKind.Relative));
        }

        private void ginobutton_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("You are holding me down :(");
        }

        private void aboutUs_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
         //   NavigationService.Navigate(new Uri("/AboutUs.xaml", UriKind.Relative));
            Storyboard2.Begin();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Storyboard2.Seek(new TimeSpan(0));
            Storyboard2.Stop();
            RulesPressedAnimation.Seek(new TimeSpan(0));
            RulesPressedAnimation.Stop();
            PlayPressedAnimation.Seek(new TimeSpan(0));
            PlayPressedAnimation.Stop();
 	        base.OnNavigatedTo(e);
            while (NavigationService.RemoveBackEntry() != null) ;
           
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
   
            
            base.OnNavigatedFrom(e);
            
        }

        private void Storyboard2_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutUs.xaml", UriKind.Relative));
            
        }

        private void SBBG_Completed(object sender, EventArgs e)
        {
            SBBG.Seek(new TimeSpan(0));
            SBBG.Begin();
        }

        private void RulesPressedAnimation_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Regole.xaml", UriKind.Relative));
        }

        private void PlayPressedAnimation_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }

    }
}