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
    /// Interaktionslogik für Firmen.xaml
    /// </summary>
    public partial class Firmen : UserControl
    {
        public int curr_id = 0;
        public Firmen()
        {
            InitializeComponent();
            refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Firma f_neu = new Firma();
            f_neu.name = " >>> NEUE Firma anlegen <<< ";
            this.listing.Items.Add(f_neu);

            ArrayList alleFirmen = Firma.getAll();

            foreach (Firma f in alleFirmen)
            {
                this.listing.Items.Add(f);
            }

            this.curr_id = 0;

            this.formular.Visibility = Visibility.Collapsed;
            this.listing.Visibility = Visibility.Visible;
        }

        private void listing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listing.SelectedIndex >= 0)
            {
                this.curr_id = ((Firma)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Firma m = new Firma(this.curr_id);

                // Blendet die Daten in den Textboxen ein
                this.name.Text = m.name;
                this.strasse.Text = m.strasse;
                this.hsnr.Text = m.hsnr;
                this.plz.Text = m.plz;
                this.ort.Text = m.ort;
                this.land.Text = m.land;

                this.formular.Visibility = Visibility.Visible;
            }
        }

        private void f_save_Click(object sender, RoutedEventArgs e)
        {
            f_save_it();
        }

        private void f_save_it()
        {
            Firma f = new Firma(this.curr_id);
            f.name = this.name.Text;
            f.strasse = this.strasse.Text;
            f.hsnr = this.hsnr.Text;
            f.plz = this.plz.Text;
            f.ort = this.ort.Text;
            f.land = this.land.Text;

            f.save();


            this.refreshList();
        }

        private void f_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                f_save_it();
            }
        }

        private void kd_delete_Click(object sender, RoutedEventArgs e)
        {
            Firma foo = new Firma (this.curr_id);
            foo.delete();
            this.refreshList();
        }
    }
}
