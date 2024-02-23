using SoftTradeTEST.Repository.IRepository;
using SoftTradeTEST.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.Models;
using System.Windows;
using Microsoft.IdentityModel.Tokens;

namespace SoftTradeTEST.MVVM.ViewModel.ManagerVM
{
    internal class EditManagerViewModel
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public Manager SelectedManager {  get; set; }
        public ICommand EditManagerCommand { get; set; }
        public string? Name { get; set; }

        public EditManagerViewModel(int id)
        {
            SelectedManager = _unit.Manager.Get(id);

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

                SelectedManager.Name = Name;
                _unit.Manager.Update(SelectedManager);
                MessageBox.Show("Успешно изменено");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}
