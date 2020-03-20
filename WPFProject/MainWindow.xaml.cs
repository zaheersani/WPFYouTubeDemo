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

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOperation_Click(object sender, RoutedEventArgs e)
        {
            int num1 = int.Parse(this.txtNum1.Text);
            int num2 = int.Parse(this.txtNum2.Text);
            Button op;
            int result = 0;
            if(sender is Button)
            {
                op = (Button)sender;
                if (op == btnSum)
                    //MessageBox.Show(num1 + "+" + num2 + "=" + (num1 + num2));
                    result = num1 + num2;
                else if (op == btnSub)
                    //MessageBox.Show(num1 + "-" + num2 + "=" + (num1 - num2));
                    result = num1 - num2;
                else if (op == btnMult)
                    //MessageBox.Show(num1 + "x" + num2 + "=" + (num1 * num2));
                    result = num1 * num2;
                else if (op == btnDiv)
                    result = num1 / num2;
                //MessageBox.Show(num1 + "/" + num2 + "=" + (num1 / num2));
                this.lblResult.Content = result;
            }
            
            // 5 + 6 = 11
            //MessageBox.Show(num1 + "+" + num2 + "=" + (num1 + num2));
        }
    }
}
