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
using wpf_sessiya1.DbModels;

namespace wpf_sessiya1.Windows
{
    /// <summary>
    /// Логика взаимодействия для Add_Window.xaml
    /// </summary>
    public partial class Add_Window : Window
    {
        Service service;
        public Add_Window(Service srv)
        {
            InitializeComponent();
            this.service = srv;
            DataContext = service;
            //lViewService.ItemsSource = CoreModel.init().Services.ToList();
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {
            if (service.Id == 0)
            {
                CoreModel.init().Services.Add(service);
            }

            CoreModel.init().SaveChanges();
        }
        private void AddServices_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (service.Id != 0)
            {
                CoreModel.init().Entry(service).Reload();
            }

        }
    }
}
