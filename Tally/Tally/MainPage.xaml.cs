using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using BitcoinAPIaccess;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Bitcoin.Models;
using Tally.Models;
using System.Windows.Navigation;

namespace Tally
{
    public partial class MainPage : PhoneApplicationPage
    {
		
        // Constructor
        public MainPage()
        {
            InitializeComponent();
          
            // Process the data here
        }





        //protected override void OnNavigatedFrom(NavigationEventArgs e)
        //{
        //    PageFlickClose.Begin();
        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PageFlickOpen.Begin();
           // CrazySpin.Begin();
        }




        private void SearchSpacesButtonClickPivot(object sender, RoutedEventArgs e)
        {
            PageFlickClose.Begin();
            this.NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
        }

        private void SearchSpacesButtonClickPanorama(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/PanoramaPage1.xaml", UriKind.Relative));
        }







     


    }

            
}