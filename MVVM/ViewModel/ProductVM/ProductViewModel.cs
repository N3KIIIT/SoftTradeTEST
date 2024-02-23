using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.View.ClientView;
using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SoftTradeTEST.MVVM.View.ProductView;
using System.Windows;

namespace SoftTradeTEST.MVVM.ViewModel.ProductVM
{
    internal class ProductViewModel
    {
        private readonly IUnit _unit = new Unit(new DB.DbConnection());

        public Product? SelectedProduct { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public ICommand CreateProductWindowCommand { get; set; }
        public ICommand EditProductWindowCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ProductViewModel()
        {
            Products = _unit.Product.GetAll();

            CreateProductWindowCommand = new RelayCommand(CreateProductWindow, CanShowWindow);
            EditProductWindowCommand = new RelayCommand(EditProductWindow, CanShowWindow);
            DeleteProductCommand = new RelayCommand(DeleteProduct, CanShowWindow);
        }

        private void CreateProductWindow(object obj)
        {
            ProductCreateWindow editManagerWindow = new ProductCreateWindow();
            editManagerWindow.ShowDialog();
        }
        private void EditProductWindow(object obj)
        {
            ProductEditWindow editManagerWindow = new ProductEditWindow(SelectedProduct.ProductId);
            editManagerWindow.ShowDialog();
        }

        private void DeleteProduct(object obj)
        {
            try
            {
                if (SelectedProduct == null)
                    throw new NullReferenceException();

                MessageBoxResult result = MessageBox.Show("Вы уверены", "Подтвердить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    _unit.Product.Remove(SelectedProduct);


            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите удалить");
            }
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }
    }
}
