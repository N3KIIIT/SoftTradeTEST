using SoftTradeTEST.Commands;
using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SoftTradeTEST.MVVM.Models;
using Microsoft.IdentityModel.Tokens;
using System.Windows;

namespace SoftTradeTEST.MVVM.ViewModel.ProductVM
{
    internal class CreateProductViewModel
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public ICommand CreateProductCommand { get; set; }
        public string? Name { get; set; }
        public Models.Enum.Type? Type { get; set; } 
        public Models.Enum.SubscriptionPeriod? Period { get; set; } 

        public CreateProductViewModel()
        {
            CreateProductCommand = new RelayCommand(CreateClient, CanCreateClient);
        }

        private bool CanCreateClient(object obj)
        {
            return true;
        }

        private void CreateClient(object obj)
        {
            try
            {
                Product product = new Product();

                if (Name.IsNullOrEmpty() || Type.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();
                if (Type == Models.Enum.Type.Subscription && Period.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();

                if (!Name.IsNullOrEmpty() && Type == Models.Enum.Type.Permanent)
                {
                    product.Name = Name;
                    product.Type = Models.Enum.Type.Permanent;

                    _unit.Product.Add(product);
                }
                if (!Name.IsNullOrEmpty() && Type == Models.Enum.Type.Subscription)
                {
                    product.Name = Name;
                    product.Type = Models.Enum.Type.Subscription;
                    product.Period = (Models.Enum.SubscriptionPeriod)Period;
                    _unit.Product.Add(product);
                    MessageBox.Show("Успешно создано");
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}
