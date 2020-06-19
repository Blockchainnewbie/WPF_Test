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
    /// Interaktionslogik für Projekte.xaml
    /// </summary>
    public partial class Projekte : UserControl
    {
        public int curr_id = 0;
        public Projekte()
        {
            InitializeComponent();
            this.refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Projekt pro_neu = new Projekt();
            pro_neu.name = " >>> NEUES Projekt anlegen <<< ";
            this.listing.Items.Add(pro_neu);

            ArrayList alleProjekte = Projekt.getAll();

            foreach (Projekt b in alleProjekte)
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
                this.curr_id = ((Projekt)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Projekt b = new Projekt(this.curr_id);

                this.pro_name.Text = b.name;
                this.pro_kunde_id.Text = b.kunde_id.ToString();
                this.pro_leiter_ma_id.Text = b.pro_leit_ma_id.ToString();
                this.pro_ort.Text = b.ort;
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
            Projekt b = new Projekt(this.curr_id);

            b.name = this.pro_name.Text;
            b.kunde_id = Int32.Parse(this.pro_kunde_id.Text);
            b.pro_leit_ma_id = Int32.Parse(this.pro_leiter_ma_id.Text);
            b.ort = this.pro_ort.Text;
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

        private void kd_delete_Click(object sender, RoutedEventArgs e)
        {
            Projekt foo = new Projekt(this.curr_id);
            foo.delete();
            this.refreshList();
        }
    }
}

