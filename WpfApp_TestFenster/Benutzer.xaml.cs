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
    /// Interaktionslogik für Benutzer.xaml
    /// </summary>
    public partial class Benutzer : UserControl
    {
        public int curr_id = 0;
        public Benutzer()
        {
            InitializeComponent();
            refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Benutzer1 f_neu = new Benutzer1();
            f_neu.vorname = " >>> NEUEN Benutzer anlegen <<< ";
            this.listing.Items.Add(f_neu);

            ArrayList alleBenutzer = Benutzer1.getAll();

            foreach (Benutzer1 f in alleBenutzer)
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
                this.curr_id = ((Benutzer1)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Benutzer1 b = new Benutzer1(this.curr_id);

                this.vorname.Text = b.vorname;
                this.nachname.Text = b.nachname;
                this.cb_typ.SelectedItem = b.typ;
                this.email.Text = b.email;
                //this.passwort.Text = b.setPasswort;
                

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
            Benutzer1 b = new Benutzer1(this.curr_id);

            b.vorname = this.vorname.Text;
            b.nachname = this.nachname.Text;
            b.typ = (int)this.cb_typ.SelectedItem;
            b.email = this.email.Text;
            //b.passwort = this.passwort.Password;
            b.save();

            this.refreshList();
        }

        private void kd_name_KeyDown(object sender, KeyEventArgs e)
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
    }
}
