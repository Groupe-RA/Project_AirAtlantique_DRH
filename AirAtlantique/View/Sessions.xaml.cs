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

            StartCalendar.BlackoutDates.Add(new CalendarDateRange(
                new DateTime(1990, 1, 1),
                DateTime.Now
            ));

            EndCalendar.BlackoutDates.Add(new CalendarDateRange(
                new DateTime(1990, 1, 1),
                DateTime.Now
            ));

            if (idSessionEdition != 0)
                PreselectEdit(idSessionEdition);
        }

        private void PreselectEdit(int idToEdit)
        {
            Save.Content = "Modifier";
            IsModif = true;
            idModif = idToEdit;

            Database.Session theSession = sessiondao.GetById(idToEdit);

            StartCalendar.SelectedDate = theSession.DateStart;
            EndCalendar.SelectedDate = theSession.DateEnd;

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
                if (StartCalendar.SelectedDate != null) 
                    nouvelleSession.DateDebut = StartCalendar.SelectedDate.Value; 
                else 
                    throw new Exception("Aucune date de début choisie");

                if (EndCalendar.SelectedDate != null)
                    nouvelleSession.DateFin = EndCalendar.SelectedDate.Value;
                else
                    throw new Exception("Aucune date de fin choisie");

                nouvelleSession.FormationSession = (Class.FormationView)ListeFormation.SelectedItem;
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
    }
}
