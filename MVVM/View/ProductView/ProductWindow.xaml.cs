using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System.Windows;
using System.Windows.Controls;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ProductVM;

namespace SoftTradeTEST.MVVM.View.ProductView
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public ProductWindow()
        {
            InitializeComponent();

            ProductViewModel productViewModel = new ProductViewModel();
            this.DataContext = productViewModel;

        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();
        }
 
        private void RefreshDataGridView()
        {
            DataGrid.ItemsSource = _unit.Product.GetAll();
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
