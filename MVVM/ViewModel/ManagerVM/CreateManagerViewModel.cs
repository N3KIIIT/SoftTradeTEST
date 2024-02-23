using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace SoftTradeTEST.MVVM.ViewModel.ManagerVM
{
    internal class CreateManagerViewModel
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public ICommand CreateManagerCommand { get; set; }
        public string? Name { get; set; }

        public CreateManagerViewModel()
        {
            CreateManagerCommand = new RelayCommand(CreateManager, CanCreateManager);
        }
        private void CreateManager(object obj)
        {

            try
            {
                if (Name.IsNullOrEmpty())
                    throw new NullReferenceException();

                Manager manager = new Manager()
                {
                    Name = Name
                };
                _unit.Manager.Add(manager);

                MessageBox.Show("Успешно создано");

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }

        private bool CanCreateManager(object obj)
        {
                return true;
        }
    }
}
