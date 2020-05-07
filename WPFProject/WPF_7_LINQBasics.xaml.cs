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

    enum Country { USA, UK, Pakistan }
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Country Country { get; set; }
    }

    /// <summary>
    /// Interaction logic for WPFLINQBasics.xaml
    /// </summary>
    public partial class WPFLINQBasics : Window
    {
        public WPFLINQBasics()
        {

            InitializeComponent();
            StringBuilder sb = new StringBuilder();
            List<Student> sList = new List<Student>()
            {
                new Student()
                {
                    Name = "John",
                    Age = 25,
                    Country = Country.USA
                },
                new Student()
                {
                    Name = "Ahmed",
                    Age = 20,
                    Country = Country.USA
                },
                new Student()
                {
                    Name = "Zaheer",
                    Age = 24,
                    Country = Country.Pakistan
                },
            };
            var result = from s in sList
                         where s.Name.Contains("e")
                         orderby s.Name
                         select s;

            foreach (var item in result)
            {
                sb.AppendLine(item.Name + " Age: " + item.Age + " Country:" + item.Country);
            }

            lblOutput.Content = sb;
        }

        public void LINQonStrings()
        {
            StringBuilder sb = new StringBuilder();
            List<string> names = new List<string>() { "John", "Bengston", "Ahmed", "Michael", "David", "Zeeshan" };

            IEnumerable<string> result = from n in names
                                         where n.Length <= 5
                                         orderby n
                                         select n;

            foreach (string name in result)
            {
                sb.AppendLine(name);
            }

            lblOutput.Content = sb;
        }

        public void LINQonInt()
        {
            StringBuilder sb = new StringBuilder();

            int[] nums = new int[] { 3, 5, 4, 6, 7, 8, 9, 2, 4, 5, 6, 7, 822, 776, 88 };

            var result = from n in nums
                         where n > 2 && n < 100 && n != 5
                         orderby n descending
                         select n;

            //IEnumerable<int> result = nums.Where(n => n > 2 && n < 100)
            //    .OrderByDescending(n => n)
            //    .Distinct();

            sb.AppendLine("Max:" + result.Max());
            sb.AppendLine("Min:" + result.Min());
            sb.AppendLine("Average:" + result.Average());

            Console.WriteLine("Max:" + result.Max());
            Console.WriteLine("Min:" + result.Min());
            Console.WriteLine("Average:" + result.Average());

            foreach (var item in result)
            {
                sb.AppendLine(item.ToString());
                Console.WriteLine(item);
            }

            lblOutput.Content = sb;
        }
    }
}
