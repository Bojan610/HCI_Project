using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace pz1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static BindingList<Automobili> Automobili { get; set; }

        public MainWindow()
        {
            Automobili = new BindingList<Automobili>(); 
          
            DataContext = this;
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Pregledaj(object sender, RoutedEventArgs e)
        {
            Window3 pregled = new Window3(dataGridAutomobili.SelectedIndex);
            pregled.ShowDialog();
        }

        private void Izmena(object sender, RoutedEventArgs e)
        {
            Window2 izmena = new Window2(dataGridAutomobili.SelectedIndex);
            izmena.ShowDialog();
            dataGridAutomobili.Items.Refresh();
        }

        private void Brisanje(object sender, RoutedEventArgs e)
        {
            if (Automobili.Count > 0)
            {
                Automobili.RemoveAt(dataGridAutomobili.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Nije moguce brisati iz prazne tabele.", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

     
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            Window1 dodaj = new Window1();
            dodaj.ShowDialog();
        }

        private void Izlaz(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
