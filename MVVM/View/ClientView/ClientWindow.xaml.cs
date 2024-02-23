using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System.Windows;
using System.Windows.Controls;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ClientVM;

namespace SoftTradeTEST.MVVM.View
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public ClientWindow()
        {
            InitializeComponent();


            Status_comboBox.ItemsSource = _unit.ClientStatus.GetAll();
            Manager_comboBox.ItemsSource = _unit.Manager.GetAll();
            Product_comboBox.ItemsSource = _unit.Product.GetAll();

            ClientViewModel clientViewModel = new ClientViewModel();
            this.DataContext = clientViewModel;

            RefreshDataGrid();
        }

        private void Status_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                List<Client> clientList = new List<Client>();

                foreach (var item in _unit.Client.GetAll().Where(o => o.Status == ((ClientStatus)Status_comboBox.SelectedValue).Id.ToString()))
                {
                    var client = new Client();

                    client.Id = item.Id;
                    client.Name = item.Name;
                    client.Status = (from Status in _unit.ClientStatus.GetAll()
                                       where Status.Id.ToString() == item.Status
                                       select (Status.Status)).FirstOrDefault();
                    client.Manager = (from Manager in _unit.Manager.GetAll()
                                        where Manager.Id.ToString() == item.Manager
                                        select (Manager.Name)).FirstOrDefault();
                    client.Products = (from Product in _unit.Product.GetAll()
                                         where Product.ProductId.ToString() == item.Products
                                         select Product.Name).FirstOrDefault();

                    clientList.Add(client);
                }
                DataGrid.ItemsSource = clientList;

        }
        private void Manager_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Client> clientList = new List<Client>();
            foreach (var item in _unit.Client.GetAll().Where(o => o.Manager == ((Manager)Manager_comboBox.SelectedValue).Id.ToString()))
            {
                var client = new Client();

                client.Id = item.Id;
                client.Name = item.Name;
                client.Status = (from Status in _unit.ClientStatus.GetAll()
                                   where Status.Id.ToString() == item.Status
                                   select (Status.Status)).FirstOrDefault();
                client.Manager = (from Manager in _unit.Manager.GetAll()
                                    where Manager.Id.ToString() == item.Manager
                                    select (Manager.Name)).FirstOrDefault();
                client.Products = (from Product in _unit.Product.GetAll()
                                     where Product.ProductId.ToString() == item.Products
                                     select Product.Name).FirstOrDefault();

                clientList.Add(client);
            }
            DataGrid.ItemsSource = clientList;
        }
        private void Product_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Client> clientList = new List<Client>();

            foreach (var item in _unit.Client.GetAll().Where(o => o.Products == ((Product)Product_comboBox.SelectedValue).ProductId.ToString()))
            {
                var client = new Client();

                client.Id = item.Id;
                client.Name = item.Name;
                client.Status = (from Status in _unit.ClientStatus.GetAll()
                                   where Status.Id.ToString() == item.Status
                                   select (Status.Status)).FirstOrDefault();
                client.Manager = (from Manager in _unit.Manager.GetAll()
                                    where Manager.Id.ToString() == item.Manager
                                    select (Manager.Name)).FirstOrDefault();
                client.Products = (from Product in _unit.Product.GetAll()
                                     where Product.ProductId.ToString() == item.Products
                                     select Product.Name).FirstOrDefault();

                clientList.Add(client);
            }
            DataGrid.ItemsSource = clientList;
        }

        private void RefreshDataGrid()
        {
            var clients = new List<Client>();
            foreach (var item in _unit.Client.GetAll())
            {
                Client client = new Client();

                client.Id = item.Id;
                client.Name = item.Name;
                client.Status = (from Status in _unit.ClientStatus.GetAll()
                                 where Status.Id.ToString() == item.Status
                                 select (Status.Status)).FirstOrDefault();
                client.Manager = (from Manager in _unit.Manager.GetAll()
                                  where Manager.Id.ToString() == item.Manager
                                  select (Manager.Name)).FirstOrDefault();
                client.Products = (from Product in _unit.Product.GetAll()
                                   where Product.ProductId.ToString() == item.Products
                                   select Product.Name).FirstOrDefault();

                clients.Add(client);
            }
            DataGrid.ItemsSource = clients;
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGrid();
        }
    }
}
