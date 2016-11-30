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
using Tally.Models;
using Newtonsoft.Json.Linq;

namespace Tally
{
    public partial class PanoramaPage1 : PhoneApplicationPage
    {
        List<ParkingModel> myList;
        WebClient wc = new WebClient();

        public PanoramaPage1()
        {
            InitializeComponent();
            SetParkingList();
        }




        //When user clocks the get data button
        private void SetParkingList()
        {


            WebClient myWeb = new WebClient();

            myList = new List<ParkingModel>();

            ParkingModel myPark1 = new ParkingModel("Fake Street", 0.0005, 0.0234234234);
            ParkingModel myPark2 = new ParkingModel("Unreal Grove", 0.045, 0.0234234234);
            ParkingModel myPark3 = new ParkingModel("Park Road", 0.065655, 0.02342334234);

            int i = 0;
            int x = 0;

            while (i != 100)
            {

                //myList.Add(myPark1);
                //myList.Add(myPark2);
                //myList.Add(myPark3);
                i++;
            }

            listBox1.ItemsSource = myList;
            //x++;


            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadedCompleteEventHandler);
            wc.DownloadStringAsync(new Uri("http://api.parkshark.nl/psapi/api.jsp?action=find_nearest&lat=52.377&lon=4.9104&rate=3.0)"));

        }


        void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            JArray jarray = convertBitstampTickerLast(e.Result);
            MessageBox.Show(jarray.ToString());
            myList.Add(new ParkingModel(e.Result,0.01,0.02));
           

            // var rawTicker = JsonConvert.DeserializeObject<RawTicker>(e.Result);

            wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);



        }

        int x = 0;
        void wc_DownloadedCompleteEventHandler(object sender, DownloadStringCompletedEventArgs e)
        {

            JArray jarray = new JArray();
            // e.Result.
            // 

            try
            {
                jarray.Add(e.Result);
                Object o = JObject.Parse(e.Result);

                //MessageBox.Show(e.Result);
                x++;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }


        }


        //Gets the last token of bitstamp ticker and returns it as a string
        public JArray convertBitstampTickerLast(string jsonData)
        {
            JObject o = JObject.Parse(jsonData);
            JArray a = JArray.Parse(jsonData);
            //string h = (string)o.SelectToken("last");
            // BalanceTextBox.Text = a.ToString();
            return a;
        }


    }
}