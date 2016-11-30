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
using Newtonsoft.Json.Linq;
using Tally.Models;
using Newtonsoft.Json;
using System.Device.Location;
using System.Windows.Navigation;

namespace Tally
{
    public partial class PivotPage1 : PhoneApplicationPage
    {

        ParkingJSON_Helpers JSONhelpers = new ParkingJSON_Helpers();
        //Initialize page
        public PivotPage1()
        {
            InitializeComponent();
            JSONhelpers.setParkingDataList();
            JSONhelpers.setDummyFavourites();
            ParkingSpaceListBox.ItemsSource = JSONhelpers.listParkingData;
            FavouritesListBox.ItemsSource = JSONhelpers.listFavourites;
         
            //MessageBox.Show(JSONhelpers.listParkingData[0].location);
        }

        private void GoToParkingSpotPage(object sender, GestureEventArgs e)
        {
            //ListBoxItem selectedItem = this.JSONhelpers.listParkingData;.ItemContainerGenerator.ContainerFromItem(this.JSONhelpers.listParkingData;.SelectedItem) as ListBoxItem;
            PageFlickClose.Begin();
            this.NavigationService.Navigate(new Uri("/ParkingSpotPage.xaml", UriKind.Relative));
        }

        private void refresh(object sender, EventArgs e)
        {
            ParkingSpaceListBox.ItemsSource = JSONhelpers.listParkingData;
        }

        private void getlocation(object sender, EventArgs e)
        {
            if (JSONhelpers.listParkingData.Count() > 0)
            {
                ParkingSpaceListBox.ItemsSource = JSONhelpers.listParkingData;
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            PageFlickOpen.Begin();
        }

    }
}