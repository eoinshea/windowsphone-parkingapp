using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Tally
{
    public partial class ParkingSpotPage : PhoneApplicationPage
    {
        public ParkingSpotPage()
        {
            InitializeComponent();
            // create the task 
           

        }

        private void OpenBingMaps(object sender, RoutedEventArgs e)
        {
            var task = new BingMapsTask()
            {
               //SearchTerm = "restaurants",
                Center = new System.Device.Location.GeoCoordinate(App.selectedSpaceGeolocation.Latitude, App.selectedSpaceGeolocation.Longitude),
                ZoomLevel = 13.000
            };

            // try to show the task // (may fail if searchTerm = coordinate = null) 
            try
            {
                task.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while showing task: " + ex.Message);
            }
        }
    }
}