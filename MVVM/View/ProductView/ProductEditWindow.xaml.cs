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
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        private IUnit _unit = new Unit(new AppDbConetext.Context());
        private Product _selectedProduct = new Product();
        public ProductEditWindow()
        {
            InitializeComponent();
        }
        public ProductEditWindow(int id)
        {
            InitializeComponent();
            _selectedProduct = _unit.Product.Get(o=>o.ProductId==id);

            Name_textBox.Text = _selectedProduct.Name;

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

        private void Update_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Name_textBox.Text.IsNullOrEmpty() || Type_comboBox.SelectedValue.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();
                if ((Models.Enum.Type)Type_comboBox.SelectedValue == Models.Enum.Type.Subscription && Period_comboBox.SelectedValue.ToString().IsNullOrEmpty())
                    throw new NullReferenceException();

                if (!Name_textBox.Text.IsNullOrEmpty() && (Models.Enum.Type)Type_comboBox.SelectedValue == Models.Enum.Type.Permanent)
                {
                    _selectedProduct.Name = Name_textBox.Text;
                    _selectedProduct.Type = Models.Enum.Type.Permanent;
                    _selectedProduct.Period = 0;
                    _unit.Product.Update(_selectedProduct);
                    _unit.Save();
                    this.Close();
                }
                if (!Name_textBox.Text.IsNullOrEmpty() && (Models.Enum.Type)Type_comboBox.SelectedValue == Models.Enum.Type.Subscription)
                {
                    _selectedProduct.Name = Name_textBox.Text;
                    _selectedProduct.Type = Models.Enum.Type.Subscription;
                    _selectedProduct.Period = (Models.Enum.SubscriptionPeriod)Period_comboBox.SelectedValue;
                    _unit.Product.Update(_selectedProduct);
                    _unit.Save();
                    this.Close();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Пожалуйста,заполните обязательные формы");
            }
        }
    }
}
