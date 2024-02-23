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

namespace SoftTradeTEST.MVVM.ViewModel.ClientVM
{
    internal class CreateClientViewModel
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public ICommand CreateClientCommand { get; set; }
        public string? Name { get; set; }
        public ClientStatus? Status { get; set; }
        public Manager? Manager { get; set; }
        public Product? Product { get; set; }

        public CreateClientViewModel()
        {
            CreateClientCommand = new RelayCommand(CreateClient, CanCreateClient);
        }

        private bool CanCreateClient(object obj)
        {
            return true;
        }

        private void CreateClient(object obj)
        {
            try
            {
                if (Name.IsNullOrEmpty() || Status.ToString().IsNullOrEmpty() || Manager.Id.ToString().IsNullOrEmpty() || Product.ProductId.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();


                Client client = new Client();


                client.Name = Name;
                client.Status = Status.Id.ToString();
                if ((Manager != null))
                    client.Manager = Manager.Id.ToString();
                else
                    client.Manager = null!;

                if ((Product != null))
                    client.Products = Product.ProductId.ToString();
                else
                    client.Products = null!;

                _unit.Client.Add(client);
                MessageBox.Show("Создано успешно");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}
