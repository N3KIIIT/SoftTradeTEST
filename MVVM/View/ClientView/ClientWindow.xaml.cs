using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
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
using SoftTradeTEST.MVVM.View.ClientView;
using SoftTradeTEST.Models.VM;

namespace SoftTradeTEST.MVVM.View
{
    /// <summary>
    /// Interaction logic for ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        private Client _selectedClient { get; set; } = null;
        private ClientVM _selectedClientVM { get; set; } = null;
        public ClientWindow()
        {
            InitializeComponent();

            Status_comboBox.ItemsSource = _unit.ClientStatus.GetAll();
            Manager_comboBox.ItemsSource = _unit.Manager.GetAll();
            Product_comboBox.ItemsSource = _unit.Product.GetAll();
            RefreshDataGridView();
        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            ClientCreateWindow clientCreateWindow = new ClientCreateWindow();
            clientCreateWindow.ShowDialog();
        }
        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedClient == null)
                    throw new NullReferenceException();


                ClientEditWindow managerWindow = new ClientEditWindow(_selectedClient.Id);
                managerWindow.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите отредактировать");
            }
        }
        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            if (_selectedClient == null)
                throw new NullReferenceException();


            MessageBoxResult result = MessageBox.Show("Вы уверены", "Подтвердить", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                _unit.Client.Remove(_selectedClient);

            RefreshDataGridView();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите удалить");
            }
        }
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _selectedClientVM = ((ClientVM)DataGrid.SelectedValue);
            if(_selectedClientVM != null)
            _selectedClient =(_unit.Client.Get(_selectedClientVM.Id));
        }
        private void RefreshDataGridView()
        {
        List<ClientVM> _clientVmList = new List<ClientVM>();

            foreach (var item in _unit.Client.GetAll())
            {
                var clientVM = new ClientVM();

                clientVM.Id = item.Id;
                clientVM.Name = item.Name;
                clientVM.Status = (from Status in _unit.ClientStatus.GetAll()
                                                 where Status.Id.ToString() == item.Status
                                                 select (Status)).FirstOrDefault();
                clientVM.Manager = (from Manager in _unit.Manager.GetAll()
                                             where Manager.Id.ToString() == item.Manager
                                             select (Manager)).FirstOrDefault();
                clientVM.Products = (from Product in _unit.Product.GetAll()
                                              where Product.ProductId.ToString() == item.Products
                                              select Product).FirstOrDefault();

                _clientVmList.Add(clientVM);
            }
            DataGrid.ItemsSource = _clientVmList;
            _selectedClient = null;
            _selectedClientVM = null;
        }
        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGridView();
        }
        private void SortByStatus_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Status_comboBox.SelectedValue == null)
                    throw new NullReferenceException();


                List<ClientVM> _clientVmList = new List<ClientVM>();

                foreach (var item in _unit.Client.GetAll().Where(o => o.Status == ((ClientStatus)Status_comboBox.SelectedValue).Id.ToString()))
                {
                    var clientVM = new ClientVM();

                    clientVM.Id = item.Id;
                    clientVM.Name = item.Name;
                    clientVM.Status = (from Status in _unit.ClientStatus.GetAll()
                                       where Status.Id.ToString() == item.Status
                                       select (Status)).FirstOrDefault();
                    clientVM.Manager = (from Manager in _unit.Manager.GetAll()
                                        where Manager.Id.ToString() == item.Manager
                                        select (Manager)).FirstOrDefault();
                    clientVM.Products = (from Product in _unit.Product.GetAll()
                                         where Product.ProductId.ToString() == item.Products
                                         select Product).FirstOrDefault();

                    _clientVmList.Add(clientVM);
                }
                DataGrid.ItemsSource = _clientVmList;
                _selectedClient = null;
                _selectedClientVM = null;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выбирите статус по которому хотите отсортировать");
            }
        }
        private void SortByManagers_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Manager_comboBox.SelectedValue == null)
                    throw new NullReferenceException();
                List<ClientVM> _clientVmList = new List<ClientVM>();

                foreach (var item in _unit.Client.GetAll().Where(o => o.Manager == ((Manager)Manager_comboBox.SelectedValue).Id.ToString()))
                {
                    var clientVM = new ClientVM();

                    clientVM.Id = item.Id;
                    clientVM.Name = item.Name;
                    clientVM.Status = (from Status in _unit.ClientStatus.GetAll()
                                       where Status.Id.ToString() == item.Status
                                       select (Status)).FirstOrDefault();
                    clientVM.Manager = (from Manager in _unit.Manager.GetAll()
                                        where Manager.Id.ToString() == item.Manager
                                        select (Manager)).FirstOrDefault();
                    clientVM.Products = (from Product in _unit.Product.GetAll()
                                         where Product.ProductId.ToString() == item.Products
                                         select Product).FirstOrDefault();

                    _clientVmList.Add(clientVM);
                }
                DataGrid.ItemsSource = _clientVmList;
                _selectedClient = null;
                _selectedClientVM = null;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выбирите менеджера по которому хотите отсортировать");
            }
        }
        private void SortByProducts_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Product_comboBox.SelectedValue == null)
                    throw new NullReferenceException();

                List<ClientVM> _clientVmList = new List<ClientVM>();

                foreach (var item in _unit.Client.GetAll().Where(o => o.Products == ((Product)Product_comboBox.SelectedValue).ProductId.ToString()))
                {
                    var clientVM = new ClientVM();

                    clientVM.Id = item.Id;
                    clientVM.Name = item.Name;
                    clientVM.Status = (from Status in _unit.ClientStatus.GetAll()
                                       where Status.Id.ToString() == item.Status
                                       select (Status)).FirstOrDefault();
                    clientVM.Manager = (from Manager in _unit.Manager.GetAll()
                                        where Manager.Id.ToString() == item.Manager
                                        select (Manager)).FirstOrDefault();
                    clientVM.Products = (from Product in _unit.Product.GetAll()
                                         where Product.ProductId.ToString() == item.Products
                                         select Product).FirstOrDefault();

                    _clientVmList.Add(clientVM);
                }
                DataGrid.ItemsSource = _clientVmList;
                _selectedClient = null;
                _selectedClientVM = null;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выбирите продукт по которому хотите отсортировать");
            }
        }
    }
}
