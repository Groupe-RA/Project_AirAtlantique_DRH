using AirAtlantique.Class;
using AirAtlantique.Database;
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
    /// Logique d'interaction pour Formations.xaml
    /// </summary>
    public partial class Formations : UserControl
    {
        FormationsDao formationdao = new FormationsDao();

        public Formations()
        {
            InitializeComponent();

            Application.Current.MainWindow.Width = 900;
            Application.Current.MainWindow.Height = 500;

            FormationsVM formationsvm = new FormationsVM();
            JobVM jobsvm = new JobVM();

            ListFormations.ItemsSource = formationsvm.theFormations;
            ListPostes.ItemsSource = jobsvm.theJobs;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Index();
        }

        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            // Sauvegarder
            Class.Formation nouvelleFormation = new Class.Formation();

            nouvelleFormation.Nom = NameBox.Text;
            nouvelleFormation.Description = DescriptionBox.Text;
            nouvelleFormation.DureeValidite = int.Parse(DurationBox.Text);
            nouvelleFormation.RequiredForJobs = ListPostes.SelectedItems.Cast<Class.Jobs>().Select(x => x.Id);

            formationdao.Save(nouvelleFormation);

            try
            {

            }
            catch(Exception erreur)
            {

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            FormationView formationtodelete = new FormationView();
            formationtodelete = (FormationView)ListFormations.SelectedItem;

            formationdao.DeleteById(formationtodelete.Id);

            ListFormations.ItemsSource = null;
            ListFormations.ItemsSource = new FormationsVM().theFormations;
        }
    }
}
