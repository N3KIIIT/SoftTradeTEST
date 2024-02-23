using Microsoft.IdentityModel.Tokens;
using SoftTradeTEST.MVVM.Models;
using SoftTradeTEST.MVVM.ViewModel.ProductVM;
using SoftTradeTEST.Repository;
using SoftTradeTEST.Repository.IRepository;
using System.Windows;


namespace SoftTradeTEST.MVVM.View.ProductView
{
    /// <summary>
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {

        public ProductCreateWindow()
        {
            InitializeComponent();

            CreateProductViewModel productCreateViewModel = new CreateProductViewModel();
            this.DataContext = productCreateViewModel;

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
