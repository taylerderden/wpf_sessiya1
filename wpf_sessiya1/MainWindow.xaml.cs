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
using MySqlConnector;
using wpf_sessiya1.Windows;

namespace wpf_sessiya1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Server = cfif31.ru; Port = 3306; User ID = ISPr23-35_ZlobinDS; Database = ISPr23-35_ZlobinDS_sessiya1; Password = ISPr23-35_ZlobinDS; Character Set = utf8
        }

        private void Authorization_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text == null || tbPassword.Text == null)
            {
                MessageBox.Show("Заполните данные для входа!");
            }
            else
            {
                User
            }
            Window_Tables window_Tables = new Window_Tables();
            window_Tables.Show();
            Hide();
        }
    }
}
