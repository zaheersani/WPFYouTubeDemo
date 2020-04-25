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
    public class ExitKey : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //MessageBox.Show("Ctrl+X");
            Application.Current.Shutdown();
        }
    }

    public class WrapKey : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public object UIElement { get; set; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(UIElement.GetType() == typeof(TextBox))
            {
                if (((TextBox)UIElement).TextWrapping == TextWrapping.Wrap)
                    ((TextBox)UIElement).TextWrapping = TextWrapping.NoWrap;
                else
                    ((TextBox)UIElement).TextWrapping = TextWrapping.Wrap;
            }
            //foreach (Window win in Application.Current.Windows)
            //{
            //    if(win.GetType() == typeof(WPFMenus))
            //    {
            //        if(((WPFMenus)win).txtBox.TextWrapping == TextWrapping.Wrap)
            //            ((WPFMenus)win).txtBox.TextWrapping = TextWrapping.NoWrap;
            //        else
            //            ((WPFMenus)win).txtBox.TextWrapping = TextWrapping.Wrap;
            //    }
            //}
        }
    }

    public class CommandsContext
    {
        public object objForWrapKey { get; set; }
        public ICommand ExitCommand
        {
            get
            {
                return new ExitKey();
            }
        }
        public ICommand WrapCommand
        {
            get
            {
                return new WrapKey()
                {
                    UIElement = objForWrapKey
                };
            }
        }
    }

    /// <summary>
    /// Interaction logic for WPFMenus.xaml
    /// </summary>
    public partial class WPFMenus : Window
    {
        public WPFMenus()
        {
            InitializeComponent();
            this.DataContext = new CommandsContext()
            {
                objForWrapKey = this.txtBox
            };
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void CommandBindingNew_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBindingNew_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New MenuItem Clicked!");
        }

        private void CommandBindingOpen_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBindingOpen_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open MenuItem Clicked!");
        }
    }
}
