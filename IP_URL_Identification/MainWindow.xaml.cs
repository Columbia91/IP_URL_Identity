using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Input;

namespace IP_URL_Identification
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UrlTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    ipListBox.Items.Clear();

                    IPHostEntry host = Dns.GetHostEntry(urlTextBox.Text);
                    foreach (var ip in host.AddressList)
                    {
                        ipListBox.Items.Add(ip);
                    }
                }
                catch (InvalidOperationException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (SocketException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void IpTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                try
                {
                    string ip = ipTextBox.Text;
                    IPAddress address = IPAddress.Parse(ip);
                    IPHostEntry host = Dns.GetHostEntry(address);
                    serverTextBox.Text = host.HostName;
                }
                catch (FormatException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (SocketException exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
