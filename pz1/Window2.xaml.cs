using Microsoft.Win32;
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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        int index;

        public Window2()
        {
            InitializeComponent();
        }

        public Window2(int index)
        {
            InitializeComponent();

            textBoxDatum.Text = "unesite datum predstavljanja automobila";
            textBoxDatum.Foreground = Brushes.LightSlateGray;

            textBoxSnaga.Text = "unesite snagu automobila";
            textBoxSnaga.Foreground = Brushes.LightSlateGray;

            labelSlika.Content = "Slobodno mesto";

            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            cmbFontColor.ItemsSource = typeof(Colors).GetProperties();

            cmbModel.ItemsSource = Modeli.modeli;

            cmbModel.SelectedItem = MainWindow.Automobili[index].Model;
            textBoxDatum.Text = MainWindow.Automobili[index].Godina.ToString();
            textBoxSnaga.Text = MainWindow.Automobili[index].Snaga.ToString();
            if (String.Equals(MainWindow.Automobili[index].Boja, "Crvena"))
            {
                rbCrvena.IsChecked = true;
            }
            else if (String.Equals(MainWindow.Automobili[index].Boja, "Plava"))
            {
                rbPlava.IsChecked = true;
            }
            else
            {
                rbCrna.IsChecked = true;
            }

            image.Source = MainWindow.Automobili[index].Slika;
            rtbTextEditor.AppendText(MainWindow.Automobili[index].Tekst.ToString());

            this.index = index;
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(rtbTextEditor.Document.ContentStart, rtbTextEditor.Document.ContentEnd);

            if (validate())
            {
                if (rbCrvena.IsChecked == true)
                {
                    MainWindow.Automobili[index].Model = cmbModel.SelectedItem.ToString();
                    MainWindow.Automobili[index].Godina = textBoxDatum.Text;
                    MainWindow.Automobili[index].Snaga = Int32.Parse(textBoxSnaga.Text);
                    MainWindow.Automobili[index].Boja = "Crvena";
                    MainWindow.Automobili[index].Slika = image.Source;
                    MainWindow.Automobili[index].Tekst = range.Text;
                }
                else if (rbPlava.IsChecked == true)
                {
                    MainWindow.Automobili[index].Model = cmbModel.SelectedItem.ToString();
                    MainWindow.Automobili[index].Godina = textBoxDatum.Text;
                    MainWindow.Automobili[index].Snaga = Int32.Parse(textBoxSnaga.Text);
                    MainWindow.Automobili[index].Boja = "Plava";
                    MainWindow.Automobili[index].Slika = image.Source;
                    MainWindow.Automobili[index].Tekst = range.Text;
                }
                else
                {
                    MainWindow.Automobili[index].Model = cmbModel.SelectedItem.ToString();
                    MainWindow.Automobili[index].Godina = textBoxDatum.Text;
                    MainWindow.Automobili[index].Snaga = Int32.Parse(textBoxSnaga.Text);
                    MainWindow.Automobili[index].Boja = "Crna";
                    MainWindow.Automobili[index].Slika = image.Source;
                    MainWindow.Automobili[index].Tekst = range.Text;
                }
            }
            else
            {
                MessageBox.Show("Podaci nisu dobro popunjeni", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog picture = new OpenFileDialog();

            if (picture.ShowDialog() == true)
            {
                labelSlika.Content = "";
                image.Source = new BitmapImage(new Uri(picture.FileName));
            }
        }

        private void BtnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validate()
        {
            bool result = true;

            if (cmbModel.SelectedItem == null)
            {
                result = false;
                cmbModel.BorderBrush = Brushes.Red;
                cmbModel.BorderThickness = new Thickness(1);
                labelModelGreska.Content = "Morate odabrati jednu opciju!";
            }
            else
            {
                cmbModel.BorderBrush = Brushes.Green;
                labelModelGreska.Content = string.Empty;
            }


            if (textBoxDatum.Text.Trim().Equals("") || textBoxDatum.Text.Trim().Equals("unesite datum predstavljanja automobila"))
            {
                result = false;
                textBoxDatum.BorderBrush = Brushes.Red;
                textBoxDatum.BorderThickness = new Thickness(1);
                labelDatumGreska.Content = "Ne moze biti prazno!";
            }
            else
            {
                textBoxDatum.BorderBrush = Brushes.Green;
                labelDatumGreska.Content = string.Empty;
            }

            if (textBoxSnaga.Text.Trim().Equals("") || textBoxSnaga.Text.Trim().Equals("unesite snagu automobila"))
            {
                result = false;
                textBoxSnaga.BorderBrush = Brushes.Red;
                textBoxSnaga.BorderThickness = new Thickness(1);
                labelSnagaGreska.Content = "Ne moze biti prazno!";
            }
            else
            {
                textBoxSnaga.BorderBrush = Brushes.Green;
                labelSnagaGreska.Content = string.Empty;
            }

            if (rbCrvena.IsChecked == false && rbPlava.IsChecked == false && rbCrna.IsChecked == false)
            {
                result = false;
                labelBojaGreska.Content = "Morate odabrati jednu opciju!";
            }
            else
            {
                labelBojaGreska.Content = string.Empty;
            }

            if (image.Source == null)
            {
                result = false;
                labelSlikaGreska.Content = "Morate odabrati fotografiju!";
            }
            else
            {
                labelSlikaGreska.Content = string.Empty;
            }

            if (rtbTextEditor.ToString() == "")
            {
                result = false;
                rtbTextEditor.BorderBrush = Brushes.Red;
                rtbTextEditor.BorderThickness = new Thickness(1);
                labelOpisGreska1.Content = "Ne moze biti prazno!";
            }
            else
            {
                labelOpisGreska1.Content = string.Empty;
            }

            return result;
        }


        private void RtbTextEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtbTextEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));

            temp = rtbTextEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));

            temp = rtbTextEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));


            temp = rtbTextEditor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;

            temp = rtbTextEditor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();

            temp = rtbTextEditor.Selection.GetPropertyValue(Inline.ForegroundProperty);
        }

        private void CmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
            {
                rtbTextEditor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
            }
        }

        private void CmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontSize.SelectedItem != null)
            {
                rtbTextEditor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.SelectedItem);
            }
        }

        private void CmbTextColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void TextBoxModel_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxDatum.Text.Trim().Equals("unesite datum predstavljanja automobila"))
            {
                textBoxDatum.Text = "";
                textBoxDatum.Foreground = Brushes.Black;
            }
        }

        private void TextBoxModel_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxDatum.Text.Trim().Equals(string.Empty))
            {
                textBoxDatum.Text = "unesite datum predstavljanja automobila";
                textBoxDatum.Foreground = Brushes.LightSlateGray;
            }
        }

        private void TextBoxSnaga_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxSnaga.Text.Trim().Equals("unesite snagu automobila"))
            {
                textBoxSnaga.Text = "";
                textBoxSnaga.Foreground = Brushes.Black;
            }
        }

        private void TextBoxSnaga_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxSnaga.Text.Trim().Equals(string.Empty))
            {
                textBoxSnaga.Text = "unesite snagu automobila";
                textBoxSnaga.Foreground = Brushes.LightSlateGray;
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void RtbTextEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextRange range = new TextRange(rtbTextEditor.Document.ContentStart, rtbTextEditor.Document.ContentEnd);
            statusBar.ItemsSource = (range.Text.Length - 2).ToString();
        }
    }
}
