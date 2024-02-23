
using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.View;
using SoftTradeTEST.MVVM.View.ManagerView;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using System.Data.Common;
using System.Windows;
using System.Windows.Input;

namespace SoftTradeTEST.MVVM.ViewModel
{
    internal class ManagerViewModel
    {
        private readonly IUnit _unit = new Unit(new DB.DbConnection());
        public Manager? SelectedManager { get; set; }
        public IEnumerable<Manager> Managers { get; set; }
        public ICommand CreateManagerWindowCommand { get; set; }
        public ICommand EditManagerWindowCommand { get; set; }
        public ICommand DeleteManagerCommand { get; set; }
        public ManagerViewModel()
        {
            Managers = _unit.Manager.GetAll();

            CreateManagerWindowCommand = new RelayCommand(CreateManagerWindow, CanShowWindow);
            EditManagerWindowCommand = new RelayCommand(EditManagerWindow, CanShowWindow);
            DeleteManagerCommand = new RelayCommand(DeleteManager, CanShowWindow);
        }

        private void CreateManagerWindow(object obj)
        {
            CreateManagerWindow editManagerWindow = new CreateManagerWindow();
            editManagerWindow.ShowDialog();
        }
        private void EditManagerWindow(object obj)
        {
            EditManagerWindow editManagerWindow = new EditManagerWindow(SelectedManager.Id);
            editManagerWindow.ShowDialog();
        }

        private void DeleteManager(object obj)
        {
            try
            {
                if (SelectedManager == null)
                    throw new NullReferenceException();

                MessageBoxResult result = MessageBox.Show("Вы уверены", "Подтвердить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    _unit.Manager.Remove(SelectedManager);

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
