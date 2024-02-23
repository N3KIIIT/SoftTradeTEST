using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ProductVM;
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

namespace SoftTradeTEST.MVVM.View.ProductView
{
    /// <summary>
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        public ProductEditWindow(int id)
        {
            InitializeComponent();

            EditProductViewModel editProductViewModel = new EditProductViewModel(id);
            this.DataContext = editProductViewModel;

            Type_comboBox.ItemsSource = new object[]
           {
                Models.Enum.Type.Subscription,
                Models.Enum.Type.Permanent,
           };
            Period_comboBox.ItemsSource = new object[] {
                Models.Enum.SubscriptionPeriod.Month,
                Models.Enum.SubscriptionPeriod.Quarter,
                Models.Enum.SubscriptionPeriod.Year
            };
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
