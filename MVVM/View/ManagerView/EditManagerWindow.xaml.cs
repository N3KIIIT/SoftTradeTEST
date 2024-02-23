using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ManagerVM;
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

namespace SoftTradeTEST.MVVM.View
{
    /// <summary>
    /// Interaction logic for EditManagerWindow.xaml
    /// </summary>
    public partial class EditManagerWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        public EditManagerWindow(int id)
        {
            InitializeComponent();

            EditManagerViewModel editManagerWindow = new EditManagerViewModel(id);
            this.DataContext = editManagerWindow;

            Name_textBox.Text = _unit.Manager.Get(id).Name;
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
