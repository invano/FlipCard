using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace FlipCard_WP
{
    public partial class Statistics_Page : PhoneApplicationPage
    {
        IsolatedStorageSettings appStats = IsolatedStorageSettings.ApplicationSettings;

        public Statistics_Page()
        {
            InitializeComponent();
            StartAnimation.Begin();

            stats_block_W.Text = "Victories = " + appStats["Wins"] + "\n";
            stats_block_L.Text = "Losses = " + appStats["Losses"] + "\n";
            stats_block_T.Text = "Ties = " + appStats["Ties"] + "\n";
            stats_block_B.Text = "MyBest = " + appStats["Best"] + "\n";

            int starstmp = (int)appStats["Stars"];
            clearStars();
            setStars(starstmp); //must be five

        }

        void setStars(int starstmp)
        {
            switch (starstmp)
            {
                case 0:
                    break;
                case 1:
                    setStar1();
                    break;
                case 2:
                    setStar1();
                    setStar2();
                    break;
                case 3:
                    setStar1();
                    setStar2();
                    setStar3();
                    break;
                case 4:
                    setStar1();
                    setStar2();
                    setStar3();
                    setStar4();
                    break;
                case 5:
                    setStar1();
                    setStar2();
                    setStar3();
                    setStar4();
                    setStar5();
                    break;
            }
        }

        void clearStars()
        {
            star1.Visibility = Visibility.Collapsed;
            star2.Visibility = Visibility.Collapsed;
            star3.Visibility = Visibility.Collapsed;
            star4.Visibility = Visibility.Collapsed;
            star5.Visibility = Visibility.Collapsed;
        }

        void setStar1()
        {
            star1.Visibility = Visibility.Visible;
        }
        void setStar2()
        {
            star2.Visibility = Visibility.Visible;
        }
        void setStar3()
        {
            star3.Visibility = Visibility.Visible;
        }
        void setStar4()
        {
            star4.Visibility = Visibility.Visible;
        }
        void setStar5()
        {
            star5.Visibility = Visibility.Visible;
        }
    }

}