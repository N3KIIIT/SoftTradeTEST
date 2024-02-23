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

namespace SoftTradeTEST.MVVM.View.ManagerView
{
    /// <summary>
    /// Interaction logic for CreateManagerWindow.xaml
    /// </summary>
    public partial class CreateManagerWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection()); 
        public CreateManagerWindow()
        {
            InitializeComponent();
            CreateManagerViewModel createManagerViewModel = new CreateManagerViewModel();
            this.DataContext = createManagerViewModel;
        }
        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
