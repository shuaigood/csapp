using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Management;

namespace WirelessControl
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string WIFI_ADAPTER = "Intel(R) Centrino(R) Ultimate-N 6300 AGN";//"Intel(R) PRO/Wireless 3945ABG Network Connection";

        private ManagementObject m_WifiAdapter;

        public MainWindow()
        {
            InitializeComponent();
        }

        private ManagementObject GetWifiAdapter(string name)
        {            

            ManagementObject objFound = null;

            string manage = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            ManagementObjectCollection collection = searcher.Get();
            //List<string> netWorkList = new List<string>();

            foreach (ManagementObject obj in collection)
            {
                string objName = obj["Name"].ToString();
                if (objName.Equals(name))
                {
                    objFound = obj;
                    break;
                    //netWorkList.Add(objName);
                    //Console.WriteLine(objName);
                }
            }

            return objFound;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            m_WifiAdapter = GetWifiAdapter(WIFI_ADAPTER);
        }

        private void Disable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_WifiAdapter.InvokeMethod("Disable", null);
            }
            catch
            {
            }

        }

        private void Enable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                m_WifiAdapter.InvokeMethod("Enable", null);
            }
            catch
            {
            }
        }


    }
}
