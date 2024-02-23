using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SoftTradeTEST.MVVM.ViewModel.ProductVM
{
    internal class EditProductViewModel
    {
        public Product _selectedProduct { get; set; }

        private IUnit _unit = new Unit(new DB.DbConnection());
        public ICommand EditManagerCommand { get; set; }

        public string? Name { get; set; }
        public Models.Enum.Type? Type { get; set; }
        public Models.Enum.SubscriptionPeriod? Period { get; set; }

        public EditProductViewModel(int id)
        {
            _selectedProduct = _unit.Product.Get(id);

            EditManagerCommand = new RelayCommand(EditManager, CanEdit);
        }

        private bool CanEdit(object obj)
        {
            return true;
        }

        private void EditManager(object obj)
        {

            try
            {
                if (Name.IsNullOrEmpty())
                    throw new NullReferenceException();

                if (Name.IsNullOrEmpty() || Type.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();
                if (Type == Models.Enum.Type.Subscription && Period.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();

                if (!Name.IsNullOrEmpty() && Type == Models.Enum.Type.Permanent)
                {
                    _selectedProduct.Name = Name;
                    _selectedProduct.Type = Models.Enum.Type.Permanent;

                    _unit.Product.Add(_selectedProduct);
                }
                if (!Name.IsNullOrEmpty() && Type == Models.Enum.Type.Subscription)
                {
                    _selectedProduct.Name = Name;
                    _selectedProduct.Type = Models.Enum.Type.Subscription;
                    _selectedProduct.Period = (Models.Enum.SubscriptionPeriod)Period;
                    _unit.Product.Add(_selectedProduct);
                }

                _unit.Product.Update(_selectedProduct);
                MessageBox.Show("Успешно изменено");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}

