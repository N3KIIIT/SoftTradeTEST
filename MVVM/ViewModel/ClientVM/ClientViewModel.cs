using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.View.ManagerView;
using SoftTradeTEST.MVVM.View;
using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SoftTradeTEST.MVVM.View.ClientView;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace SoftTradeTEST.MVVM.ViewModel.ClientVM
{
    internal class ClientViewModel
    {
        private readonly IUnit _unit = new Unit(new DB.DbConnection());
        public MVVM.Models.Client SelectedClient { get; set; }
        public List<Client> Clients { get; set; }
        
        
        public ICommand CreateClientWindowCommand { get; set; }
        public ICommand EditClientWindowCommand { get; set; }
        public ICommand DeleteClientCommand { get; set; }

      
        public ClientViewModel()
        {

            CreateClientWindowCommand = new RelayCommand(CreateClientWindow, CanShowWindow);
            EditClientWindowCommand = new RelayCommand(EditClientWindow, CanShowWindow);
            DeleteClientCommand = new RelayCommand(DeleteClient, CanShowWindow);

        }

        private void CreateClientWindow(object obj)
        {
            ClientCreateWindow editManagerWindow = new ClientCreateWindow();
            editManagerWindow.ShowDialog();
        }
        private void EditClientWindow(object obj)
        {
            ClientEditWindow editManagerWindow = new ClientEditWindow(SelectedClient.Id);
            editManagerWindow.ShowDialog();
        }

        private void DeleteClient(object obj)
        {
            try
            {
                if (SelectedClient == null)
                    throw new NullReferenceException();


                MessageBoxResult result = MessageBox.Show("Вы уверены", "Подтвердить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    _unit.Client.Remove(_unit.Client.Get(SelectedClient.Id));

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
