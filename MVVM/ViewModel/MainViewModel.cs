using SoftTradeTEST.Commands;
using SoftTradeTEST.MVVM.View;
using SoftTradeTEST.MVVM.View.ManagerView;
using SoftTradeTEST.MVVM.View.ProductView;

using System.Windows.Input;

namespace SoftTradeTEST.MVVM.ViewModel
{
    internal class MainViewModel
    {

        public ICommand ShowManagerWindowCommand { get; set; }
        public ICommand ShowProductWindowCommand { get; set; }
        public ICommand ShowClientWindowCommand { get; set; }
        
        public MainViewModel() 
        {
            ShowManagerWindowCommand = new RelayCommand(ShowManagerWindow,CanShowWindow);
            ShowProductWindowCommand = new RelayCommand(ShowProductWindow, CanShowWindow);
            ShowClientWindowCommand = new RelayCommand(ShowClientWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowManagerWindow(object obj)
        {
           ManagerWindow managerWindow = new ManagerWindow();
            managerWindow.ShowDialog();
        } 
        private void ShowProductWindow(object obj)
        {
           ProductWindow managerWindow = new ProductWindow();
            managerWindow.ShowDialog();
        }
        private void ShowClientWindow(object obj)
        {
           ClientWindow managerWindow = new ClientWindow();
            managerWindow.ShowDialog();
        }
    }
}
