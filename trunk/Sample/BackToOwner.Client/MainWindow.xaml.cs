using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace BackToOwner.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers.Add("Content-Type", "text/xml");
                var ms = new MemoryStream(client.UploadData(
                    UriText.Text,
                    "POST",
                    UTF8Encoding.UTF8.GetBytes(RequestText.Text)
                    ));
                ResponseText.Text = UTF8Encoding.UTF8.GetString(ms.ToArray());
            }
            catch (WebException ex)
            {
                handleWebException(ex);
            }
                
        }

        private void GetBtutton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                HttpWebRequest request = WebRequest.Create(UriText.Text) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "text/xml";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var stream = response.GetResponseStream();
                string responseText = stream.ConvertToString();
                ResponseText.Text = responseText;
            }
            catch (WebException ex)
            {
                handleWebException(ex);
            }
        }

        private void handleWebException(WebException ex)
        {
            ResponseText.Text = ex.Message;
            
            if (ex.Response!=null)
                ResponseText.Text = ResponseText.Text + "/r Response Content:" + ex.Response.GetResponseStream().ConvertToString();
        }  
    }

    public static class ClassExtensions
    {
        public static string ConvertToString(this Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
