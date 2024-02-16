using SoftTradeTEST.DB;
using SoftTradeTEST.Models;
using System.Windows;
using SoftTradeTEST.Models.Enum;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using Type = SoftTradeTEST.Models.Enum.Type;
using Microsoft.VisualBasic.ApplicationServices;
using System.Collections.ObjectModel;
using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.MVVM.View;
using SoftTradeTEST.MVVM.View.ManagerView;
using SoftTradeTEST.MVVM.View.ProductView;

namespace SoftTradeTEST
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
        }

        private void Managers_button_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.ShowDialog();
        }

        private void Clients__button_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.ShowDialog();
        }

        private void Products_button_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.ShowDialog();
        }
    }
}