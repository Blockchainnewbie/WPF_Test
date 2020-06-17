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
    /// Interaktionslogik für Baustellen.xaml
    /// </summary>
    public partial class Baustellen : UserControl
    {
        public int curr_id = 0;
        public Baustellen()
        {
            InitializeComponent();
            this.refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Baustelle bst_neu = new Baustelle();
            bst_neu.name = " >>> NEUEN Baustelle anlegen <<< ";
            this.listing.Items.Add(bst_neu);

            ArrayList alleDaten = Baustelle.getAll();

            foreach (Baustelle b in alleDaten)
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
                this.curr_id = ((Baustelle)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Baustelle b = new Baustelle(this.curr_id);

                this.bst_name.Text = b.name;
                this.bst_kostenträger.Text = b.kostentraeger;
                this.bst_pro_id.Text = b.pro_id;
                this.bst_bau_lei_id.Text = b.bau_leit_ma_id.ToString();
                this.bst_start.Text = b.start_date;
                this.bst_end.Text = b.end_date;

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
            Baustelle b = new Baustelle(this.curr_id);
           b.name = this.bst_name.Text;
            b.kostentraeger = this.bst_kostenträger.Text;
            b.projekt_id = this.bst_pro_id.Text;
            b.plz = this.bst_bau_lei_id.Text;
            b.ort = this.bst_start.Text;
            b.land = this.bst_end.Text;
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

    }
}

