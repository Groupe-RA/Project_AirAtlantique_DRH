using AirAtlantique.Class;
using AirAtlantique.ViewModel;
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

namespace AirAtlantique
{
    /// <summary>
    /// Logique d'interaction pour Employes.xaml
    /// </summary>
    public partial class EmployesUI : UserControl
    {
        public EmployesUI()
        {
            InitializeComponent();

            Global.CenterWindow();

            IEnumerable<Employes> donnees = new EmployesVM().theEmployes;

            EditSessionListView.ItemsSource = donnees;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Index();
        }

        private void ActionModifier(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("GOOD");
        }

        private void ActionSupprimer(object sender, RoutedEventArgs e)
        {
            Button leBoutton = sender as Button;
            Employes unEmploye = leBoutton.DataContext as Employes;
            var test = unEmploye.Nom;

            MessageBoxResult result = MessageBox.Show("Êtes vous sûr de supprimer " + test + " ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                /* TODO */
            }

        }
    }
}
