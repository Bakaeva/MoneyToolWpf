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

            cbCurrency1.SelectionChanged += MainWindow_SummaChanged; // (sender, args) => SummaChanged(sender, args);
            tbSumma1.TextChanged += MainWindow_SummaChanged; // (sender, args) => SummaChanged(sender, args);
            cbCurrency2.SelectionChanged += MainWindow_SummaChanged; // (sender, args) => SummaChanged(sender, args);
            tbSumma2.TextChanged += MainWindow_SummaChanged; // (sender, args) => SummaChanged(sender, args);

            //SummaChanged += new EventHandler(MainWindow_SummaChanged);
        }

        decimal summa1 = 0.00M;
        decimal summa2 = 0.00M;

        //event EventHandler SummaChanged;
        
        void MainWindow_SummaChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox && (sender as ComboBox).Name == "cbCurrency1"
                || sender is TextBox && (sender as TextBox).Name == "tbSumma1")
            {
                try
                {
                    summa1 = Math.Round(Int32.Parse(tbSumma1.Text) * CurrencyExtensions.CurrencyRateInRubles((Currency)cbCurrency1.SelectedIndex), 2);
                }
                catch
                {
                    summa1 = 0.00M;
                }
                label1.Content = $"{summa1} ₽";
            }
            else // if (sender is ComboBox && (sender as ComboBox).Name == "cbCurrency2" || sender is TextBox && (sender as TextBox).Name == "tbSumma2")
            {
                try
                {
                    summa2 = Math.Round(Int32.Parse(tbSumma2.Text) * CurrencyExtensions.CurrencyRateInRubles((Currency)cbCurrency2.SelectedIndex), 2);
                }
                catch
                {
                    summa2 = 0.00M;
                }
                label2.Content = $"{summa2} ₽";
            }

            labelCompare.Content =
                summa1 < summa2 ? "<" :
                summa1 > summa2 ? ">" :
                "==";
        }
    }
}
