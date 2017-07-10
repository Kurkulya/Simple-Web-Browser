using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_Web_Browser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WebBrowser.Navigated += (sender,e) => txtUrl.Text = WebBrowser.Source.ToString();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            WebBrowser.GoBack();
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            WebBrowser.GoForward();
        }

        private void RefreshPage(object sender, RoutedEventArgs e)
        {
            WebBrowser.Refresh();
        }

        private void GoUrl(object sender, RoutedEventArgs e)
        {
            string address = txtUrl.Text; 
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                WebBrowser.Navigate(address);
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string address = txtUrl.Text;
                if (String.IsNullOrEmpty(address)) return;
                if (address.Equals("about:blank")) return;
                if (!address.StartsWith("http://") &&
                    !address.StartsWith("https://"))
                {
                    address = "http://" + address;
                }
                try
                {
                    WebBrowser.Navigate(address);
                }
                catch (System.UriFormatException)
                {
                    return;
                }
            }
        }
    }
}
