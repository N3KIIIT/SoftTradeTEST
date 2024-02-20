using SoftTradeTEST.Models;
using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System.Windows;
using System.Windows.Controls;
using SoftTradeTEST.AppDbConetext;


namespace SoftTradeTEST.MVVM.View.ProductView
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private readonly IUnit _unit = new Unit(new AppDbConetext.Context());
        private Product _selectedProduct { get; set; }
        public ProductWindow()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            ProductCreateWindow productCreateWindow = new ProductCreateWindow();
            productCreateWindow.ShowDialog();
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedProduct == null)
                    throw new NullReferenceException();


                ProductEditWindow productEditWindow = new ProductEditWindow(_selectedProduct.ProductId);
                productEditWindow.ShowDialog();
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
                if (_selectedProduct == null)
                    throw new NullReferenceException();


                MessageBoxResult result = MessageBox.Show("Вы уверены", "Подтвердить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    _unit.Product.Remove(_selectedProduct);
                    _unit.Save();
                }
                RefreshDataGridView();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите отредактировать");
            }
        }
        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _selectedProduct = (Product)DataGrid.SelectedValue;
        }
        private void RefreshDataGridView()
        {
            DataGrid.ItemsSource = _unit.Product.GetAll();
            _selectedProduct = null;
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
