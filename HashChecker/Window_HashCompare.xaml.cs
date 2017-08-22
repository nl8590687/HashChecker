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

namespace HashChecker
{
    /// <summary>
    /// Window_HashCompare.xaml 的交互逻辑
    /// </summary>
    public partial class Window_HashCompare : Window
    {
        public Window_HashCompare()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button_check_Click(object sender, RoutedEventArgs e)
        {
            if(textBox_Hash1.Text==textBox_Hash2.Text)
            {
                label_status.Content = "Right!";
                label_status.Foreground = Brushes.Green;
            }
            else
            {
                label_status.Content = "Wrong!";
                label_status.Foreground = Brushes.Red;
            }
        }

        private void button_reset_Click(object sender, RoutedEventArgs e)
        {
            textBox_Hash1.Clear();
            textBox_Hash2.Clear();
            label_status.Content = "Unchecked";
            label_status.Foreground = Brushes.Blue;
        }
    }
}
