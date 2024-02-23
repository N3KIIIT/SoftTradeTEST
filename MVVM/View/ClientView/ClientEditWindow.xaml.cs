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
using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ClientVM;

namespace SoftTradeTEST.MVVM.View.ClientView
{
    /// <summary>
    /// Interaction logic for ClientEditWindow.xaml
    /// </summary>
    public partial class ClientEditWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public ClientEditWindow(int id)
        {
            InitializeComponent();

            EditClientViewModel createClientViewModel = new EditClientViewModel(id);
            this.DataContext = createClientViewModel;

            Status_comboBox.ItemsSource = _unit.ClientStatus.GetAll();
            Manager_comboBox.ItemsSource = _unit.Manager.GetAll();
            Product_comboBox.ItemsSource = _unit.Product.GetAll();

            Name_textBox.Text = _unit.Client.Get(id).Name;
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
