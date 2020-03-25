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
    enum Cities { Islamabad, Peshawar }
    class Contact
    {
        public string Name { get; set;}
        public string Number { get; set; }
        public string Email { get; set; }
        public override string ToString()
        {
            return this.Name + "(" + this.Number + ")";
        }
    }
    
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {

            InitializeComponent();

            foreach (RadioButton r in this.gridGender.Children)
                Console.WriteLine(r.Content + " is checked? " + r.IsChecked);

            List<string> cities = new List<string>() { "Islamabad", "Lahore", "Karachi" };
            List<Contact> contacts = new List<Contact>()
            {
                new Contact()
                {
                    Name = "John",
                    Number = "+4682093480289898",
                },
                new Contact()
                {
                    Name = "David",
                    Number = "+134928",
                }
            };

            this.combo.ItemsSource = contacts;
            this.dataGrid.ItemsSource = contacts;
            

            cities.Add("Peshawar");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.combo.Items.Refresh();
        }
    }
}
