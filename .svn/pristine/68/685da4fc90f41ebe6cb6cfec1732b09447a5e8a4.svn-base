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

            //this.refreshList();
        }
        /*
        public void refreshList()
        {
            this.listing.Items.Clear();

            // leeren neuen Kunden anlegen und als 1 Eintrag in die Liste einsetzen
            Kunde kd_neu = new Kunde();
            kd_neu.name = " >>> NEUEN Kunde anlegen <<< ";
            this.listing.Items.Add(kd_neu);

            // alle Kunden aus Datenbank in eine Arrayliste einlesen
            ArrayList alleDaten = Kunde.getAll();

            // alle Kunden Instanzen der Listbox als Zeile hinzufügen
            foreach (Kunde k in alleDaten)
            {
                this.listing.Items.Add(k);
            }

            // DB Id des aktuell ausgewählten Kunden
            this.curr_id = 0;

            // im Fenster die Liste sichtbar machen
            // das Formular ausblenden
            this.formular.Visibility = Visibility.Collapsed;
            this.listing.Visibility = Visibility.Visible;
        }
        // Holt die Daten aus der Datenbank
        private void listing_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listing.SelectedIndex >= 0)
            {
                // Datenbank ID des angeklickten Kunden anzeigen
                this.curr_id = ((Kunde)this.listing.Items[this.listing.SelectedIndex]).id;

                // Liste unsichtbar nachdem angeklickt 
                this.listing.Visibility = Visibility.Collapsed;

                Kunde k = new Kunde(this.curr_id);

                this.kd_name.Text = k.name;
                this.kd_strasse.Text = k.strasse;
                this.kd_hsnr.Text = k.hsnr;
                this.kd_plz.Text = k.plz;
                this.kd_ort.Text = k.ort;
                this.kd_land.Text = k.land;

                // Formular sichtbar schalten
                this.formular.Visibility = Visibility.Visible;
            }
        }
        // Schreibt die Daten in die Datenbank
        private void kd_save_Click(object sender, RoutedEventArgs e)
        {
            kd_save_it();
        }

        private void kd_save_it()
        {   // Den aktuellen Kunden instanzieren
            Kunde k = new Kunde(this.curr_id);

            // die Werte aus dem Formular in die Instanzen(RAM) schreiben
            k.name = this.
            k.strasse = this.kd_strasse.Text;
            k.hsnr = this.kd_hsnr.Text;
            k.plz = this.kd_plz.Text;
            k.ort = this.kd_ort.Text;
            k.land = this.kd_land.Text;

            // Daten an MySQL senden: RAM >> HDD
            k.save();

            // Liste aktualisiert neu laden
            this.refreshList();
        }

        private void kd_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                kd_save_it();
            }
        }

        private void kd_dell_Click(object sender, RoutedEventArgs e)
        {
            Kunde k = new Kunde(this.curr_id);

            //
            k.deleted = 1;

            // Daten an MySQL senden: RAM >> HDD
            k.save();

            this.refreshList();
        }
        */
    }
}
