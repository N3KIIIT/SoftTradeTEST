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
using SoftTradeTEST.Models;
using Microsoft.IdentityModel.Tokens;

namespace SoftTradeTEST.MVVM.View.ClientView
{
    /// <summary>
    /// Interaction logic for ClientEditWindow.xaml
    /// </summary>
    public partial class ClientEditWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        private Client _selectedClient = new Client();
        public ClientEditWindow()
        {
            InitializeComponent();
        }
        public ClientEditWindow(int id)
        {
            InitializeComponent();

            _selectedClient = _unit.Client.Get(id);

            Status_comboBox.ItemsSource = _unit.ClientStatus.GetAll();
            Manager_comboBox.ItemsSource = _unit.Manager.GetAll();
            Product_comboBox.ItemsSource = _unit.Product.GetAll();

            Name_textBox.Text = _selectedClient.Name;
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name_textBox.Text.IsNullOrEmpty() || Status_comboBox.SelectedValue.ToString().IsNullOrEmpty() || Manager_comboBox.SelectedValue.ToString().IsNullOrEmpty() || Product_comboBox.SelectedValue.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();

                _selectedClient.Name = Name_textBox.Text;
                _selectedClient.Status = ((ClientStatus)Status_comboBox.SelectedValue).Id.ToString();
                if ((((Manager)Manager_comboBox.SelectedValue) != null))    
                    _selectedClient.Manager = ((Manager)Manager_comboBox.SelectedValue).Id.ToString();

                
                if ((((Product)Product_comboBox.SelectedValue) != null))    
                _selectedClient.Products = ((Product)Product_comboBox.SelectedValue).ProductId.ToString();

                _unit.Client.Update(_selectedClient);
                this.Close();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}
