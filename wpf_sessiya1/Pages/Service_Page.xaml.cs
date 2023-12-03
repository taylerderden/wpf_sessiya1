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
using wpf_sessiya1.Windows;

namespace wpf_sessiya1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Service_Page.xaml
    /// </summary>
    public partial class Service_Page : Page
    {
        Service service;
        public Service_Page()
        {
            InitializeComponent();
            lViewService.ItemsSource = CoreModel.init().Services.ToList();

            DataContext = service;

            cbSort.Items.Add("Дешевле");
            cbSort.Items.Add("Дороже");

            cbFiltr.Items.Add("Установка");
            cbFiltr.Items.Add("Оптимизация");
            cbFiltr.Items.Add("Все");
        }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddServices_Page(new Service()));
        }

        private void Button_DelClick(object sender, RoutedEventArgs e)
        {
            if (lViewService.SelectedItems.Count > 1)
            {
                return;
            }

            Service SerDel = lViewService.SelectedItem as Service;

            if (MessageBox.Show("Delete?", "Realy delete?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CoreModel.init().Services.Remove(SerDel);
                CoreModel.init().SaveChanges();
                Update();
            }
        }

        private void Button_UpdateClick(object sender, RoutedEventArgs e)
        {
            //if (service.Id != 0)
            //{
            //    CoreModel.init().Entry(service).Reload();
            //    Service serviceEdit = lViewService.SelectedItem as Service;
            //    NavigationService.Navigate(new AddServices_Page(serviceEdit));
            //}
            //else 
            //{
            //    MessageBox.Show("Кликни по услуге, а потом редактируй");
            //}
            //CoreModel.init().Entry(service).Reload();
            Service serviceEdit = lViewService.SelectedItem as Service;
            NavigationService.Navigate(new AddServices_Page(serviceEdit));
        }

        private void tbSearchChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSearch();
        }

        private void cbSortChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSearch();
        }

        private void cbFiltrChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSearch();
        }

        private void Update()
        {
            lViewService.ItemsSource = CoreModel.init().Services.ToList();
        }
        private void UpdateSearch()
        {
            IEnumerable<Service> services = CoreModel.init().Services.Where(p => p.Title.Contains(tbSearch.Text));

            switch (cbSort.SelectedIndex)
            {
                case 0:
                    services = services.OrderBy(p => p.Cost);
                    break;
                case 1:
                    services = services.OrderByDescending(p => p.Cost);
                    break;
            }

            if (cbFiltr.SelectedItem == "Установка")
            {
                services = CoreModel.init().Services.Where(p => p.Title.Contains("Установка"));
            }
            else if (cbFiltr.SelectedItem == "Оптимизация")
            {
                services = CoreModel.init().Services.Where(p => p.Title.Contains("Оптимизация"));
            }
            else
            {
                Update();
            }

            lViewService.ItemsSource = services.ToList();
        }

        private void AddServices_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Update();
        }
    }
}
