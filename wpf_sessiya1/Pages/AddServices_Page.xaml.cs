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
using wpf_sessiya1.DbModels;
using Service = wpf_sessiya1.DbModels.Service;

namespace wpf_sessiya1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddServices_Page.xaml
    /// </summary>
    public partial class AddServices_Page : Page
    {
        Service service;
        public AddServices_Page(Service srv)
        {
            this.service = srv;
            DataContext = service;
            InitializeComponent();
        }

        private void Button_SaveClick(object sender, RoutedEventArgs e)
        {     
            if(service.Id == 0)
            {
                CoreModel.init().Services.Add(service);
            }                   
            CoreModel.init().SaveChanges();
            NavigationService.GoBack();
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
