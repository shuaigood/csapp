using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace csapp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Intel(R) PRO/Wireless 3945ABG Network Connection

            string manage = "SELECT * From Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            ManagementObjectCollection collection = searcher.Get();
            List<string> netWorkList = new List<string>();

            foreach (ManagementObject obj in collection)
            {
                string objName = obj["Name"].ToString();
                if (objName.Equals("Intel(R) PRO/Wireless 3945ABG Network Connection"))
                {
                    netWorkList.Add(objName);
                    Console.WriteLine(objName);
                }
            }
            //this.cmbNetWork.DataSource = netWorkList;



            Console.Read();
        }
    }
}
