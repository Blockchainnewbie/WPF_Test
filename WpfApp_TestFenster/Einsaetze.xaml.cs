using klassen_anwendung_staudinger;
using System;
using System.Collections;
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
    /// Interaktionslogik für Einsaetze.xaml
    /// </summary>
    public partial class Einsaetze : UserControl
    {
        public int curr_id = 0;
        public Einsaetze()
        {
            InitializeComponent();
            this.refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Einsatz einsatz_neu = new Einsatz();
            
            this.listing.Items.Add(einsatz_neu);

            ArrayList alleEinsaetze = Einsatz.getAll();

            foreach (Einsatz b in alleEinsaetze)
            {
                this.listing.Items.Add(b);
            }

            this.curr_id = 0;

            this.formular.Visibility = Visibility.Collapsed;
            this.listing.Visibility = Visibility.Visible;
        }

        // Holt die Daten aus der Datenbank
        private void listing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listing.SelectedIndex >= 0)
            {
                this.curr_id = ((Einsatz)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Einsatz b = new Einsatz(this.curr_id);

                this.ein_bau_id.Text = b.bau_id.ToString();
                this.ein_ma_id.Text = b.ma_id.ToString();
                this.ein_start.Text = b.start_date;
                this.ein_ende.Text = b.end_date;
                this.ein_forecast.Text = b.forecast.ToString();

                this.formular.Visibility = Visibility.Visible;
            }
        }



        // Schreibt die Daten in die Datenbank
        private void kd_save_Click(object sender, RoutedEventArgs e)
        {
            kd_save_it();
        }

        private void kd_save_it()
        {
            Einsatz b = new Einsatz(this.curr_id);

            b.forecast = Int32.Parse(this.ein_forecast.Text);
            b.ma_id = Int32.Parse(this.ein_ma_id.Text);
            b.bau_id = Int32.Parse(this.ein_bau_id.Text);
            b.start_date = this.ein_start.Text;
            b.end_date = this.ein_ende.Text;

            b.save();

            this.refreshList();
        }

        private void kd_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                kd_save_it();
            }
        }

        private void kd_delete_Click(object sender, RoutedEventArgs e)
        {
            Einsatz foo = new Einsatz(this.curr_id);
            foo.delete();
            this.refreshList();
        }
    }
}

