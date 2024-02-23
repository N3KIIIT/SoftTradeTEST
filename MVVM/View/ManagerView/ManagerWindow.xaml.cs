
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using System.Windows;
using System.Windows.Controls;


namespace SoftTradeTEST.MVVM.View.ManagerView
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
         private IUnit _unit = new Unit(new DB.DbConnection());

        public ManagerWindow()
        {
            InitializeComponent();

            ManagerViewModel managerViewModel = new ManagerViewModel();
            this.DataContext = managerViewModel;           
        }

        private void RefreshDataGridView()
        {
            DataGrid.ItemsSource = _unit.Manager.GetAll();
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGridView();
        }

    }
}
