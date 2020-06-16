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
    /// Interaktionslogik für Faehigkeiten.xaml
    /// </summary>
    public partial class Faehigkeiten : UserControl
    {
        public int curr_id = 0;

        public Faehigkeiten()
        {
            InitializeComponent();

            this.refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Faehigkeit f_neu = new Faehigkeit();
            f_neu.name = " >>> NEUE Fähigkeit anlegen <<< ";
            this.listing.Items.Add(f_neu);

            ArrayList alleFaehigkeiten = Faehigkeit.getAll();

            foreach (Faehigkeit f in alleFaehigkeiten)
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
                this.curr_id = ((Faehigkeit)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Faehigkeit f = new Faehigkeit( this.curr_id );

                this.f_name.Text = f.name;

                this.formular.Visibility = Visibility.Visible;
            }
        }

        private void f_save_Click(object sender, RoutedEventArgs e)
        {
            f_save_it();
        }

        private void f_save_it()
        {
            Faehigkeit f = new Faehigkeit(this.curr_id);
            f.name = this.f_name.Text;
            f.save();

            this.refreshList();
        }

        private void f_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                f_save_it();
            }
        }

    }
}
