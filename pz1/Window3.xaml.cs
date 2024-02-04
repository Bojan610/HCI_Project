using System;
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
using System.Windows.Shapes;

namespace pz1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        public Window3(int index)
        {
            InitializeComponent();

            Model.Content = MainWindow.Automobili[index].Model.ToString();
            Datum.Content = MainWindow.Automobili[index].Godina;
            Snaga.Content = MainWindow.Automobili[index].Snaga.ToString();
            Boja.Content = MainWindow.Automobili[index].Boja;
            image.Source = MainWindow.Automobili[index].Slika;
            Opis.AppendText(MainWindow.Automobili[index].Tekst.ToString());
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
