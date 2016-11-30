using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using Tally.Models;

namespace Tally
{
    public class ParkingJSON_Helpers
    {
        public List<ParkingDataItem> listParkingData;
        public List<ParkingDataItem> listFavourites;

         public ParkingJSON_Helpers()
        {
            listParkingData = new List<ParkingDataItem>();
            listFavourites  = new List<ParkingDataItem>();
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.Default)
            {
                MovementThreshold = 20
            };

            watcher.PositionChanged += this.watcher_PositionChanged;
            watcher.StatusChanged += this.watcher_StatusChanged;
            watcher.Start();
            //SetBusStopList();

            App.selectedSpaceGeolocation = new GeoCoordinate(watcher.Position.Location.Latitude, watcher.Position.Location.Latitude);
            MessageBox.Show(App.selectedSpaceGeolocation.Latitude.ToString() +","+ App.selectedSpaceGeolocation.Longitude.ToString());
            
        }


         public void setDummyFavourites()
         {
             int i;
             for(i=0;i!=5;i++)
             {
                listFavourites.Add(new ParkingDataItem("123","Dame Street","200","test","13","50","5"));
             }
         }

        

        public void setParkingDataList()
        {
            try
            {
                WebClient wc = new WebClient();

                string myUri = "http://mobileapi.parkya.com/v5/?lat=" + watcher.Position.Location.Latitude  + "&lon=" + watcher.Position.Location.Longitude+"&params=1&page=0&featured=0&tiid=e2f75e26c9259097e1ea68a22fa6b0f4073cf6&sortby=2&radius=1";


                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(myweb_DownloadStringCompleted);
                wc.DownloadStringAsync(new Uri(myUri));                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
           
        }

        public  List<ParkingDataItem>  getParkingDataList()
        {
            return listParkingData;
        }

        void myweb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
               
                //Parse string result to JSON.NET object
                JObject o = JObject.Parse(e.Result);

                //Parse array of datas to JArray
                JArray datas = (JArray)o["results"];
                MessageBox.Show(datas.ToString());
                foreach (JToken data in datas)
                {
                    
                     listParkingData.Add(new ParkingDataItem(
                         data["id"].ToString(),
                         data["name"].ToString(),
                         data["location"].ToString(),
                         data["distance"].ToString(),
                         data["price"].ToString(),
                         data["zone"].ToString(),
                         data["total_spaces"].ToString()));
                     //MessageBox.Show(listParkingData[0].location);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error");
            }
        }




        GeoCoordinateWatcher watcher;




        private void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Disabled:
                    // location is unsupported on this device
                    break;
                case GeoPositionStatus.NoData:
                    // data unavailable
                    break;
            }
        }

        private void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var epl = e.Position.Location;

            // Access the position information thusly:
            epl.Latitude.ToString("0.000");
            epl.Longitude.ToString("0.000");
            epl.Altitude.ToString();
            epl.HorizontalAccuracy.ToString();
            epl.VerticalAccuracy.ToString();
            epl.Course.ToString();
            epl.Speed.ToString();
            e.Position.Timestamp.LocalDateTime.ToString();
        }
    }
}
