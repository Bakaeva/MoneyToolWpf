using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MoneyToolWpf.UserControls;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyToolWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            cbCurrency1.ItemsSource = Enum.GetValues(typeof(MoneyToolWpf.Currency));
            cbCurrency2.ItemsSource = Enum.GetValues(typeof(MoneyToolWpf.Currency));
            cbCurrency1.SelectedIndex = cbCurrency2.SelectedIndex = 2;
            tbSumma1.Text = tbSumma2.Text = "0";
            cbCurrency1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbCurrency1_SelectionChanged);
            tbSumma1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbSumma1_TextChanged);
            cbCurrency2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbCurrency2_SelectionChanged);
            tbSumma2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbSumma2_TextChanged);
        }

        void label1Refresh()
        {
            var summa = Math.Round(Int32.Parse(tbSumma1.Text) * CurrencyExtension.CurrencyRateInRubles((Currency)cbCurrency1.SelectedIndex), 2);
            label1.Content = $"{summa} ₽";
        }
        void label2Refresh()
        {
            var summa = Math.Round(Int32.Parse(tbSumma2.Text) * CurrencyExtension.CurrencyRateInRubles((Currency)cbCurrency2.SelectedIndex), 2);
            label2.Content = $"{summa} ₽";
        }

        private void cbCurrency1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            label1Refresh();
        }

        private void tbSumma1_TextChanged(object sender, TextChangedEventArgs e)
        {
            label1Refresh();
        }

        private void cbCurrency2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            label2Refresh();
        }

        private void tbSumma2_TextChanged(object sender, TextChangedEventArgs e)
        {
            label2Refresh();
        }
    }
}
