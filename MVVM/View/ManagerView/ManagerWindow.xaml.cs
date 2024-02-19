using SoftTradeTEST.Models;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoftTradeTEST.MVVM.View.ManagerView
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
         private IUnit _unit = new Unit(new DB.DbConnection());
        private Manager _selectedManager { get; set; } = null;

        public ManagerWindow()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            CreateManagerWindow managerWindow = new CreateManagerWindow();
            managerWindow.ShowDialog();
        }

        private void Edit_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedManager == null)
                    throw new NullReferenceException();


                EditManagerWindow managerWindow = new EditManagerWindow(_selectedManager.Id);
                managerWindow.ShowDialog();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите отредактировать");
            }
        }
        private void Delete_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_selectedManager == null)
                    throw new NullReferenceException();

            MessageBoxResult result = MessageBox.Show("Вы уверены", "Подтвердить", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) 
                _unit.Manager.Remove(_selectedManager);

                RefreshDataGridView();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Выберите что хотите удалить");
            }


        }
        private void RefreshDataGridView()
        {
            DataGrid.ItemsSource = _unit.Manager.GetAll();
            _selectedManager = null;
        }

        private void DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            _selectedManager = (Manager)DataGrid.SelectedValue;
        }

        private void Refresh_button_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
