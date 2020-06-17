using klassen_anwendung_staudinger;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp_TestFenster
{
    /// <summary>
    /// Interaktionslogik für Mitarbeiter.xaml
    /// </summary>
    public partial class MitarbeiterForm : UserControl
    {
        public int curr_id = 0;
        public MitarbeiterForm()
        {
            InitializeComponent();
            refreshList();
        }

        public void refreshList()
        {
            this.listing.Items.Clear();

            Mitarbeiter f_neu = new Mitarbeiter();
            f_neu.vorname = " >>> NEUEN Mitarbeiter anlegen <<< ";
            this.listing.Items.Add(f_neu);

            ArrayList alleMitarbeiter = Mitarbeiter.getAll();

            foreach (Mitarbeiter f in alleMitarbeiter)
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
                this.curr_id = ((Mitarbeiter)this.listing.Items[this.listing.SelectedIndex]).id;

                this.listing.Visibility = Visibility.Collapsed;

                Mitarbeiter m = new Mitarbeiter(this.curr_id);

                this.vorname.Text = m.vorname;
                this.nachname.Text = m.nachname;
                this.anrede.Text = m.anrede;

                ArrayList allFirmen = Firma.getAll();

                this.f_firma.Items.Clear();

                foreach (Firma firm in allFirmen)
                {
                    this.f_firma.Items.Add(firm);
                    
                    if ( firm.id == m.firmen_id)
                    {
                        this.f_firma.SelectedIndex = this.f_firma.Items.Count - 1;
                    }
                }
                this.formular.Visibility = Visibility.Visible;
            }
        }

        private void f_save_Click(object sender, RoutedEventArgs e)
        {
            f_save_it();
        }

        private void f_save_it()
        {
            Mitarbeiter f = new Mitarbeiter(this.curr_id);
            f.vorname = this.vorname.Text;
            f.nachname = this.nachname.Text;

            int selIndex = this.f_firma.SelectedIndex;
            if ( selIndex != -1 )
            {
                f.firmen_id = ((Firma)(this.f_firma.Items[selIndex])).id;
            }
            

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

    }
}
