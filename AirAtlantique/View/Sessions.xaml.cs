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
using System.Windows.Controls.Primitives;
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
    /// Logique d'interaction pour Sessions.xaml
    /// </summary>
    public partial class Sessions : UserControl
    {
        SessionsDao sessiondao = new SessionsDao();
        bool IsModif = false;
        int idModif = 0;

        public Sessions(int idSessionEdition = 0)
        {
            InitializeComponent();

            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 700;

            IEnumerable<Employes> lesEmployes = new EmployesVM().theEmployes;
            IEnumerable<Class.FormationView> lesFormations = new FormationsVM().theFormations;

            ListeFormation.ItemsSource = lesFormations;
            ListeEmploye.ItemsSource = lesEmployes;

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListeEmploye.ItemsSource);
            view.Filter = FilterJobFor;

            /*
            StartCalendar.BlackoutDates.Add(new CalendarDateRange(
                new DateTime(1990, 1, 1),
                DateTime.Now
            ));

            EndCalendar.BlackoutDates.Add(new CalendarDateRange(
                new DateTime(1990, 1, 1),
                DateTime.Now
            ));
            */

            // Si mode édition
            if (idSessionEdition != 0)
                PreselectEdit(idSessionEdition);
        }

        // Si mode édition
        private void PreselectEdit(int idToEdit)
        {
            Save.Content = "Modifier";
            IsModif = true;
            idModif = idToEdit;

            Database.Session theSession = sessiondao.GetById(idToEdit);

            StartCalendar.Value = theSession.DateStart;
            EndCalendar.Value = theSession.DateEnd;

            ListeFormation.SelectedValuePath = "Id";

            ListeFormation.SelectedValue = theSession.FormationID;

            ListeEmploye.SelectedValuePath = "Id";


            // Preselection multiples employes hack
            List<object> test = new List<object>();
            foreach(Database.Employee unEmp in theSession.Employee) {
                ListeEmploye.SelectedValue = unEmp.EmployeeID;
                test.Add(ListeEmploye.SelectedItem);
            }
            ListeEmploye.SelectedItems.Clear();

            foreach (object Emp in test)
                ListeEmploye.SelectedItems.Add(Emp);
            // fin hack
        }


        private bool FilterJobFor(object item)
        {
            var formationSelect = (Class.FormationView)ListeFormation.SelectedItem;
            if (formationSelect != null)
                return formationSelect.RequiredForJobs.Any(x => x == (item as Class.Employes).Poste);
            else
                return false;
        }

        /// <summary>
        /// Bouton de retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(!IsModif)
                Application.Current.MainWindow.Content = new Index();
            else
                Application.Current.MainWindow.Content = new EditSessions();
        }

        /// <summary>
        /// Bouton enregistrer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Class.Session nouvelleSession = new Class.Session();

            try
            {
                if ((DateTime)StartCalendar.Value < DateTime.Now || (DateTime)EndCalendar.Value < DateTime.Now)
                    throw new Exception("Les dates choisies sont déja écoulées");

                if (StartCalendar.Value != null) 
                    nouvelleSession.DateDebut = (DateTime)StartCalendar.Value; 
                else 
                    throw new Exception("Aucune date de début choisie");

                if (EndCalendar.Value != null)
                    nouvelleSession.DateFin = (DateTime)EndCalendar.Value;
                else
                    throw new Exception("Aucune date de fin choisie");

                nouvelleSession.FormationSession = (Class.FormationView)ListeFormation.SelectedItem;

                if (ListeEmploye.SelectedItems.Count == 0)
                    throw new Exception("Aucun employé sélectionné ou éligible");

                nouvelleSession.EmployesParticipants = ListeEmploye.SelectedItems.Cast<Class.Employes>().Select(x => x.Id);

                if (!IsModif)
                    sessiondao.Save(nouvelleSession);
                else
                    sessiondao.Modify(idModif, nouvelleSession);

                result.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#FF37A416");
                result.Text = "Enregistrement réussi";
            }
            catch (Exception ex)
            {
                result.Foreground = (SolidColorBrush)new BrushConverter().ConvertFromString("#CC0033");
                result.Text = ex.Message;
            }

        }

        // Calendar fix bug du double click
        protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseUp(e);
            if (Mouse.Captured is CalendarItem)
            {
                Mouse.Capture(null);
            }
        }

        // Called when Selection changed to refresh employee list
        private void FormationSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ListeEmploye.ItemsSource).Refresh();
        }
    }
}
