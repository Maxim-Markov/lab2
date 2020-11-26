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
using System.Collections;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DetailedThreadWindow.xaml
    /// </summary>
    public partial class DetailedThreadWindow : Window
    {
        public DetailedThreadWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void CloseDetailedWindowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
