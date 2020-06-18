using klassen_anwendung_staudinger;
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

namespace WpfApp_TestFenster
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void hideAllControlls()
        {
            this.baustellen.Visibility = Visibility.Collapsed;
            this.bemerkungen.Visibility = Visibility.Collapsed;
            this.benutzer.Visibility = Visibility.Collapsed;
            this.einsaetze.Visibility = Visibility.Collapsed;
            this.faehigkeiten.Visibility = Visibility.Collapsed;
            this.firmen.Visibility = Visibility.Collapsed;
            this.kunden.Visibility = Visibility.Collapsed;
            this.mitarbeiter.Visibility = Visibility.Collapsed;
            this.projekte.Visibility = Visibility.Collapsed;
        }

        private void Baustellen_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.baustellen.Visibility = Visibility.Visible;
        }

        private void Bemerkungen_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.bemerkungen.Visibility = Visibility.Visible;
        }

        private void Benutzer_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.benutzer.Visibility = Visibility.Visible;
        }

        private void Einsaetze_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.einsaetze.Visibility = Visibility.Visible;
        }

        private void Faehigkeiten_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.faehigkeiten.refreshList();
            this.faehigkeiten.Visibility = Visibility.Visible;
        }

        private void Firmen_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.firmen.Visibility = Visibility.Visible;
        }

        private void Kunden_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();

            // Im Kundenview die Liste neu laden und anzeigen
            //this.kunden.refreshList();
            this.kunden.Visibility = Visibility.Visible;
        }

        private void Mitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.mitarbeiter.refreshList();
            this.mitarbeiter.Visibility = Visibility.Visible;
        }

        private void Projekte_Click(object sender, RoutedEventArgs e)
        {
            this.hideAllControlls();
            this.projekte.Visibility = Visibility.Visible;
        }
    }



}
