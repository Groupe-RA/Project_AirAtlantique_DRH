using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirAtlantique
{
    static class Global
    {
        private static string _username = "";

        public static string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public static void CenterWindow()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = Application.Current.MainWindow.Width;
            double windowHeight = Application.Current.MainWindow.Height;
            Application.Current.MainWindow.Left = (screenWidth / 2) - (windowWidth / 2);
            Application.Current.MainWindow.Top = (screenHeight / 2) - (windowHeight / 2);
        }
    }
}
