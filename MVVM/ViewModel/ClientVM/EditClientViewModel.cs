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

namespace SoftTradeTEST.MVVM.ViewModel.ClientVM
{
    internal class EditClientViewModel
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public Client _selectedClient { get; set; }
        public ICommand EditClientCommand { get; set; }

        public string? Name { get; set; }
        public ClientStatus? Status { get; set; }
        public Manager? Manager { get; set; }
        public Product? Product { get; set; }

        public EditClientViewModel(int id)
        {
            _selectedClient = _unit.Client.Get(id);

            EditClientCommand = new RelayCommand(EditManager, CanEdit);
        }

        private bool CanEdit(object obj)
        {
            return true;
        }

        private void EditManager(object obj)
        {

            try
            {
                if (Name.IsNullOrEmpty() || Status.Id.ToString().IsNullOrEmpty() || Manager.Id.ToString().IsNullOrEmpty() || Product.ProductId.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();

                _selectedClient.Name = Name;
                _selectedClient.Status = Status.Id.ToString();
                if ((Manager != null))
                    _selectedClient.Manager = Manager.Id.ToString();
                else
                    _selectedClient.Manager = null!;

                if ((Product != null))
                    _selectedClient.Products = Product.ProductId.ToString();
                else
                    _selectedClient.Products = null!;

                _unit.Client.Update(_selectedClient);
                MessageBox.Show("Успешно изменено");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}

