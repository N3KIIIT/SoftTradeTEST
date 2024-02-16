using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.Models;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
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

namespace SoftTradeTEST.MVVM.View.ClientView
{
    /// <summary>
    /// Interaction logic for ClientCreateWindow.xaml
    /// </summary>
    public partial class ClientCreateWindow : Window
    {

        private IUnit _unit = new Unit();
        public ClientCreateWindow()
        {
            InitializeComponent();

            Status_comboBox.ItemsSource = _unit.ClientStatus.GetAll();
            Manager_comboBox.ItemsSource = _unit.Manager.GetAll();
            Product_comboBox.ItemsSource = _unit.Product.GetAll();
        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name_textBox.Text.IsNullOrEmpty() || Status_comboBox.SelectedValue.ToString().IsNullOrEmpty() || Manager_comboBox.SelectedValue.ToString().IsNullOrEmpty() || Product_comboBox.SelectedValue.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();



                Client client = new Client();


                client.Name = Name_textBox.Text;
                client.Status = ((ClientStatus)Status_comboBox.SelectedValue).Id.ToString();
                if ((((Manager)Manager_comboBox.SelectedValue) != null))
                    client.Manager = (((Manager)Manager_comboBox.SelectedValue).Id).ToString();
                else
                    client.Manager = null!;

                if ((((Product)Product_comboBox.SelectedValue) != null))
                    client.Products = ((Product)Product_comboBox.SelectedValue).ProductId.ToString();
                else
                    client.Products = null!; 

                _unit.Client.Add(client);
                this.Close();

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
