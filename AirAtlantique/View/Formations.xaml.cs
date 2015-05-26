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

            Global.CenterWindow();

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
            try
            {
                Class.Formation nouvelleFormation = new Class.Formation();

                if (String.IsNullOrEmpty(NameBox.Text) || String.IsNullOrEmpty(DescriptionBox.Text) || String.IsNullOrEmpty(DurationBox.Text))
                    throw new Exception("Certains champs ne sont pas remplis");

                nouvelleFormation.Nom = NameBox.Text;
                nouvelleFormation.Description = DescriptionBox.Text;

                int duree = 1;
                bool isNumber = int.TryParse(DurationBox.Text, out duree);

                if (!isNumber)
                    throw new Exception("La durée de validité doit être un nombre");
                else
                    nouvelleFormation.DureeValidite = duree;

                nouvelleFormation.RequiredForJobs = ListPostes.SelectedItems.Cast<Class.Jobs>().Select(x => x.Id);

                formationdao.Save(nouvelleFormation);

                result.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF37A416");
                result.Text = "Ajout réussi";

                ListFormations.ItemsSource = null;
                ListFormations.ItemsSource = new FormationsVM().theFormations;
            }
            catch (Exception error)
            {
                result.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#CC0033");
                result.Text = error.Message;
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
