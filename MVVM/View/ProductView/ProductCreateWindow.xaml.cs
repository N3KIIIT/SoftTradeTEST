using Microsoft.IdentityModel.Tokens;
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

namespace SoftTradeTEST.MVVM.View.ProductView
{
    /// <summary>
    /// Interaction logic for ProductCreateWindow.xaml
    /// </summary>
    public partial class ProductCreateWindow : Window
    {
        private IUnit _unit = new Unit(new DB.DbConnection());
        
        public ProductCreateWindow()
        {
            InitializeComponent();
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

        private void Create_button_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product();
            try
            {
                if (Name_textBox.Text.IsNullOrEmpty() || Type_comboBox.SelectedValue.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();
                if ((Models.Enum.Type)Type_comboBox.SelectedValue == Models.Enum.Type.Subscription && Period_comboBox.SelectedValue.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();

                if (!Name_textBox.Text.IsNullOrEmpty() && (Models.Enum.Type)Type_comboBox.SelectedValue == Models.Enum.Type.Permanent)
                {
                    product.Name = Name_textBox.Text;
                    product.Type = Models.Enum.Type.Permanent;
                    
                    _unit.Product.Add(product);
                    this.Close();
                }
                if (!Name_textBox.Text.IsNullOrEmpty() && (Models.Enum.Type)Type_comboBox.SelectedValue == Models.Enum.Type.Subscription)
                {
                    product.Name = Name_textBox.Text;
                    product.Type = Models.Enum.Type.Subscription;
                    product.Period = (Models.Enum.SubscriptionPeriod)Period_comboBox.SelectedValue;
                    _unit.Product.Add(product);
                    this.Close();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }

        private void Cancel_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
