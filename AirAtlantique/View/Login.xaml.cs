using AirAtlantique.Database;
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

namespace AirAtlantique.View
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        UsersDao userdao = new UsersDao();

        public Login()
        {
            Application.Current.MainWindow.Width = 300;
            Application.Current.MainWindow.Height = 300;

            InitializeComponent();

            Global.CenterWindow();

            // Close Button
            End.MouseLeftButtonDown += new MouseButtonEventHandler(End_MouseLeftButtonDown);
        }

        private void End_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(Username.Text))
                    throw new Exception("Champ nom d'utilisateur vide");

                if (String.IsNullOrEmpty(Password.Password))
                    throw new Exception("Champ mot de passe vide");

                if (userdao.Login(Username.Text, Password.Password))
                {
                    Global.UserName = Username.Text;
                    Application.Current.MainWindow.Content = new Index();
                }
                else
                {
                    throw new Exception("Utilisateur ou mot de passe incorrect");
                }
            }
            catch (Exception error)
            {
                Result.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#CC0033");
                Result.Text = error.Message;
            }

        }
    }
}
