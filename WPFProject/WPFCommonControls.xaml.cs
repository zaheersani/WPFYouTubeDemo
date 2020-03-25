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

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for WPFCommonControls.xaml
    /// </summary>
    public partial class WPFCommonControls : Window
    {
        public WPFCommonControls()
        {
            InitializeComponent();
            foreach (RadioButton item in this.gridGender.Children)
            {
                if(item.IsChecked == true)
                    Console.WriteLine("User Selected " + item.Content + " gender");
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (this.comboCity.SelectedIndex >= 0)
            {
                ComboBoxItem item = (ComboBoxItem)this.comboCity.SelectedItem;
                MessageBox.Show(item.Content.ToString());
            }
            if (this.listBoxCountry.SelectedIndex >= 0)
            {
                MessageBox.Show("Country:" +
                ((ListBoxItem)this.listBoxCountry.SelectedItem).Content.ToString());
            }

            MessageBox.Show(this.calendar.SelectedDate.Value.ToString("MMMM dd"));
        }
    }
}
