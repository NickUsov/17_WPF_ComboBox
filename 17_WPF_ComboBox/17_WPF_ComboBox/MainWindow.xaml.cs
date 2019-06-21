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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _17_WPF_ComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gas gas = null;
        double gas_price = 0;
        const double hotdob_price = 1.99;
        const double humb_price = 2.99;
        const double free_price = 0.99;
        const double cola_price = 1.99;
        double total_hotdg = 0;
        double total_humb = 0;
        double total_free = 0;
        double total_cola = 0;
        double gallons = 0;
        double totalGas = 0;
        double totalFood = 0;
        int itemsHotdog = 0;
        int itemsHumb = 0;
        int itemsFree = 0;
        int itemsCola = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                upHotdogItemsButton.IsEnabled = true;
                downHotdogItemsButton.IsEnabled = true;
            }
            else
            {
                upHotdogItemsButton.IsEnabled = false;
                downHotdogItemsButton.IsEnabled = false;

            }
        }

        private void CheckBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox2.IsChecked == true)
            {
                upHumbItemsButton.IsEnabled = true;
                downHumbItemsButton.IsEnabled = true;
            }
            else
            {
                upHumbItemsButton.IsEnabled = false;
                downHumbItemsButton.IsEnabled = false;
            }
        }

        private void CheckBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox3.IsChecked == true)
            {
                upFreeItemsButton.IsEnabled = true;
                downFreeItemsButton.IsEnabled = true;
            }
            else
            {
                upFreeItemsButton.IsEnabled = false;
                downFreeItemsButton.IsEnabled = false;
            }
        }

        private void CheckBox4_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox4.IsChecked == true)
            {
                upColaItemsButton.IsEnabled = true;
                downColaItemsButton.IsEnabled = true;
            }
            else
            {
                upColaItemsButton.IsEnabled = false;
                downColaItemsButton.IsEnabled = false;
            }
        }

        private void UpHumbItemsButton_Click(object sender, RoutedEventArgs e)
        {
            total_humb += humb_price;
            itemsHumb++;
            totalFood = total_cola + total_free + total_hotdg + total_humb;
            textBlockHumbTotal.Text = total_humb.ToString();
            textBlockTotalFood.Text = totalFood.ToString();
            textBlockHumbItems.Text = itemsHumb.ToString();
        }

        private void DownFreeItemsButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsFree > 0)
            {
                itemsFree--;
                if (itemsFree < 0)
                    itemsFree = 0;
                total_free -= free_price;
                totalFood = total_cola + total_free + total_hotdg + total_humb;
                textBlockTotalFood.Text = totalFood.ToString();
                textBlockFreeTotal.Text = total_free.ToString();
                textBlockFreeItems.Text = itemsFree.ToString();
            }
        }

        private void UpFreeItemsButton_Click(object sender, RoutedEventArgs e)
        {
            itemsFree++;
            total_free += free_price;
            totalFood = total_cola + total_free + total_hotdg + total_humb;
            textBlockTotalFood.Text = totalFood.ToString();
            textBlockFreeTotal.Text = total_free.ToString();
            textBlockFreeItems.Text = itemsFree.ToString();
        }

        private void ComboBoxGasName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            ComboBoxItem comboboxitem = (ComboBoxItem)combobox.SelectedItem;
            gas = comboboxitem.Content as Gas;
            gas_price = gas.Price;
            textBoxGasPrice.Text = gas.Price.ToString();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxGasPrice.Text != "")
            {
                if (double.TryParse(textBox1.Text, out gallons))
                {
                    totalGas = gallons * gas_price;
                    textBlockTotalGas.Text = $"{totalGas:f2}";
                }
            }
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true)
            {
                textBox1.IsReadOnly = false;
                textBox2.IsReadOnly = true;
                radioButton2.IsChecked = false;
            }
            else
            {
                textBox1.IsReadOnly = true;
                textBox2.IsReadOnly = false;
                radioButton2.IsChecked = true;
            }
        }

        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxGasPrice.Text != "")
            {
                if (double.TryParse(textBox2.Text, out totalGas))
                {
                    textBox1.Text = $"{(totalGas / gas_price):f2}";
                    textBlockTotalGas.Text = $"{totalGas:f2}";
                }
            }
        }

        private void UpHotdogItemsButton_Click(object sender, RoutedEventArgs e)
        {
            total_hotdg += hotdob_price;
            itemsHotdog++;
            totalFood = total_cola + total_free + total_hotdg + total_humb;
            textBlockTotalFood.Text = totalFood.ToString();
            textBlockHotdogTotal.Text = total_hotdg.ToString();
            textBlockHotdogItems.Text = itemsHotdog.ToString();
        }

        private void DownHotdogItemsButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsHotdog > 0)
            {
                total_hotdg -= hotdob_price;
                itemsHotdog--;
                if (itemsHotdog < 0)
                    itemsHotdog = 0;
                totalFood = total_cola + total_free + total_hotdg + total_humb;
                textBlockTotalFood.Text = totalFood.ToString();
                textBlockHotdogTotal.Text = total_hotdg.ToString();
                textBlockHotdogItems.Text = itemsHotdog.ToString();
            }
        }

        private void UpColaItemsButton_Click(object sender, RoutedEventArgs e)
        {
            itemsCola++;
            total_cola += cola_price;
            totalFood = total_cola + total_free + total_hotdg + total_humb;
            textBlockTotalFood.Text = totalFood.ToString();
            textBlockColaTotal.Text = total_cola.ToString();
            textBlockColaItems.Text = itemsCola.ToString();
        }

        private void DownColaItemsButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsCola > 0)
            {
                itemsCola--;
                if (itemsCola < 0)
                    itemsCola = 0;
                total_cola -= cola_price;
                totalFood = total_cola + total_free + total_hotdg + total_humb;
                textBlockTotalFood.Text = totalFood.ToString();
                textBlockColaTotal.Text = total_cola.ToString();
                textBlockColaItems.Text = itemsCola.ToString();
            }
        }

        private void DownHumbItemsButton_Click(object sender, RoutedEventArgs e)
        {
            if (itemsHumb > 0)
            {
                total_humb -= humb_price;
                itemsHumb--;
                if (itemsHumb < 0)
                    itemsHumb = 0;
                totalFood = total_cola + total_free + total_hotdg + total_humb;
                textBlockHumbTotal.Text = total_humb.ToString();
                textBlockTotalFood.Text = totalFood.ToString();
                textBlockHumbItems.Text = itemsHumb.ToString();
            }
        }

        private void TotalButton_Click(object sender, RoutedEventArgs e)
        {
            totalGas += totalFood;
            totalTextBlock.Text = $"{totalGas:f2}";
        }
    }
}
