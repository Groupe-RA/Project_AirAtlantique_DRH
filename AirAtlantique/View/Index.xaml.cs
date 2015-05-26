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
using AirAtlantique.View;

namespace AirAtlantique
{
    /// <summary>
    /// Logique d'interaction pour Index.xaml
    /// </summary>
    public partial class Index : UserControl
    {
        public Index()
        {
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 700;

            InitializeComponent();

            Global.CenterWindow();
            
            Login.Text += Global.UserName.ToUpper();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Formations();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Sessions();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Width = 1200;
            Application.Current.MainWindow.Height = 800;
            Application.Current.MainWindow.Content = new EmployesUI();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new EditSessions();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Login();
        }
    }
}
