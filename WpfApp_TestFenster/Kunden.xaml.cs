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
    /// Interaktionslogik für Kunden.xaml
    /// </summary>
    public partial class Kunden : UserControl
    {
        public int curr_id = 0;
        public Kunden()
        {
            InitializeComponent();
            refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Kunde f_neu = new Kunde();
            f_neu.name = " >>> NEUEN Kunden anlegen <<< ";
            this.listing.Items.Add(f_neu);

            ArrayList alleKunden = Kunde.getAll();

            foreach (Kunde f in alleKunden)
            {
                this.listing.Items.Add(f);
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
                this.curr_id = ((Kunde)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Kunde b = new Kunde(this.curr_id);
                this.name.Text = b.name;
                this.strasse.Text = b.strasse;
                this.hsnr.Text = b.hsnr;
                this.plz.Text = b.plz;
                this.ort.Text = b.ort;
                this.land.Text = b.land;

                this.formular.Visibility = Visibility.Visible;
            }
        }

        // Schreibt die Daten in die Datenbank
        private void f_save_Click(object sender, RoutedEventArgs e)
        {
            F_save_it();
        }

        private void F_save_it()
        {
            Kunde b = new Kunde(this.curr_id);

            b.name = this.name.Text;
            b.strasse = this.strasse.Text;
            b.hsnr = this.hsnr.Text;
            b.plz = this.plz.Text;
            b.ort = this.ort.Text;
            b.land = this.land.Text;
  
            b.save();

            this.refreshList();
        }

        private void f_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                F_save_it();
            }
        }

        private void listing_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            return;
        }

        private void kd_delete_Click(object sender, RoutedEventArgs e)
        {
            Kunde foo = new Kunde(this.curr_id);
            foo.delete();
            this.refreshList();
        }
    }
}
