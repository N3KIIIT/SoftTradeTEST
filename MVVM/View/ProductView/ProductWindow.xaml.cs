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

namespace SoftTradeTEST.MVVM.View.ProductView
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private IUnit _unit = new Unit();
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
                    _unit.Product.Remove(_selectedProduct);

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
