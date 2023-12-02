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
using wpf_sessiya1.Pages;

namespace wpf_sessiya1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window_Tables.xaml
    /// </summary>
    public partial class Window_Tables : Window
    {
        public Window_Tables()
        {
            InitializeComponent();
        }

        private void ShowService_Click(object sender, RoutedEventArgs e)
        {
            FrameNav.Navigate(new Service_Page());
        }
    }
}
