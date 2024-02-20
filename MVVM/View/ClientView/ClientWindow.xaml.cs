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

        private IUnit _unit = new Unit(new AppDbConetext.Context());

        private Client _selectedClient { get; set; } = null;
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
                {
                    _unit.Client.Remove(_selectedClient);
                    _unit.Save();
                }
                RefreshDataGridView();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите удалить");
            }
        }
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _selectedClient = ((Client)DataGrid.SelectedValue);
            if (_selectedClient != null)
                _selectedClient = (_unit.Client.Get(o => o.Id == _selectedClient.Id));
        }
        private void RefreshDataGridView()
        {
            var clientList = new List<Client>();

            clientList.AddRange(_unit.Client.GetAll());

            DataGrid.ItemsSource = clientList;
            _selectedClient = null;
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

                var clientList = new List<Client>();

                clientList.AddRange(_unit.Client.GetAll().Where(o => o.Status == Status_comboBox.SelectedValue));

                DataGrid.ItemsSource = clientList;
                _selectedClient = null;

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
                var clientList = new List<Client>();

                clientList.AddRange(_unit.Client.GetAll().Where(o => o.Manager == Manager_comboBox.SelectedValue));

                DataGrid.ItemsSource = clientList;
                _selectedClient = null;

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

                var clientList = new List<Client>();

                clientList.AddRange(_unit.Client.GetAll().Where(o => o.Products == Product_comboBox.SelectedValue));

                DataGrid.ItemsSource = clientList;
                _selectedClient = null;

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выбирите продукт по которому хотите отсортировать");
            }
        }
    }
}
