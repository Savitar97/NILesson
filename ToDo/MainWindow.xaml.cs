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

namespace ToDo
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
        /*
        private void AddClick(object sender, RoutedEventArgs e)
        {
            if (! string.IsNullOrWhiteSpace(toDoTextBox.Text))
            {
                toDoListView.Items.Add(toDoTextBox.Text);
            }
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (toDoListView.SelectedItem != null)
            {
                toDoListView.Items.Remove(toDoListView.SelectedItem);
            }
        }*/
    }
}
