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
    /// Interaktionslogik für Bemerkungen.xaml
    /// </summary>
    public partial class Bemerkungen : UserControl
    {
        public int curr_id = 0;
        public Bemerkungen()
        {
            InitializeComponent();
            this.refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Bemerkung bem_neu = new Bemerkung();
            bem_neu.text = " >>> NEUEN Text anlegen <<< ";
            this.listing.Items.Add(bem_neu);

            ArrayList alleBem = Bemerkung.getAll();

            foreach (Bemerkungen b in alleBem)
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
                this.curr_id = ((Bemerkung)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                B b = new Baustelle(this.curr_id);

                this.bst_name.Text = b.name;
                this.bst_kostentraeger.Text = b.kostentraeger;
                this.bst_pro_id.Text = b.projekt_id.ToString();
                this.bst_bau_ma_lei_id.Text = b.bau_leit_ma_id.ToString();
                this.bst_start.Text = b.start_date;
                this.bst_ende.Text = b.end_date;

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
            b.kostentraeger = this.bst_kostentraeger.Text;
            b.projekt_id = Int32.Parse(this.bst_pro_id.Text);
            b.bau_leit_ma_id = Int32.Parse(this.bst_bau_ma_lei_id.Text);
            b.start_date = this.bst_start.Text;
            b.end_date = this.bst_ende.Text;

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
