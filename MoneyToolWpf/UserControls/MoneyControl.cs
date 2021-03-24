using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoneyToolWpf.UserControls
{
    public partial class MoneyControl : UserControl
    {
        public MoneyControl()
        {
            InitializeComponent();

            cbCurrency.DataSource = Enum.GetValues(typeof(MoneyToolWpf.Currency));
        }
    }
}
