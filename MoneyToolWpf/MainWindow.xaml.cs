using System;
using System.Windows;
using System.Windows.Controls;

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
            tbSumma1.Text = tbSumma2.Text = "0";
            cbCurrency1.SelectedIndex = cbCurrency2.SelectedIndex = 2; // RUB
            label1.Content = label2.Content = labelCompare.Content = "";

            cbCurrency1.SelectionChanged += cbCurrency_SelectionChanged; //new System.Windows.Controls.SelectionChangedEventHandler(this.cbCurrency1_SelectionChanged);
            tbSumma1.TextChanged += tbSumma_TextChanged;
            cbCurrency2.SelectionChanged += cbCurrency_SelectionChanged;
            tbSumma2.TextChanged += tbSumma_TextChanged;
            btnCompare.Click += btnCompare_Click;
        }

        decimal summa1 = 0.00M;
        decimal summa2 = 0.00M;

        void summa1Changed()
        {
            try
            {
                summa1 = Math.Round(Int32.Parse(tbSumma1.Text) * CurrencyExtension.CurrencyRateInRubles((Currency)cbCurrency1.SelectedIndex), 2);
            }
            catch
            {
                summa1 = 0.00M;
            }
            label1.Content = $"{summa1} ₽";
            labelCompare.Content = "";
        }
        void summa2Changed()
        {
            try
            {
                summa2 = Math.Round(Int32.Parse(tbSumma2.Text) * CurrencyExtension.CurrencyRateInRubles((Currency)cbCurrency2.SelectedIndex), 2);
            }
            catch
            {
                summa2 = 0.00M;
            }
            label2.Content = $"{summa2} ₽";
            labelCompare.Content = "";
        }

        private void tbSumma_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Name == "tbSumma1")
                summa1Changed();
            else
                summa2Changed();
        }

        private void cbCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).Name == "cbCurrency1")
                summa1Changed();
            else
                summa2Changed();
        } 

        private void btnCompare_Click(object sender, RoutedEventArgs e)
        {
            labelCompare.Content =
                summa1 < summa2 ? "<" :
                summa1 > summa2 ? ">" :
                "==";
        }
    }
}
