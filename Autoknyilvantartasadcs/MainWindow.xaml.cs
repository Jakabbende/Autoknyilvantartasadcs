using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Autoknyilvantartasadcs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Kocsi
        {
            

            public string Rendszam {  get; set; }
            public string Marka {  get; set; }
            public string Uzemanyag {  get; set; }
            public Kocsi(string rendszam, string marka, string uzemanyag)
            {
                this.Rendszam = rendszam;
                this.Marka = marka;
                this.Uzemanyag = uzemanyag;
            }

        }
        List<Kocsi> lista = new List<Kocsi>();
        public MainWindow()
        {
            InitializeComponent();
            lista.Add(new Kocsi("TST-001", "Teszt v1", "Benzin"));
            datagridem.ItemsSource = lista;
        }

        private void Hozzaadas(object sender, RoutedEventArgs e)
        {
            if (rendszamuj.Text.Contains('-') && markauj.Text.Length > 0)
            {
                lista.Add(new Kocsi(rendszamuj.Text, markauj.Text, uzemanyaguj.Text));
                datagridem.Items.Refresh();
            }
            else if (rendszamuj.Text.Contains('-') && markauj.Text.Length == 0)
            {
                MessageBox.Show("Nem adott meg márkát");
            }
            else
            {
                MessageBox.Show("Helytelen rendszám");
            }
        }

        private void Torles(object sender, RoutedEventArgs e)
        {
            if(datagridem.SelectedItem != null && datagridem.SelectedItem is Kocsi)
            {
                lista.Remove((Kocsi)datagridem.SelectedItem);
                datagridem.Items.Refresh();
            }
            else if(datagridem.SelectedItem != null && datagridem.SelectedItem is not Kocsi)
            {
                MessageBox.Show("Ez nem kocsi");
            }
            else
            {
                MessageBox.Show("Nincs kijelölve elem");
            }
        }

        private void Kilepes(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}