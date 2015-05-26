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
using AirAtlantique.ViewModel;
using AirAtlantique.Class;
using AirAtlantique.Database;
using System.ComponentModel;

namespace AirAtlantique
{
    /// <summary>
    /// Logique d'interaction pour EditSessions.xaml
    /// </summary>
    public partial class EditSessions : UserControl
    {
        public EditSessions()
        {
            InitializeComponent();

            Application.Current.MainWindow.Width = 1200;
            Application.Current.MainWindow.Height = 800;

            /*EditSessionListView.Items.Add(new EmployesVM().theEmployes);
            this.DataContext = new EmployesVM().theEmployes;*/

            Global.CenterWindow();
            
            IEnumerable<SessionView> donnees = new SessionsVM().theSessions;

            EditSessionListView.ItemsSource = donnees;
        }

        /// <summary>
        /// Bouton retour
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new Index();
        }

        /// <summary>
        /// Bouton modifier session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionModifier(object sender, RoutedEventArgs e)
        {
            Button leBoutton = sender as Button;
            SessionView uneSession = leBoutton.DataContext as SessionView;
            var idSession = uneSession.Id;

            if (uneSession.DateDebut <= DateTime.Now)
                MessageBox.Show("Vous ne pouvez pas modifier une session en cours ou terminée");
            else
                Application.Current.MainWindow.Content = new Sessions(idSession);
        }

        /// <summary>
        /// Bouton supprimer session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActionSupprimer(object sender, RoutedEventArgs e)
        {
            SessionsDao sessiondao = new SessionsDao();

            Button leBoutton = sender as Button;
            SessionView uneSession = leBoutton.DataContext as SessionView;
            var id = uneSession.Id;

            MessageBoxResult result = MessageBox.Show("Êtes vous sûr de supprimer " + uneSession + " ?", "Supprimer", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                sessiondao.DeleteById(id);
                EditSessionListView.ItemsSource = null;
                EditSessionListView.ItemsSource = new SessionsVM().theSessions;
            }
            
        }


        // SORT HEADER TEST
        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        void GridViewColumnHeaderClickedHandler(object sender,
                                                RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked =
                  e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    string header = headerClicked.Column.Header as string;
                    Sort(header, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }


                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(EditSessionListView.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }


    }
}
