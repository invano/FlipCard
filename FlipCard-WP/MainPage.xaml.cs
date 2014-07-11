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
using System.IO.IsolatedStorage;

namespace FlipCard_WP
{
    public partial class MainPage : PhoneApplicationPage


    {

        IsolatedStorageSettings appStats = IsolatedStorageSettings.ApplicationSettings;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
            Storyboard_ButtonsDown.Begin();
            Menu_In.Begin();
          //  int myBest = (int)appStats["Best"];
           // this.progressBar.Value = ((myBest / 13090) * 100);
           // ProgressBarIn.Begin();
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

        private void Play_Tap(object sender, RoutedEventArgs e)
        {
            //At the end of the animation the proper target page is fired up
            PlayPressedAnimation.Begin();
            ProgressBarOut.Begin();
        }

        private void Rules_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //At the end of the animation the proper target page is fired up
            RulesPressedAnimation.Begin();
            ProgressBarOut.Begin();
        }

        private void btn_stats_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            StatsPressedAnimation.Begin();
            ProgressBarOut.Begin();

        }

        private void button_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {
           

            MessageBox.Show("You are holding me down :(");
            
            //Cancel this before deployement
            appStats["Stars"] = 0;
            appStats["Row"] = 0;
            appStats["Wins"] = 0;
            appStats["Losses"] = 0;
            appStats["Ties"] = 0;
            appStats["Best"] = 0;
           
        }

        private void aboutUs_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //At the end of the animation the proper target page is fired up
            AboutUsPressedAnimation.Begin();
            ProgressBarOut.Begin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
            AboutUsPressedAnimation.Seek(new TimeSpan(0));
            AboutUsPressedAnimation.Stop();
            RulesPressedAnimation.Seek(new TimeSpan(0));
            RulesPressedAnimation.Stop();
            PlayPressedAnimation.Seek(new TimeSpan(0));
            PlayPressedAnimation.Stop();
            StatsPressedAnimation.Seek(new TimeSpan(0));
            StatsPressedAnimation.Stop();
            
         
            FadeInMenu.Begin();
            //update bottom bar value
            float myBest = (int)appStats["Best"];
            myBest = ((myBest / 13090) * 100);
            this.progressBar.Value = (int)myBest;

            //make bottom bar appear
            ProgressBarIn.Begin(); 
            ProgressBarOut.Stop();

 	        base.OnNavigatedTo(e);
            while (NavigationService.RemoveBackEntry() != null) ;    
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void AboutUsPressedAnimation_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/AboutUs.xaml", UriKind.Relative));
        }

        private void RulesPressedAnimation_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Rules.xaml", UriKind.Relative));
        }

        private void PlayPressedAnimation_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/RandomGame.xaml", UriKind.Relative));
        }

        private void StatsPressedAnimation_Completed(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Statistics.xaml", UriKind.Relative));
        }

        private void setMyBest(object sender, System.Windows.Input.GestureEventArgs e)
        {
            appStats["Best"] = 3333;
        }
    }
}