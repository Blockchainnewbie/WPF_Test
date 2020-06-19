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

            foreach (Bemerkung b in alleBem)
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

                Bemerkung b = new Bemerkung(this.curr_id);

                this.bem_text.Text = b.text;
                this.bem_rel_tab.Text = b.rel_tab;
                this.bem_rel_id.Text = b.rel_id.ToString();
                this.bem_datum.Text = b.datum;
                this.bem_benutzer_id.Text = b.benutzer_id.ToString();
               

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
            Bemerkung b = new Bemerkung(this.curr_id);
            b.text = this.bem_text.Text;
            b.rel_tab = this.bem_rel_tab.Text;
            b.rel_id = Int32.Parse(this.bem_rel_id.Text);
            b.datum = this.bem_datum.Text;
            b.benutzer_id = Int32.Parse(this.bem_benutzer_id.Text);
           

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
            Bemerkung foo = new Bemerkung(this.curr_id);
            foo.delete();
            this.refreshList();
        }
    }
}
