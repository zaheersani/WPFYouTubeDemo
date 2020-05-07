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
    /// Interaction logic for WPFDataBinding.xaml
    /// </summary>
    public partial class WPFDataBinding : Window
    {
        List<Contact> listContact;
        public WPFDataBinding()
        {
            InitializeComponent();
            List<string> listNames = new List<string>()
            {
                "John", "David", "Tim", "Kevin"
            };
            listContact = new List<Contact>()
            {
                new Contact()
                {
                    Name = "John",
                    Number = "+4680980980"
                },
                new Contact()
                {
                    Name = "David",
                    Number = "+1453453535"
                }
            };
            this.listBoxNames.ItemsSource = listContact;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in this.listContact)
            {
                Console.WriteLine(item.Name);
            }
            this.listBoxNames.Items.Refresh();
             
        }
    }
    public class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public override string ToString()
        {
            return this.Name + " (" + this.Number + ")";
        }
    }
}
