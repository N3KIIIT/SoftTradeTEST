using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ClientVM;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using System.Windows;

namespace SoftTradeTEST.MVVM.View.ClientView
{
    /// <summary>
    /// Interaction logic for ClientCreateWindow.xaml
    /// </summary>
    public partial class ClientCreateWindow : Window
    {

        private IUnit _unit = new Unit(new DB.DbConnection());
        public ClientCreateWindow()
        {
            InitializeComponent();
            CreateClientViewModel createClientViewModel = new CreateClientViewModel();
            this.DataContext = createClientViewModel;

            Status_comboBox.ItemsSource = _unit.ClientStatus.GetAll();
            Manager_comboBox.ItemsSource = _unit.Manager.GetAll();
            Product_comboBox.ItemsSource = _unit.Product.GetAll();
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
